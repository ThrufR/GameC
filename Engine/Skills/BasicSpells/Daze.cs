using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class Daze:Skill
    {
        public Daze() : base("Daze", 25, 5)
        {
            PublicName = "Daze: 50% chance to reduce enemy strength by 8 [blunt]";
            RequiredItem = "Staff";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("blunt");
            Random rnd = new Random();
            if (rnd.Next(0, 100) >= 50)
            {
                response.StrengthDmg = 8;
                response.CustomText = "You daze your opponent! (" + 8 + " strength damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You miss!";
            }
            return new List<StatPackage>() { response };
        }
    }
}
