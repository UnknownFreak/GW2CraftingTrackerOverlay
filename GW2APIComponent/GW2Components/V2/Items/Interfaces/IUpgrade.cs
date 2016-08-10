using System.Collections.Generic;

namespace GW2APIComponent.GW2Components.V2.Items
{
    public interface IUpgrade : IBaseItem
    {
        string getType();
        List<string> getFlags();
        List<string> getInfusionUpgradeFlags();
        string getSuffix();
        InfixUpgrade getInfixUpgrade();
        List<string> getBonuses();
    }
}
