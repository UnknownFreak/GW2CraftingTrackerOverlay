namespace GW2APIComponent.GW2Components.V2.Items
{
    public interface IBag : IBaseItem
    {
        uint getSize();
        bool getSellOrNoSort();
    }
}
