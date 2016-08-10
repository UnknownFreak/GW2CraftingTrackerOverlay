using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;

namespace OverlayApp
{
    [Serializable]
    public class ItemRecipe
    {
        public string name = "None";
        public string itemIcon = "None";
        public uint itemID;
        public uint count = 0;
        public uint totalCount = 0;
        public uint current = 0;

        public TPinfo tpCost;
        public List<string> aquireIcons = new List<string>();
        public List<ItemRecipe> requiredItems = new List<ItemRecipe>();
        TreeViewItem tvi = null;
        public TreeViewItem getItemRecipeAsTreeItem()
        {
            tvi = new TreeViewItem();
            tvi.IsExpanded = true;
            //tvi.IsHitTestVisible = false;
            tvi.Header = new ItemProgressView(this);

            foreach(ItemRecipe ir in requiredItems)
                tvi.Items.Add(ir.getItemRecipeAsTreeItem());
            return tvi;
        }
        public TreeViewItem getTreeViewItem()
        {
            return tvi;
        }
        public void updateSubItems()
        {
            updateSubItems(count, current);
        }
        private void updateSubItems(uint _count, uint _current)
        {
            foreach(ItemRecipe ir in requiredItems)
            {
                ir.updateSubItems(ir.count*(_count-_current),ir.current);
            }
            if ((current >= totalCount) && (requiredItems.Count > 0) && Properties.Settings.Default.AutoRemoveSubItems)
            {
                requiredItems.Clear();
                tvi.Items.Clear();
            }
            uint bshft = (_count >> 31) & 1;
            if (bshft == 1)
                totalCount = 0;
            else
                totalCount = _count ;
        }
        public void updateItemCount(GW2APIComponent.GW2Object obj)
        {
            current = obj.GetComponent<GW2APIComponent.GW2Components.V2.Account.AccountComponent>().getTotalItemCount(itemID);
            updateSubItems(obj);
        }
        public void updateSubItems(GW2APIComponent.GW2Object obj)
        {
            foreach (ItemRecipe ir in requiredItems)
                ir.updateItemCount(obj);
        }
        public Dictionary<string,ItemRecipe> getRecipes( Random random , ref TreeNode tn)
        {
            Dictionary<string, ItemRecipe> _items = new Dictionary<string, ItemRecipe>();
            string n = name + random.NextUInt64().ToString();
            _items.Add(n, this);
            tn = new TreeNode(name);
            tn.Name = n;
            foreach (ItemRecipe ir in requiredItems)
            {
                var subs = getSubRecipes(ir, ref tn, random);
                foreach (var v in subs)
                    _items.Add(v.Key, v.Value);
            }
            return _items;
        }
        private Dictionary<string,ItemRecipe> getSubRecipes(ItemRecipe sub, ref TreeNode tn, Random random)
        {
            Dictionary<string, ItemRecipe> _items = new Dictionary<string, ItemRecipe>();
            string n = name + random.NextUInt64().ToString();
            _items.Add(n, sub);
            TreeNode subNode = tn.Nodes.Add(n,sub.name);
            foreach (ItemRecipe ir in sub.requiredItems)
            {
                var subs = getSubRecipes(ir, ref subNode, random);
                foreach (var v in subs)
                    _items.Add(v.Key, v.Value);
            }
            return _items;
        }
    }
}
