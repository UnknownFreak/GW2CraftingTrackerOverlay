using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Items
{
    public interface IArmor : IBaseItem
    {
        string getType();
        string getWeightClass();
        uint getDefense();
        List<Infusion> getInfusionSlots();
        InfixUpgrade getInfixUpgrade();
        uint getSuffixItemID();
        string getSecondarySuffixItemID();
    }
}
