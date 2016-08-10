using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GW2APIComponent.GW2Components.V2.Items
{
    [DataContract]
    public class Item
    {
        [DataMember(Name= "id")]
        public uint ID;
        [DataMember(Name = "chat_link")]
        public string chatLink;
        [DataMember(Name = "name")]
        public string name;
        [DataMember(Name = "icon")]
        public string icon;
        [DataMember(Name = "description")]
        public string description;
        [DataMember(Name = "type")]
        public string type;
        [DataMember(Name = "rarity")]
        public string rarity;
        [DataMember(Name = "level")]
        public uint level;
        [DataMember(Name = "vendor_value")]
        public uint vendorValue;
        [DataMember(Name = "default_skin")]
        public uint defaultSkin;
        [DataMember(Name = "flags")]
        public List<string> flags;
        [DataMember(Name = "game_types")]
        public List<string> gameTypes;
        [DataMember(Name = "restrictions")]
        public List<string> restrictions;
        [DataMember(Name = "details")]
        public Detail details;
        public T GetDetailsAsInterface<T>() where T : IBaseItem
        {
            return (T)(IBaseItem)details;
        }
    }
#pragma warning disable 0649
    [DataContract]
    public class Detail : IArmor, IBack, IBag, IConsumable, IContainer, IGathering,
        IGizmo, IMiniature, ISalvage, ITrinket, IUpgrade, IWeapon
    {
        [DataMember(Name = "type")]
        string type;
        [DataMember(Name = "weight_class")]
        string weightClass;
        [DataMember(Name = "defense")]
        uint defense;
        [DataMember(Name = "infusion_slots")]
        List<Infusion> infusionSlots;
        [DataMember(Name = "infix_upgrade")]
        InfixUpgrade infixUpgrade;
        [DataMember(Name = "suffix_item_id")]
        uint suffixItemID;
        [DataMember(Name = "secondary_suffix_item_id")]
        string secondarySuffixItemID;
        [DataMember(Name = "size")]
        uint size;
        [DataMember(Name = "no_sell_or_sort")]
        bool noSellOrSort;
        [DataMember(Name = "description")]
        string description;        
        [DataMember(Name = "duration_ms")]
        uint duration;
        [DataMember(Name = "unlock_type")]
        string unlockType;
        [DataMember(Name = "color_id")]
        uint colorID;
        [DataMember(Name = "recipe_id")]
        uint recipeID;
        [DataMember(Name = "charges")]
        uint charges;
        [DataMember(Name = "minipet_id")]
        uint minipetID;
        [DataMember(Name = "flags")]
        List<string> flags;
        [DataMember(Name = "infusion_upgrade_flags")]
        List<string> infusionUpgradeFlags;
        [DataMember(Name = "suffix")]
        string suffix;
        [DataMember(Name = "bonuses")]
        List<string> bonuses;
        [DataMember(Name = "damage_type")]
        string damageType;
        [DataMember(Name = "min_power")]
        uint minPower;
        [DataMember(Name = "max_power")]
        uint maxPower;

        #region IAarmor
        string IArmor.getType()
        {
            return type;
        }
        string IArmor.getWeightClass()
        {
            return weightClass;
        }
        uint IArmor.getDefense()
        {
            return defense;
        }
        List<Infusion> IArmor.getInfusionSlots()
        {
            return infusionSlots;
        }
        InfixUpgrade IArmor.getInfixUpgrade()
        {
            return infixUpgrade;
        }
        uint IArmor.getSuffixItemID()
        {
            return suffixItemID;
        }
        string IArmor.getSecondarySuffixItemID()
        {
            return secondarySuffixItemID;
        }
        #endregion
        #region IBack
        List<Infusion> IBack.getInfusionSlots()
        {
            return infusionSlots;
        }
        InfixUpgrade IBack.getInfixUpgrade()
        {
            return infixUpgrade;
        }
        uint IBack.getSuffixItemID()
        {
            return suffixItemID;
        }
        string IBack.getSecondarySuffixItemID()
        {
            return secondarySuffixItemID;
        }
        #endregion
        #region IBag
        uint IBag.getSize()
        {
            return size;
        }
        bool IBag.getSellOrNoSort()
        {
            return noSellOrSort;
        }
        #endregion
        #region IConsumable
        string IConsumable.getType()
        {
            return type;
        }
        string IConsumable.getDescription()
        {
            return description;
        }
        uint IConsumable.getDuration()
        {
            return duration;
        }
        string IConsumable.getUnlockType()
        {
            return unlockType;
        }
        uint IConsumable.getColorID()
        {
            return colorID;
        }
        uint IConsumable.getRecipeID()
        {
            return recipeID;
        }
        #endregion
        #region IContainer
        string IContainer.getType()
        {
            return type;
        }
        #endregion
        #region IGathering
        string IGathering.getType()
        {
            return type;
        }
        #endregion
        #region IGizmo
        string IGizmo.getType()
        {
            return type;
        }
        #endregion
        #region IMinipet
        uint IMiniature.getMinipetID()
        {
            return minipetID;
        }
        #endregion
        #region ISalvage
        string ISalvage.getType()
        {
            return type;
        }
        uint ISalvage.getCharges()
        {
            return charges;
        }
        #endregion
        #region ITrinket
        string ITrinket.getType()
        {
            return type;
        }
        List<Infusion> ITrinket.getInfusionSlots()
        {
            return infusionSlots;
        }
        InfixUpgrade ITrinket.getInfixUpgrade()
        {
            return infixUpgrade;
        }
        uint ITrinket.getSuffixItemID()
        {
            return suffixItemID;
        }
        string ITrinket.getSecondarySuffixItemID()
        {
            return secondarySuffixItemID;
        }
        #endregion
        #region IUpgrade
        string IUpgrade.getType()
        {
            return type;
        }
        List<string> IUpgrade.getFlags()
        {
            return flags;
        }
        List<string> IUpgrade.getInfusionUpgradeFlags()
        {
            return infusionUpgradeFlags;
        }
        string IUpgrade.getSuffix()
        {
            return suffix;
        }
        InfixUpgrade IUpgrade.getInfixUpgrade()
        {
            return infixUpgrade;
        }
        List<string> IUpgrade.getBonuses()
        {
            return bonuses;
        }
        #endregion
        #region IWeapon
        string IWeapon.getType()
        {
            return type;
        }
        string IWeapon.getDamageType()
        {
            return damageType;
        }
        uint IWeapon.getMinPower()
        {
            return minPower;
        }
        uint IWeapon.getMaxPower()
        {
            return maxPower;
        }
        uint IWeapon.getDefense()
        {
            return defense;
        }
        List<Infusion> IWeapon.getInfusionSlots()
        {
            return infusionSlots;
        }
        InfixUpgrade IWeapon.getInfixUpgrade()
        {
            return infixUpgrade;
        }
        uint IWeapon.getSuffixItemID()
        {
            return suffixItemID;
        }
        string IWeapon.getSecondarySuffixItemID()
        {
            return secondarySuffixItemID;
        }
        #endregion
    }
    [DataContract]
    public class Infusion
    {
        [DataMember(Name = "flags")]
        public List<string> flags;
        [DataMember(Name = "item_id")]
        public uint itemID;
    }
    [DataContract]
    public class InfixUpgrade
    {
        [DataMember(Name = "attributes")]
        public Attribute attributes;
        [DataMember(Name = "buff")]
        public Buff buff;
    }
    [DataContract]
    public class Attribute
    {
        [DataMember(Name = "modifier")]
        public uint modifier;
    }
    [DataContract]
    public class Buff
    {
        [DataMember(Name = "skill_id")]
        public uint skillID;
        [DataMember(Name = "description")]
        public string description;
    }
#pragma warning restore 0649

}
