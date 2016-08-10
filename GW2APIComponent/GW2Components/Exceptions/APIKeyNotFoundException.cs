namespace GW2APIComponent.GW2Components.Exceptions
{
    public class APIKeyNotFoundException : BaseGw2Exception
    {
        public APIKeyNotFoundException() : base("The APIKey component was not found.")
        {

        }
    }
}
