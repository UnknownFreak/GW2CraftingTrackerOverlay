using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GW2APIComponent.GW2Components
{
    [DataContract]
    public class KeyPermissions
    {
        [DataMember(Name = "id")]
        public string ID;
        [DataMember(Name = "name")]
        public string name;
        [DataMember(Name = "permissions")]
        public List<string> permissions = new List<string>();
    }
}
