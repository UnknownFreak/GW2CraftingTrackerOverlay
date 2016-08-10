namespace GW2APIComponent.GW2Components.Exceptions
{
    public class APIKeyInvalidException : BaseGw2Exception
    {
        public APIKeyInvalidException()
            : base("The APIKey is invalid.")
        {
        }
    }
}
