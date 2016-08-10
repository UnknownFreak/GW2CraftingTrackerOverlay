namespace GW2APIComponent.GW2Components.Exceptions
{
    public class APIKeyLacksPermissionException : BaseGw2Exception
    {
        public string MissingPermission;
        public APIKeyLacksPermissionException()
            : base("API key does not have permission")
        {

        }
        public APIKeyLacksPermissionException(string MissingPermission)
            : base("API key does not have permission\n")
        {
            this.MissingPermission = MissingPermission;
        }
    }
}
