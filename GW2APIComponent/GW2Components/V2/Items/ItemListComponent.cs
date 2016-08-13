using System;
using System.Collections.Generic;
using System.Linq;
using GW2APIComponent.BaseComponents;
namespace GW2APIComponent.GW2Components.V2.Items
{
    [Serializable]
    public class ItemListComponent : IBaseComponent<ItemListComponent>
    {
        public event EventHandler<string> onAdd = null;
        public Dictionary<uint, string> itemNames = new Dictionary<uint,string>();
        List<uint> itemIDs = new List<uint>();

        public ItemListComponent()
            : base("ItemListComponent", eComponentTypeID.ItemListComponent)
        {
            URL = "https://api.guildwars2.com/v2/items";
            itemIDs = requestJSON<List<uint>>(URL);
        }
        public bool checkForAddedItems()
        {
            if (itemNames.Count != itemIDs.Count)
                return requestItemNames((uint)itemNames.Count / 200);
            return true;
        }
        public int getMaxPages()
        {
            return itemIDs.Count / 200;
        }
        public Item getItem(uint itemID)
        {
            return requestJSON<Item>(URL + "/" + itemID);
        }
        public List<uint> getItemIDs()
        {
            return itemIDs;
        }
        public List<Item> getItemsByName(string name)
        {
            List<Item> items = new List<Item>();
            foreach (var v in itemNames)
            {
                if (v.Value.Contains(name))
                {
                    items.Add(getItem(v.Key));
                }
            }
            //if the key does not exist
            return items;
        }
        private bool requestItemNames(uint page)
        {
            if (page <= (uint)getMaxPages())
                return addNamesToList(fetchItems(page));
            return true;
        }
        private List<Item> fetchItems(uint pageNumber)
        {
            return requestJSON<List<Item>>(URL + "?page=" + pageNumber + "&page_size=200");
        }
        public void getAllItemNames()
        {
            List<Item> items = new List<Item>();
            int maxP = getMaxPages();
            for (int i = 0; i < maxP; i++)
            {
                items.AddRange(requestJSON<List<Item>>(URL + "?page=" + i + "&page_size=200"));
                onAdd?.Invoke(this,"Fetching Pages: "+i+"/"+maxP);
        }
            itemNames = items.ToDictionary(x => x.ID, x => x.name);
        }

        private bool addNamesToList(List<Item> items)
        {
            int count = 0;
            foreach(Item itm in items)
            {
                if (!itemNames.ContainsKey(itm.ID))
                {
                    itemNames.Add(itm.ID, itm.name);
                    onAdd?.Invoke(this,"Items Added: "+itemNames.Count+"/"+itemIDs.Count);
                }
                else
                    count++;
            }
            if (count == items.Count)
                return true;
            return false;
        }
    }
}
