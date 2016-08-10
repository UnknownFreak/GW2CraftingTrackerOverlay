using GW2APIComponent.BaseComponents;
using System.Collections.Generic;

namespace GW2APIComponent.GW2Components
{
    public class APIKeyPermissionsComponent :  IBaseComponent<APIKeyPermissionsComponent>
    {
        KeyPermissions permissions;
        public APIKeyPermissionsComponent() : base("APIKeyPermissionsComponent",eComponentTypeID.APIKeyPermissionsComponent)
        {
        URL = "https://api.guildwars2.com/v2/tokeninfo?access_token=";
        }
        ///<summary>
        ///Gets the permissions for the desired api key.
        ///</summary>
        ///<param name="apikey">The key to check</param>
        ///<returns>List of strings that contains all permissions for that key</returns>
        public List<string> getPermissions(string apikey)
        {
            if(permissions != null)
                return permissions.permissions;
            else
                permissions = requestJSON<KeyPermissions>(URL+apikey);
            return permissions.permissions;
        }
        ///<summary>
        ///Gets the permissions for the attached api key.
        ///</summary>
        ///<exception cref="Exceptions.APIKeyNotFoundException">Thrown if the current object does not contain the APIKeyInfoComponent.</exception>
        ///<returns>List of strings that contains all permissions for that key</returns>
        public List<string> getPermissions()
        {
            if (GetComponent<APIKeyInfoComponent>() == null)
                throw new Exceptions.APIKeyNotFoundException();
            if (permissions != null)
                return permissions.permissions;
            else
                permissions = requestJSON<KeyPermissions>(URL + GetComponent<APIKeyInfoComponent>().getAPIKey());
            return permissions.permissions;
        }
        /// <summary>
        /// Checks if the desired permission exists.
        /// </summary>
        /// <param name="permissison">The permission to check for.</param>
        /// <returns>True if the permission exists, false otherwise.</returns>
        public bool hasRequiredPermission(string permissison)
        {
            if (permissions.permissions.Contains(permissison))
                    return true;
            return false;
        }
        /// <summary>
        /// Updates the component information.
        /// </summary>
        public override void update()
        {
            //to force update
            permissions = null;
            getPermissions();
        }
    }
}
