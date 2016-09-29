using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GW2APIComponent;
using GW2APIComponent.GW2Components;
using GW2APIComponent.GW2Components.V2.Account;
using System.ComponentModel;
using System.Threading.Tasks;
using GW2APIComponent.GW2Components.V2.Trading;

namespace OverlayApp
{
    /// <summary>
    /// Interaction logic for OverlayInfo.xaml
    /// </summary>
    public partial class OverlayInfo : UserControl
    {
        private string fileName = "ItemProjects.xml";
        public event EventHandler<ErrorInfo> onError;
        List<ItemProject> projects = new List<ItemProject>();
        private GW2Object obj;
        private APIKeyInfoComponent apikey;
        private APIKeyPermissionsComponent permissions;
        private AccountComponent accountInfo;
        public OverlayInfo()
        {
            object[] o = {Properties.Settings.Default.APIKey};
            InitializeComponent();
            obj = new GW2Object();
            apikey = obj.AddComponent<APIKeyInfoComponent>(o);
            permissions = obj.AddComponent<APIKeyPermissionsComponent>(null);
            accountInfo = obj.AddComponent<AccountComponent>(null);
            obj.AddComponent<ItemTradeComponent>(null);
            loadItemProjects();
        }
        /// <summary>
        /// Loads item projects from saved data file.
        /// </summary>
        public void loadItemProjects()
        {
            Serialize.Serializer.DeSerializeObject(out projects,fileName);
            reloadProjects();
        }
        /// <summary>
        /// Reloads the item projects.
        /// </summary>
        public void reloadProjects()
        {
            ItemList.Items.Clear();
            foreach (ItemProject ip in projects)
                foreach (ItemRecipe ir in ip.items)
                    ItemList.Items.Add(ir.getItemRecipeAsTreeItem());
        }
        /// <summary>
        /// Adds a item project to the information window.
        /// </summary>
        /// <param name="project">The desired project to add.</param>
        public void addItemProject(ItemProject project)
        {
            projects.Add(project);
            ItemList.Items.Clear();
            foreach (ItemProject ip in projects)
                foreach (ItemRecipe ir in ip.items)
                    ItemList.Items.Add(ir.getItemRecipeAsTreeItem());
        }
        /// <summary>
        /// Removes a item project from the information window.
        /// </summary>
        /// <param name="project">The desired project to remove.</param>
        public void removeItemProject(ItemProject project)
        {
            projects.Remove(project);
            ItemList.Items.Clear();
            foreach (ItemProject ip in projects)
                foreach (ItemRecipe ir in ip.items)
                    ItemList.Items.Add(ir.getItemRecipeAsTreeItem());
        }
        /// <summary>
        /// Removes all item projects added to this window.
        /// </summary>
        public void clearItemProjects()
        {
            projects.Clear();
            ItemList.Items.Clear();
        }
        /// <summary>
        /// Updates the number of items the current projects contains.
        /// </summary>
        public void updateItemCount()
        {
            foreach (ItemProject ip in projects)
            {
                foreach(ItemRecipe ir in ip.items)
                {
                    ir.updateItemCount(obj);
                }
            }
        }
        /// <summary>
        /// Updates the item projects.
        /// </summary>
        public void updateItemProjects()
        {
            try
            {
                List<int> remove = new List<int>();
                Dispatcher.Invoke(new Action(() =>
                {
                    for (int i = 0; i < ItemList.Items.Count; i++)
                    {
                        bool Q = updateTreeView(ItemList.Items.GetItemAt(i) as TreeViewItem);
                        if (Q)
                            remove.Add(i);
                    }
                    foreach (int item in remove)
                    {
                        ItemList.Items.RemoveAt(item);
                    }
                }));
            }
            catch
            {

            }
        }
        bool updateTreeView(TreeViewItem item)
        {
            List<ItemProject> erase = new List<ItemProject>();
            (item.Header as ItemProgressView).update();
            try
            {
                foreach (TreeViewItem tvi in item.Items)
                    updateTreeViewNonAsync(tvi);
            }
            catch { }
            foreach (ItemProject ip in projects)
            {
                ip.update();
                if (ip.items.Count == 0 || (ip.allRecipesDone() && Properties.Settings.Default.AutoRemoveProject))
                {
                    erase.Add(ip);
                }
            }
            if (erase.Count != 0)
            {
                foreach (ItemProject ip in erase)
                    projects.Remove(ip);
                return true;
            }
            return false;
        }
        void updateTreeViewNonAsync(TreeViewItem item)
        {
            (item.Header as ItemProgressView).update();
            try
            {
                foreach (TreeViewItem tvi in item.Items)
                    updateTreeViewNonAsync(tvi);
            }
            catch { }
        }
        /// <summary>
        /// Sets the API key to use.
        /// </summary>
        /// <param name="str">The API key.</param>
        public void setAPIKey(string str)
        {
            apikey.setAPIKey(str);
        }
        /// <summary>
        /// Updates the account information.
        /// </summary>
        public void updateAccountInformation()
        {
            try
            {
                accountInfo.update();
                onError?.Invoke(this, null);
            }
            catch (GW2APIComponent.GW2Components.Exceptions.BaseGw2Exception ex)
            {
                if (onError != null)
                {
                    if (ex.GetType() == typeof(GW2APIComponent.GW2Components.Exceptions.APIKeyLacksPermissionException))
                    {
                        var v = ex as GW2APIComponent.GW2Components.Exceptions.APIKeyLacksPermissionException;
                        Dispatcher.Invoke(new Action(() =>
                        {
                            onError(this, new ErrorInfo(new List<string>() { v.Message, v.MissingPermission }));
                        }));
                    }
                    else
                        Dispatcher.Invoke(new Action(() =>
                        {
                            onError(this, new ErrorInfo(ex.Message));
                        }));
                }
            }
        }
        public void UserControl_Unloaded(object sender, CancelEventArgs e)
        {
            Serialize.Serializer.SerializeObject(projects, fileName);
        }
        /// <summary>
        /// Gets item project from name.
        /// </summary>
        /// <param name="name">The name of the item project to find.</param>
        /// <returns>Item project if exists.</returns>
        public ItemProject getItemProject(string name)
        {
            return projects.Find(x => x.projectName == name);
        }
        /// <summary>
        /// Gets a list of item project names.
        /// </summary>
        /// <returns>List of strings containing the names.</returns>
        public List<string> getItemProjectNames()
        {
            return projects.ConvertAll(x => x.projectName);
        }
    }
}
