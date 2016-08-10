using GW2APIComponent.BaseComponents;
using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Account.Materials
{
    public class MaterialStorageRequestComponent : IBaseComponent<MaterialStorageRequestComponent>
    {
        List<MaterialStorageItem> storage;
        public MaterialStorageRequestComponent(): base("MaterialStorageComponent",eComponentTypeID.MaterialStorageRequestComponent)
        {
        URL = "https://api.guildwars2.com/v2/account/materials?access_token=";
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
                throw new Exceptions.APIKeyLacksPermissionException("inventories");

            storage = requestJSON<List<MaterialStorageItem>>(URL + info.getAPIKey());
        }
        public uint getItemCount(uint itemID)
        {
            foreach(MaterialStorageItem msi in storage)
                if (itemID == msi.id)
                    return msi.count;
            return 0;
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
