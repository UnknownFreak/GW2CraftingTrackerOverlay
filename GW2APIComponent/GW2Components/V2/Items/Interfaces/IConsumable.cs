namespace GW2APIComponent.GW2Components.V2.Items
{
    public interface IConsumable : IBaseItem
    {
        string getType();
        string getDescription();
        uint getDuration();
        string getUnlockType();
        uint getColorID();
        uint getRecipeID();
    }
}
