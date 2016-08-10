using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OverlayApp
{
    [Serializable]
    public class ItemProject
    {
        public string projectName { get; set; }
        public List<ItemRecipe> items = new List<ItemRecipe>();
        public ItemProject()
        {
            
        }
        public void update()
        {
            foreach(ItemRecipe ir in items)
            {
                ir.updateSubItems();
                if (ir.current > ir.totalCount && Properties.Settings.Default.AutoRemoveCompletedItem)
                    items.Remove(ir);
            }
        }
        public Dictionary<string,ItemRecipe> toRecipeDictionary(out List<TreeNode>tns)
        {
            Random rng = new Random();
            Dictionary<string, ItemRecipe> _items = new Dictionary<string, ItemRecipe>();
            tns = new List<TreeNode>();
            foreach (ItemRecipe ir in items)
            {
                TreeNode tn = new TreeNode();
                var subs = ir.getRecipes(rng,ref tn);
                foreach (var v in subs)
                    _items.Add(v.Key, v.Value);
                tns.Add(tn);
            }
            return _items;
        }
        public bool allRecipesDone()
        {
            return items.TrueForAll(x => x.current >= x.totalCount);
        }
    }
}
