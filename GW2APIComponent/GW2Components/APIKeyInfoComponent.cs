using GW2APIComponent.BaseComponents;
namespace GW2APIComponent.GW2Components
{
    public class APIKeyInfoComponent :IBaseComponent<APIKeyInfoComponent>
    {
        private string APIKey;
        /// <summary>
        /// Instanciates the component with default values.
        /// </summary>
        public APIKeyInfoComponent() : base("APIKeyInfoComponent",eComponentTypeID.APIKeyInfoComponent)
        {

        }
        /// <summary>
        /// Instanciates the component with desired key.
        /// </summary>
        /// <param name="APIKey">The initial value of the key.</param>
        public APIKeyInfoComponent(string APIKey)
            : base("APIKeyInfoComponent", eComponentTypeID.APIKeyInfoComponent)
        {
            setAPIKey(APIKey);
        }
        /// <summary>
        /// Get a value indicating wether the api key is valid for the authenticated endpoint.
        /// </summary>
        /// <returns>True if the key is valid, false otherwise.</returns>
        public bool isValid()
        {
            Exceptions.PageError valid = new Exceptions.PageError();
            try
            {
                valid = requestJSON<Exceptions.PageError>("https://api.guildwars2.com/v2/account?access_token=" + APIKey);
            }
            catch (System.Net.WebException)
            {
                return false;
            }
            if(valid.text == null)
                return true;
            return false;
        }
        /// <summary>
        /// sets the api key with string name
        /// </summary>
        /// <param name="APIKey">The key string to be set</param>
        public void setAPIKey(string APIKey)
        {
            this.APIKey = APIKey;
        }
        /// <summary>
        /// Gets the key string.
        /// </summary>
        /// <returns>API key string.</returns>
        public string getAPIKey()
        {
            return APIKey;
        }
    }
}
