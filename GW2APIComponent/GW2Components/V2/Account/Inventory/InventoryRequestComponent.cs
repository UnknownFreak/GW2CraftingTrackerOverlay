using GW2APIComponent.BaseComponents;
using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Account.Inventory
{
    public class InventoryRequestComponent : IBaseComponent<InventoryRequestComponent>
    {
        List<Characters.Inventory> accountInventory = new List<Characters.Inventory>();
        public InventoryRequestComponent() : base("InventoryRequestComponent", eComponentTypeID.AccountInventoryComponent)
        {
        URL = "https://api.guildwars2.com/v2/account/inventory?access_token=";
        }
        public void fetchItems()
        {
            APIKeyInfoComponent info = GetComponent<APIKeyInfoComponent>();
            APIKeyPermissionsComponent permissions = GetComponent<APIKeyPermissionsComponent>();
            if (info == null)
                throw new Exceptions.APIKeyNotFoundException();
            if (!info.isValid())
                throw new Exceptions.APIKeyInvalidException();
            if (permissions == null)
                throw new Exceptions.APIKeyPermissionsNotFoundException();
            if (!permissions.hasRequiredPermission("inventories"))
                throw new Exceptions.APIKeyLacksPermissionException();
            accountInventory = requestJSON<List<Characters.Inventory>>(URL + GetComponent<APIKeyInfoComponent>().getAPIKey());
        }
        public uint getItemCount(uint itemID)
        {
            uint count = 0;
            foreach(Characters.Inventory inv in accountInventory)
                if(inv.id == itemID)
                    count += inv.count;
            return count;
        }
        public override void update()
        {
            try
            {
                fetchItems();
            }
            catch
            {
                throw;
            }
        }
    }
}
