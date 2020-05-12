using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Abomination:Monster
    {
        private int maxHealth;
        // my "monster" is a thug (maybe humans are monsters, I'm not that edgy)
        public Abomination(int abominationLevel)
        {
            Health = 100 + 2 * abominationLevel;
            maxHealth = Health;
            Strength = 20 + abominationLevel / 2;
            Armor = 5;
            Precision = 50;
            MagicPower = 30;
            Stamina = 120;
            XPValue = 50 + abominationLevel*2;
            Name = "monster0004";
            BattleGreetings = "Blrhargr!"; // Some random set of noises
        }
        public override List<StatPackage> BattleMove()
        {
            if(MagicPower >= 15)
            {
                MagicPower -= 15;
                return new List<StatPackage>() { new StatPackage("MagicPowerDmg", 20 + Precision / 10, "Abomination spits fire! (" + (20 + Precision / 10) + "magic damage)") };
            }
            else if (Stamina >= 15)
            {
                Stamina -= 15;
                // a simple bite move dealing 12 + (thug strength statistic) damage
                return new List<StatPackage>() { new StatPackage("punch", 13 + Strength, "Thug uses punch! (" + (13 + Strength) + " punch damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, "Abomination has no mana or energy left to attack") };
            }
        }
        public override void React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
            {
                Health -= pack.HealthDmg;
                Strength -= pack.StrengthDmg;
                Armor -= pack.ArmorDmg;
                Precision -= pack.PrecisionDmg;
                MagicPower -= pack.MagicPowerDmg;
            }
            if (Health < maxHealth/2)
            {
                Strength *= 2;
            }
        }
    }
}
