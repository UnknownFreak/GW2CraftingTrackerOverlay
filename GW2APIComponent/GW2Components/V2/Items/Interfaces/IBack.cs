using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Items
{
    public interface IBack : IBaseItem
    {
        List<Infusion> getInfusionSlots();
        InfixUpgrade getInfixUpgrade();
        uint getSuffixItemID();
        string getSecondarySuffixItemID();
    }
}
