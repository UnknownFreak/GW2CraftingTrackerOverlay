using GW2APIComponent.BaseComponents;
using System;
using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Trading
{
    [Serializable]
    public class ItemTradeComponent : IBaseComponent<ItemTradeComponent>
    {

        List<uint> transactionItems = new List<uint>();

        public ItemTradeComponent()
            : base("ItemTradeComponent", eComponentTypeID.ItemTradeComponent)
        {
            URL = "https://api.guildwars2.com/v2/commerce/prices";
            transactionItems = requestJSON<List<uint>>(URL);
        }

        public bool isItemTradable(uint itemID)
        {
            if (transactionItems.Contains(itemID))
                return true;
            return false;
        }

        public ItemTradePrice getItemPrice(uint itemId)
        {
            ItemTradePrice tprice = requestJSON<ItemTradePrice>(URL + "/" + itemId);
            return tprice;
        }

    }
}
