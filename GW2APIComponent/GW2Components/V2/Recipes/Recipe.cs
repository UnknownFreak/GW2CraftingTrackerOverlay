using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GW2APIComponent.GW2Components.V2.Recipes
{
    [DataContract]
    public class Recipe
    {
        [DataMember(Name = "id")]
        public int ID;
        [DataMember(Name = "type")]
        public string type;
        [DataMember(Name = "output_item_id")]
        public uint outputItemID;
        [DataMember(Name = "output_item_count")]
        public double outputItemCount;
        [DataMember(Name = "time_to_craft")]
        public uint timeToCraft;
        [DataMember(Name = "disciplines")]
        public List<string> disciplines;
        [DataMember(Name = "min_rating")]
        public uint minRating;
        [DataMember(Name = "flags")]
        public List<string> flags;
        [DataMember(Name = "ingredients")]
        public List<Ingredient> ingredients;
        [DataMember(Name = "guild_ingredients ")]
        public List<GuildIngredient> guildIngredients;
        [DataMember(Name = "output_upgrade_id")]
        public uint outputUpgradeID;
        [DataMember(Name = "chat_link")]
        public string chatLink;
        [DataMember(Name = "achievement_id")]
        public uint achievementID;
    }
    [DataContract]
    public class Ingredient
    {
        [DataMember(Name = "item_id")]
        public int ID;
        [DataMember(Name = "count")]
        public uint count;
    }
    [DataContract]
    public class GuildIngredient
    {
        [DataMember(Name = "upgrade_id")]
        public uint ID;
        [DataMember(Name = "count")]
        public uint count;
    }
}
