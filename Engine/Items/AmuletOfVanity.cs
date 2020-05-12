using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class AmuletOfButcher : Item
    {
        public AmuletOfButcher() : base("item0011")
        {
            PrMod = 5;
            GoldValue = 1000;
            PublicName = "Amulet of Butcher";
           
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "incised")
            {
                pack.HealthDmg *= 2;
            }
            return pack;
        }

    }
}
