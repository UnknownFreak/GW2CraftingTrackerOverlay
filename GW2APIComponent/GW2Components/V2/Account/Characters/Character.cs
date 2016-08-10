using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GW2APIComponent.GW2Components.V2.Account.Characters
{
    [DataContract]
    public class Character
    {
        [DataMember(Name = "name" )]
        public string name;
        [DataMember(Name = "race" )]
        public string race;
        [DataMember(Name = "gender" )]
        public string gender;
        [DataMember(Name = "profession" )]
        public string profession;
        [DataMember(Name = "level" )]
        public uint level;
        [DataMember(Name = "guild" )]
        public string guildID;
        [DataMember(Name = "age" )]
        public uint age;
        [DataMember(Name = "created" )]
        public string created;
        [DataMember(Name = "deaths" )]
        public uint deaths;
        [DataMember(Name = "crafting" )]
        public List<Crafting> crafting;
        [DataMember(Name = "title" )]
        public uint title;
        [DataMember(Name = "backstory" )]
        public List<uint> backstory;
        [DataMember(Name = "specializations" )]
        public Specializations specializations;
        [DataMember(Name = "skills" )]
        public Skills skills;
        [DataMember(Name = "equipment" )]
        public List<Equipment> equipment;
        [DataMember(Name = "recipes" )]
        public List<uint> recipes;
        [DataMember(Name = "equipment_pvp" )]
        public EquipmentPvp pvpEquipment;
        [DataMember(Name = "bags" )]
        public List<Bag> bags;
    }
    [DataContract]
    public class Crafting
    {
        [DataMember(Name = "discipline" )]
        public string discipline;
        [DataMember(Name = "rating" )]
        public uint? rating;
        [DataMember(Name = "active" )]
        public bool active;
    }
    
    [DataContract]
    public class Specializations
    {
        [DataMember(Name = "pve" )]
        public List<TraitLine> pve;
        [DataMember(Name = "pvp" )]
        public List<TraitLine> pvp;
        [DataMember(Name = "wvw" )]
        public List<TraitLine> wvw;
    }
    [DataContract]
    public class TraitLine
    {
        [DataMember(Name = "id" )]
        public uint? id;
        [DataMember(Name = "traits" )]
        public List<uint?> traits;
    }
    [DataContract]
    public class Skills
    {
        [DataMember(Name = "pvp" )]
        public SkillSet pvp;
        [DataMember(Name = "pve" )]
        public SkillSet pve;
        [DataMember(Name = "wvw" )]
        public SkillSet wvw;
    }
    [DataContract]
    public class SkillSet
    {
        [DataMember(Name = "heal" )]
        public uint? heal;
        [DataMember(Name = "utilities" )]
        public List<uint?> utilities;
        [DataMember(Name = "elite" )]
        public uint? elite;
    }
    [DataContract]
    public class Equipment
    {
        [DataMember(Name = "id" )]
        public uint id;
        [DataMember(Name = "slot" )]
        public string slot;
        [DataMember(Name = "upgrades" )]
        public List<uint> upgrades;
        [DataMember(Name = "infusions" )]
        public List<uint> infusions;
        [DataMember(Name = "stats" )]
        public Stats stats;
    }
    [DataContract]
    public class Stats
    {
        [DataMember(Name = "id" )]
        public uint id;
        //[DataMember(Name = "attributes")]
        //public Dictionary<string, uint> attributes;
    }
    [DataContract]
    public class EquipmentPvp
    {
        [DataMember(Name = "amulet" )]
        public uint amulet;
        [DataMember(Name = "rune" )]
        public uint rune;
        [DataMember(Name = "sigils" )]
        public List<uint> sigils;
    }
    [DataContract]
    public class Bag
    {
        [DataMember(Name = "id" )]
        public uint id;
        [DataMember(Name = "size" )]
        public uint size;
        [DataMember(Name = "inventory" )]
        public List<Inventory> inventory;
    }
    [DataContract]
    public class Inventory
    {
        [DataMember(Name = "id" )]
        public uint id;
        [DataMember(Name = "count" )]
        public uint count;
        [DataMember(Name = "binding" )]
        public string binding;
    }
}
