using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Account.Characters
{
    class CharacterRequestComponent: BaseComponents.IBaseComponent<CharacterRequestComponent>
    {
        private List<Character> characters = new List<Character>();
        public CharacterRequestComponent()
            : base("CharacterRequestComponent", BaseComponents.eComponentTypeID.CharacterRequestComponent)
        {
        URL = "https://api.guildwars2.com/v2/characters";
        }

        public Character requestCharacter(string characterName)
        {
            int chIndex;
            if(!characters.Exists( i => i.name == characterName))
            {  
                characters.Add(requestJSON<Character>(URL+"/"+characterName+"?access_token="+GetComponent<APIKeyInfoComponent>().getAPIKey()));
                chIndex = characters.Count-1;
            }
            else
            {
                chIndex = characters.FindIndex(i => i.name == characterName);
                characters[chIndex] = requestJSON<Character>(URL+"/"+characterName+"?access_token="+GetComponent<APIKeyInfoComponent>().getAPIKey());
            }
            return characters[chIndex];
        }
        
        /// <summary>
        /// Get the characters using the attached APIKeyInfoComponent
        /// This function will update the character list before returning.
        /// </summary>
        /// <exception cref="Exceptions.APIKeyNotFoundException"></exception>
        /// <exception cref="Exceptions.APIKeyInvalidException"></exception>
        /// <exception cref="Exceptions.APIKeyPermissionsNotFoundException"></exception>
        /// <exception cref="Exceptions.APIKeyLacksPermissionException"></exception>
        /// <returns>List of all characters for the account.</returns>
        public List<Character> getCharacters()
        {
            APIKeyInfoComponent info = GetComponent<APIKeyInfoComponent>();
            APIKeyPermissionsComponent permissions = GetComponent<APIKeyPermissionsComponent>();
            if (info == null)
                throw new Exceptions.APIKeyNotFoundException();
            if (!info.isValid())
                throw new Exceptions.APIKeyInvalidException();
            if (permissions == null)
                throw new Exceptions.APIKeyPermissionsNotFoundException();
            if (!permissions.hasRequiredPermission("characters"))
                throw new Exceptions.APIKeyLacksPermissionException("characters");
            List<string> chars = requestJSON<List<string>>(URL + "?access_token=" + GetComponent<APIKeyInfoComponent>().getAPIKey());
            foreach (string c in chars)
            {
                requestCharacter(c);
            }
            return characters;
        }
        /// <summary>
        /// Gets the characters without updating the list.
        /// </summary>
        /// <returns>List of all characters for the account.</returns>
        public List<Character> getCharactersNoUpdate()
        {
            return characters;
        }
        /// <summary>
        /// Updates the component.
        /// </summary>
        /// <exception cref="Exceptions.BaseGW2Exception">Throws if the update fails.</exception>
        public override void update()
        {
            try
            {
                getCharacters();
            }
            catch
            {
                throw;
            }
        }
    }
}
