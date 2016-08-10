namespace GW2APIComponent.GW2Components.Exceptions
{
    public class BaseGw2Exception : System.Exception
    {
        public BaseGw2Exception() : base()
        {

        }

        public BaseGw2Exception(string message) : base(message)
        {
        }
    }
}
