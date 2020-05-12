using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class Decapitate : Skill
    {
        public Decapitate() : base("Decapitate", 40, 5)
        {
            PublicName = "Decapitate: A 15% chance to equal your 3* Strength + 10 damage. (incised)";
            RequiredItem = "Axe";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("incised");
            Random rnd = new Random();
            if (rnd.Next(0, 100) >= 80)
            {
                response.HealthDmg = (int)(player.Strength*3 + 10);
                response.CustomText = "You swing your axe for enemy's head! (" + (int)(3 * player.Strength + 10) + " incised damage)";
            }
            else
            {
                response.HealthDmg = 0;
                response.CustomText = "You should've gone for the head!";
            }
            return new List<StatPackage>() { response };
        }

    }
}
