using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class Quarterstaff:Staff
    {
        public Quarterstaff() : base("item0010")
        {
            MgcMod = 15;
            ArMod = 3;
            GoldValue = 100;
            PublicName = "Quarterstaff";
        }
        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "fire")
            {
                pack.HealthDmg = 120 * pack.HealthDmg / 100;
                //Buff all fire spells by 20%.
            }
            return pack;
        }
        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "incised")
            {
                pack.HealthDmg = 90 * pack.HealthDmg / 100;
                //Buff incised attacks are reduced by 10%
            }
            return pack;
        }

    }
}
