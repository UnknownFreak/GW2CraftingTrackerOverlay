using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GW2APIComponent.GW2Components.V2.Account.Bank
{
    [DataContract]
    public class BankInfo
    {
        [DataMember(Name = "id")]
        public uint id;
        [DataMember(Name = "count")]
        public uint count;
        [DataMember(Name = "upgrades")]
        public List<uint> upgrades;
        [DataMember(Name = "infusions")]
        public List<uint> infusions;
        [DataMember(Name = "binding")]
        public string binding;
        [DataMember(Name = "bound_to")]
        public string boundTo;
    }
}
