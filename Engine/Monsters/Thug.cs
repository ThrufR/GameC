using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Thug:Monster
    {
        
        
            // my "monster" is a thug (maybe humans are monsters, I'm not that edgy)
            public Thug(int thugLevel)
            {
                Health = 50 + 3 * thugLevel;
                Strength = 14 + thugLevel/2;
                Armor = 5;
                Precision = 50;
                MagicPower = 0;
                Stamina = 80;
                XPValue = 35 + thugLevel;
                Name = "monster0003";
                BattleGreetings = "You'll regret that you were born!"; // thug is very violent and crude
            }
            public override List<StatPackage> BattleMove()
            {
                if (Stamina >= 10)
                {
                    Stamina -= 10;
                    // a simple punch move dealing 12 + (thug strength statistic) damage
                    return new List<StatPackage>() { new StatPackage("punch", 12 + Strength, "Thug uses punch! (" + (12 + Strength) + " punch damage)") };
                }
                else
                {
                    return new List<StatPackage>() { new StatPackage("none", 0, "Thug has no energy to attack anymore!") };
                }
            }
            public override void React(List<StatPackage> packs) // receive the result of your opponent's action
            {
                if (Index.RNG(0, 100) >= 10) // Give thug 10% chance to dodge player's attack
                {
                    foreach (StatPackage pack in packs)
                    {
                        Health -= pack.HealthDmg;
                        Strength -= pack.StrengthDmg;
                        Armor -= pack.ArmorDmg;
                        Precision -= pack.PrecisionDmg;
                        MagicPower -= pack.MagicPowerDmg;
                    }
                }
            }

    }
}
