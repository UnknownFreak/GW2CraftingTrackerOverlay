using GW2APIComponent.BaseComponents;
using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Account.Bank
{
    ///
    ///<summary>
    ///BankRequestComponent gets information related to an accounts bank space.
    ///<para>This component requires the object to have the APIKeyInfoComponent and </para>
    ///the APIKeyPermissionsComponent to get information and check if they key
    ///has the required permissions.
    ///</summary>
    ///
    public class BankRequestComponent : IBaseComponent<BankRequestComponent>
    {
        List<BankInfo> bankItems = new List<BankInfo>();
        public BankRequestComponent() :  base("BankRequestComponent",eComponentTypeID.BankRequestComponent)
        {
        URL = "https://api.guildwars2.com/v2/account/bank?access_token=";
        }
        /// <summary>
        /// Returns the number of items the account has stored in the bank.
        /// </summary>
        /// <param name="itemID">The item ID to look for.</param>
        /// <returns>The amount of items that was found with the "itemID" parameter.</returns>
        ///<exception cref="Exceptions.APIKeyNotFoundException">Thrown if api key not found.</exception>
        ///<exception cref="Exceptions.APIKeyInvalidException">Thrown if api key is invalid.</exception>
        ///<exception cref="Exceptions.APIKeyPermissionsNotFoundException">Thrown if api permissions not found.</exception>
        ///<exception cref="Exceptions.APIKeyLacksPermissionException">Thrown if api lacks permission.</exception>
        public uint GetItemCountFromBank(uint itemID)
        {
            uint count = 0;
            foreach (BankInfo bi in bankItems)
                if(bi != null)
                    if (bi.id == itemID)
                        count += bi.count;
            return count;
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
            bankItems = requestJSON<List<BankInfo>>(URL+ info.getAPIKey());
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
