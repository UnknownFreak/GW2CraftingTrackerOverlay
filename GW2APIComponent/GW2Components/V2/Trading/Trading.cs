using System.Runtime.Serialization;

namespace GW2APIComponent.GW2Components.V2.Trading
{
    [DataContract]
    public class ItemTradePrice
    {
        [DataMember(Name = "id")]
        public uint ID;
        [DataMember(Name = "whitelisted")]
        public bool whitelisted;
        [DataMember(Name = "buys")]
        public BuySell buys;
        [DataMember(Name = "sells")]
        public BuySell sells;
    }

    [DataContract]
    public class BuySell
    {
        [DataMember(Name = "unit_price")]
        public uint unitPrice;
        [DataMember(Name = "quantity")]
        public uint quantity;
    }
}
