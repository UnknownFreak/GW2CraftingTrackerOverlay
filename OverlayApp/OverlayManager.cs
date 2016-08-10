using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GW2APIComponent;
using GW2APIComponent.GW2Components.V2.Items;
using GW2APIComponent.GW2Components.V2.Recipes;

namespace OverlayApp
{
    public partial class OverlayManager : Form
    {
        ItemProject newProject = new ItemProject();
        ItemProject editProject;
        ItemRecipe editItem = null;
        Dictionary<string, ItemRecipe> temporaryItemProject = new Dictionary<string, ItemRecipe>();
        GW2Object gw2InformationObject = new GW2Object();
        ItemListComponent list;
        RecipeRequestComponent recipe;
        Random random = new Random();
        List<string> additemStrings = new List<string>();
        OverlayWindow overlay;

        public OverlayManager(OverlayWindow myOverlay)
        {
            //setOverlayParent;
            overlay = myOverlay;
            
            InitializeComponent();

            // AddComponents
            list = gw2InformationObject.AddComponent<ItemListComponent>(null);
            recipe = gw2InformationObject.AddComponent<RecipeRequestComponent>(null);
            list.onAdd += list_onAdd;
            // start backgroundworkers
            itemListFetcher.RunWorkerAsync();
            AddItemWorker.RunWorkerAsync();

            //set sorting algorithm for the itemNameList
            Disposed += OverlayManager_Disposed;

            itemProjectList.Items.AddRange(overlay.OverlayInfo.getItemProjectNames().ToArray());
            editProject = newProject;
        }

        void list_onAdd(object sender, string e)
        {
            Invoke((MethodInvoker)delegate
            {
                itemsFetched.Text = e;
            });
        }

        void OverlayManager_Disposed(object sender, EventArgs e)
        {
            saveitems();
            Properties.Settings.Default.Save();
        }

        private void loaditems()
        {
            if (System.IO.File.Exists("iteminfo.txt"))
            {
                using (System.IO.StreamReader fs = new System.IO.StreamReader("iteminfo.txt"))
                {
                    string line;
                    while (!fs.EndOfStream)
                    {
                        line = fs.ReadLine();
                        string[] idSplit = line.Split(',');
                        list.itemNames.Add(Convert.ToUInt32(idSplit[0]), idSplit[1]);
                    }
                }
            }
            setUpDataGridView("");
        }

        private void saveitems()
        {
            using (System.IO.StreamWriter fs = new System.IO.StreamWriter("iteminfo.txt"))
            {
                foreach(var iter in list.itemNames)
                {
                    fs.Write(iter.Key);
                    fs.Write("," + iter.Value +"\n");
                }
            }
        }

        private void Overlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
                return;
            }
            if (itemListFetcher.IsBusy)
                itemListFetcher.CancelAsync();
            if(AddItemWorker.IsBusy)
                AddItemWorker.CancelAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            setUpDataGridView(searchBox.Text);
        }

        private void addItemToProject_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow v in itemNameList.SelectedRows)
            {
                DataGridInfo dgi = (DataGridInfo)v.DataBoundItem;
                additemStrings.Add(dgi.ID.ToString());
            }
        }

        private ItemRecipe getSubItemsInRecipe(uint itemID, uint count, uint previousItemCount, TreeNode parentNode)
        {
            UInt64 randomized = random.NextUInt64();
            TreeNode myNode = new TreeNode();
            ItemRecipe ir = new ItemRecipe();
            Recipe r = new Recipe();
            Item i = list.getItem(itemID);
            if (parentNode == null)
                Invoke((MethodInvoker)delegate
                {
                    parentNode = myNode = itemList.Nodes.Add(i.name + randomized.ToString(), i.name);
                    addItemStatusLabel.Text = "Adding Item To List: " + i.name;
                });
            else
                Invoke((MethodInvoker)delegate
                { 
                    myNode = parentNode.Nodes.Add(i.name + randomized.ToString(), i.name);
                    addItemStatusLabel.Text = "Adding Item: \""+i.name +"\" To Parent: " + parentNode.Text;
                });
            temporaryItemProject.Add(myNode.Name, ir);
            ir.name = i.name;
            ir.itemID = itemID;
            ir.itemIcon = i.icon;
            ir.count = count;
            ir.totalCount = previousItemCount * count;
            ir.current = 0;

            // getTpCost

            var v = recipe.requestRecipe(itemID, false);

            if (v.Count != 0)
            {
                if (v.Count > 1)
                {
                    //show list and let user chose the recipe
                    //for now add the first one that pops up
                    ir.requiredItems = addItemsFromRecipe(v[0], false, ir.totalCount, ir, myNode);
                }
                else
                {
                    ir.requiredItems = addItemsFromRecipe(v[0], false, ir.totalCount, ir, myNode);
                }
            }
            else // check gw2profits for a recipe
            {
                ir.requiredItems = addItemsFromRecipe(ir.itemID, true, ir.totalCount, ir, myNode);
            }
            return ir;
        }
        private List<ItemRecipe> addItemsFromRecipe(uint recipeID, bool useGW2Profits, uint previousItemCount, ItemRecipe parentRecipe, TreeNode parent)
        {
            List<ItemRecipe> ir = new List<ItemRecipe>();
            Recipe myrecipe = new Recipe();
            if(!useGW2Profits)
                myrecipe = recipe.requestRecipeInfo(recipeID);
            else
            {
                var recipes = recipe.requestMysticForgeRecipe(recipeID);
                if (recipes.Count != 0)
                {
                    if (recipes.Count > 1)
                    {
                        myrecipe = recipes[0];
                    }
                    else
                        myrecipe = recipes[0];
                }
            }
            if(myrecipe.disciplines != null)
                parentRecipe.aquireIcons = myrecipe.disciplines;
            // sets recipe to null if it contains the same id as parent
            if(myrecipe.ingredients != null)
                if (myrecipe.ingredients.Select(x => x.ID).ToList().Contains((int)recipeID))
                {
                    myrecipe = null;
                    parentRecipe.aquireIcons.Clear();
                }
            if(myrecipe != null && myrecipe.disciplines != null)
                if(myrecipe.ingredients != null)
                    foreach (Ingredient ingr in myrecipe.ingredients)
                    {
                        if(ingr.ID > 0)
                            ir.Add(getSubItemsInRecipe((uint)ingr.ID, ingr.count, previousItemCount,parent));
                    }
            return ir;
        }
        private void itemList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.FullPath.Contains("\\"))
                itemCount.Enabled = false;
            else
                itemCount.Enabled = true;
            editItem = temporaryItemProject[e.Node.Name];
            itemCount.Value = editItem.count;
            itemCountTotal.Text = editItem.totalCount.ToString();
        }
        private void itemCount_ValueChanged(object sender, EventArgs e)
        {
            if (editItem != null)
            {
                editItem.count = (uint)itemCount.Value;
                if(itemCount.Enabled)
                    editItem.updateSubItems();
            }
        }
        private void addItemProject_Click(object sender, EventArgs e)
        {
            ItemProject ip = new ItemProject();
            foreach(TreeNode tn in itemList.Nodes)
                ip.items.Add(temporaryItemProject[tn.Name]);
            ip.items[0].updateSubItems();
            overlay.OverlayInfo.addItemProject(ip);
            itemList.Nodes.Clear();
            temporaryItemProject.Clear();

            ip.projectName = projectNameField.Text;

            itemProjectList.Items.Add(ip.projectName);

        }
        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode tn = itemList.SelectedNode;
            if (tn != null)
            {
                if( tn.Nodes != null)
                    foreach (TreeNode subnode in tn.Nodes)
                    {
                        removeNodes(subnode);
                        temporaryItemProject.Remove(tn.Name);
                    }
                itemList.SelectedNode.Remove();
            }
        }
        private void removeNodes(TreeNode tn)
        {
            if(tn != null)
                if (tn.Nodes != null)
                {
                    foreach (TreeNode subnode in tn.Nodes)
                    {
                        temporaryItemProject.Remove(subnode.Name);
                        removeNodes(subnode);
                    }
                    tn.Nodes.Clear();
                }
        }
        private void removeSubTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (itemList.SelectedNode != null)
            {
                removeNodes(itemList.SelectedNode);
                temporaryItemProject[itemList.SelectedNode.Name].requiredItems.Clear();
                if (temporaryItemProject[itemList.SelectedNode.Name].aquireIcons.Contains("Merchant"))
                {
                    temporaryItemProject[itemList.SelectedNode.Name].aquireIcons.Clear();
                    temporaryItemProject[itemList.SelectedNode.Name].aquireIcons.Add("Merchant");
                }
                else
                    temporaryItemProject[itemList.SelectedNode.Name].aquireIcons.Clear();
            }
        }


        private void setUpDataGridView(string search)
        {
            Invoke((MethodInvoker)delegate
            {
                itemNameList.DataSource = list.itemNames
                             .Select(x => new DataGridInfo(x.Key,x.Value)
                             ).Where(y => y.ItemName.Contains(search, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                itemsFetched.Text = "Done";
            });
        }

        #region WorkerThreads
        private void itemListFetcher_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool isdone = false;
            if ((e.Argument as string) == "FetchMissingItems")
            {
                list.getAllItemNames();
            }
            else
            {
                loaditems();
                while (!isdone)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    isdone = list.checkForAddedItems();
                    worker.ReportProgress(0);
                }
            }
            try
            {
                setUpDataGridView("");
            }
            catch (ObjectDisposedException)
            { return; }
        }

        private void itemListFetcher_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void itemListFetcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Equals(e.Error))
            {
                MessageBox.Show(e.Error.Message);
            }
        }
        private void AddItemWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool isdone = false;

            while (!isdone)
            {
                System.Threading.Thread.Sleep(70);
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                if (additemStrings.Count != 0)
                {
                    ItemRecipe ir = getSubItemsInRecipe(uint.Parse(additemStrings[0]), 1, 1, null);
                    additemStrings.RemoveAt(0);
                }
                else
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            addItemStatusLabel.Text = "";
                        });
                    }
                catch (ObjectDisposedException)
                    {
                        return;
                    }

            }
        }
        #endregion
        public class DataGridInfo
        {
            public DataGridInfo(UInt32 id, string name)
            {
                ID = id;
                ItemName = name;
            }
            public UInt32 ID { get; set; }
            public string ItemName { get; set; }
        }

        private void fetchMissingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (itemListFetcher.IsBusy)
                itemListFetcher.CancelAsync();
            itemListFetcher.RunWorkerAsync("FetchMissingItems");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<TreeNode> ltn;
            if (itemProjectList.SelectedItems.Count != 0)
            {
                if (itemProjectList.SelectedItem.ToString() == "<New Project>")
                    editProject = newProject;
                else
                    editProject = overlay.OverlayInfo.getItemProject(itemProjectList.SelectedItem.ToString());
                temporaryItemProject = editProject.toRecipeDictionary(out ltn);
                editProject.update();
                itemList.Nodes.Clear();
                itemList.Nodes.AddRange(ltn.ToArray());
            }
        }
    }
}
