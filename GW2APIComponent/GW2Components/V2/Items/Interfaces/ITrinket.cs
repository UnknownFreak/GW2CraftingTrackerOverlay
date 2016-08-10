using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Items
{
    public interface ITrinket : IBaseItem
    {
        string getType();
        List<Infusion> getInfusionSlots();
        InfixUpgrade getInfixUpgrade();
        uint getSuffixItemID();
        string getSecondarySuffixItemID();
    }
}
