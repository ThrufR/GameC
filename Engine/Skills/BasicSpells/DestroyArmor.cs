using System;
using System.Collections.Generic;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.BasicSkills
{
    [Serializable]
    class DestroyArmor:Skill
    {
        public DestroyArmor() : base("DestroyArmor", 20, 5)
        {
            PublicName = "Destroy: Reduce enemy armor by 3 + Strength*2. [stab]";
            RequiredItem = "Axe";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("stab");

            response.ArmorDmg = 3 + player.Strength;
            response.CustomText = "You destroy part of enemy armor! (" + (int)(0.5 * player.MagicPower) + " armor damage)";
            return new List<StatPackage>() { response };
        }
    }
}
