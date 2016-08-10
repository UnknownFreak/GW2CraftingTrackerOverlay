using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Recipes
{
    public class RecipeRequestComponent : BaseComponents.IBaseComponent<RecipeRequestComponent>
    {
        private string MURL = "http://gw2profits.com/json/v3?";
        private List<string> filters = new List<string>();
        public RecipeRequestComponent()
            : base("RecipeListComponent", BaseComponents.eComponentTypeID.RecipeRequestComponent)
        {
        URL = "https://api.guildwars2.com/v2/recipes";
        }
        public List<uint> requestRecipe(uint itemID, bool isInput)
        {
            List<uint> tmp = requestJSON<List<uint>>(URL+"/search?"+(isInput ? "input=": "output=")+itemID);
            return tmp;
        }
        public List<Recipe> requestMysticForgeRecipe(uint outputItem)
        {
            return requestJSON<List<Recipe>>(MURL + "disciplines=Mystic%20Forge,MerchantANDoutput_ids=" + outputItem);
        }
        public Recipe requestRecipeInfo(uint recipeID)
        {
            return requestJSON<Recipe>(URL + "/" + recipeID);
        }
    }
}
