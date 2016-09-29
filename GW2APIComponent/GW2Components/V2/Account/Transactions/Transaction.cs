using System.Runtime.Serialization;

namespace GW2APIComponent.GW2Components.V2.Account.Transactions
{
    [DataContract]
    public class Transaction
    {
        [DataMember(Name = "id")]
        public uint ID;
        [DataMember(Name = "item_id")]
        public uint itemID;
        [DataMember(Name = "price")]
        public uint price;
        [DataMember(Name = "quantity")]
        public uint quantity;
        [DataMember(Name = "created")]
        public string created;
        [DataMember(Name = "purchased")]
        public string purchased;
    }
}
