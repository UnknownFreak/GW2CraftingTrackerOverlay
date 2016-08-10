using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Items
{
    public interface IWeapon : IBaseItem
    {
        string getType();
        string getDamageType();
        uint getMinPower();
        uint getMaxPower();
        uint getDefense();
        List<Infusion> getInfusionSlots();
        InfixUpgrade getInfixUpgrade();
        uint getSuffixItemID();
        string getSecondarySuffixItemID();
    }
}
