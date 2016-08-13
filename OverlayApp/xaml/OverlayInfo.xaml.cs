using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GW2APIComponent;
using GW2APIComponent.GW2Components;
using GW2APIComponent.GW2Components.V2.Account;
using System.ComponentModel;
using System.Threading.Tasks;

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
            loadItemProjects();
        }
        public void loadItemProjects()
        {
            Serialize.Serializer.DeSerializeObject(out projects,fileName);
            reloadProjects();
        }
        public void reloadProjects()
        {
            ItemList.Items.Clear();
            foreach (ItemProject ip in projects)
                foreach (ItemRecipe ir in ip.items)
                    ItemList.Items.Add(ir.getItemRecipeAsTreeItem());
        }
        public void addItemProject(ItemProject project)
        {
            projects.Add(project);
            ItemList.Items.Clear();
            foreach (ItemProject ip in projects)
                foreach (ItemRecipe ir in ip.items)
                    ItemList.Items.Add(ir.getItemRecipeAsTreeItem());
        }
        public void removeItemProject(ItemProject project)
        {
            projects.Remove(project);
            ItemList.Items.Clear();
            foreach (ItemProject ip in projects)
                foreach (ItemRecipe ir in ip.items)
                    ItemList.Items.Add(ir.getItemRecipeAsTreeItem());
        }
        public void clearItemProjects()
        {
            projects.Clear();
            ItemList.Items.Clear();
        }
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
        public void setAPIKey(string str)
        {
            apikey.setAPIKey(str);
        }
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
        public ItemProject getItemProject(string name)
        {
            return projects.Find(x => x.projectName == name);
        }
        public List<string> getItemProjectNames()
        {
            return projects.ConvertAll(x => x.projectName);
        }
    }
}
