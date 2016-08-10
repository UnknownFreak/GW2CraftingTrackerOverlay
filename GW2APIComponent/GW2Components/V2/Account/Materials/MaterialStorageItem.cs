using System.Runtime.Serialization;

namespace GW2APIComponent.GW2Components.V2.Account.Materials
{
    [DataContract]
    public class MaterialStorageItem
    {
        [DataMember(Name = "id")]
        public uint id;
        [DataMember(Name = "category")]
        public uint category;
        [DataMember(Name = "count")]
        public uint count;
    }
}
