using System;
using System.Collections.Generic;
using Game.Engine.Skills.BasicWeaponMoves;
using Game.Engine.CharacterClasses;
using Game.Engine.Skills.BasicSkills;

namespace Game.Engine.Skills.SkillFactories
{
    class AdvancedWeaponMoveFactory:SkillFactory
    {
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills); // check what spells from the AdvancedWeaponMoves category are known by the player already
            if (known == null) // no AdvancedWeaponMoves known - we will return one of them
            {
                Daze d1 = new Daze();
                Decapitate d2 = new Decapitate();
                DestroyArmor d3 = new DestroyArmor();
                // only include elligible spells
                List<Skill> tmp = new List<Skill>();
                if (d1.MinimumLevel <= player.Level) tmp.Add(d1); // check level requirements
                if (d2.MinimumLevel <= player.Level) tmp.Add(d2);
                if (d3.MinimumLevel <= player.Level) tmp.Add(d3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)]; // use Index.RNG for safe random numbers
            }
            else if (known.decoratedSkill == null) // a BasicSpell has been already learned, use decorator to create a combo
            {
                DazeDecorator dd1 = new DazeDecorator(known);
                DecapitateDecorator dd2 = new DecapitateDecorator(known);
                DestroyArmorDecorator dd3 = new DestroyArmorDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (dd1.MinimumLevel <= player.Level) tmp.Add(dd1); // check level requirements
                if (dd2.MinimumLevel <= player.Level) tmp.Add(dd3);
                if (dd3.MinimumLevel <= player.Level) tmp.Add(dd3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; // a combo of BasicSpells has been already learned - this factory doesn't offer double combos so we stop here
        }
        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is Daze || skill is Decapitate || skill is DestroyArmor || skill is DazeDecorator || skill is DecapitateDecorator || skill is DestroyArmorDecorator) return skill;
            }
            return null;
        }
    }
    
}
