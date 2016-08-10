using GW2APIComponent.BaseComponents;
using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Account
{
    /// <summary>
    /// <para>
    /// Component that handles all the account information. If this is added to the object
    /// it checks if the following components are added and if they do not exist they will be added.
    /// </para>
    /// <list type="Number">
    /// <item>
    ///     <description>The component that handles account bank information.</description>
    /// </item>
    /// <item>
    ///     <description>The component that handles Character information.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class AccountComponent : IBaseComponent<AccountComponent>
    {
        private APIKeyPermissionsComponent permissions;
        private Bank.BankRequestComponent bankinfo;
        private Characters.CharacterRequestComponent characters;
        private Inventory.InventoryRequestComponent inventory;
        private Materials.MaterialStorageRequestComponent materials;
        private bool instantiated = false;
        
        public AccountComponent() : base("APIKeyPermissionsComponent",eComponentTypeID.AccountComponent)
        {
            URL = "https://api.guildwars2.com/v2/tokeninfo?access_token=";
        }
        public void instantiate()
        {
            permissions = GetComponent<APIKeyPermissionsComponent>();
            if (permissions == null)
                permissions = attachedOn.AddComponent<APIKeyPermissionsComponent>(null);
            if ((bankinfo = GetComponent<Bank.BankRequestComponent>()) == null)
                bankinfo = attachedOn.AddComponent<Bank.BankRequestComponent>(null);
            if ((characters = GetComponent<Characters.CharacterRequestComponent>()) == null)
                characters = attachedOn.AddComponent<Characters.CharacterRequestComponent>(null);
            if ((inventory = GetComponent<Inventory.InventoryRequestComponent>()) == null)
                inventory = attachedOn.AddComponent<Inventory.InventoryRequestComponent>(null);
            if ((materials = GetComponent<Materials.MaterialStorageRequestComponent>()) == null)
                materials = attachedOn.AddComponent<Materials.MaterialStorageRequestComponent>(null);
            instantiated = true;
        }
        public override void update()
        {
            if (instantiated == false)
                instantiate();
            try
            {
                if (GetComponent<APIKeyInfoComponent>().isValid())
                {
                    permissions.update();
                    bankinfo.update();
                    characters.update();
                    materials.update();
                    inventory.update();
                }
                else
                    throw new Exceptions.APIKeyInvalidException();
            }
            catch (System.Net.WebException)
            {
            }
            catch (System.NullReferenceException)
            {

            }
            catch
            {
                throw;
            }
        }

        public uint getTotalItemCount(uint itemID)
        {
            uint count = 0;
            if (!GetComponent<APIKeyInfoComponent>().isValid())
                return 0;
            try
            {
                permissions.getPermissions();
            }
            catch (Exceptions.APIKeyNotFoundException)
            {
                new Forms.SetAPIKeyForm(attachedOn.AddComponent<APIKeyInfoComponent>(null)).Show();
            }

            //Get item count from bank
            count += bankinfo.GetItemCountFromBank(itemID);
            //Get item count from characters
            List<Characters.Character> charList = characters.getCharactersNoUpdate();
            foreach (Characters.Character ch in charList)
            {
                if(ch.bags.Count != 0)
                    foreach(Characters.Bag bag in ch.bags)
                        if(bag != null)
                            foreach(Characters.Inventory inv in bag.inventory)
                                if(inv != null)
                                    if(inv.id == itemID)
                                        count += inv.count;
            }
            //Get item count from shared inventory slots
            count += inventory.getItemCount(itemID);
            //Get item count from material storage
            count += materials.getItemCount(itemID);
            return count;
        }
    }
}
