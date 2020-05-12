using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class AbominationFactory : MonsterFactory
    {      
     
            // this factory produces abominations
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (playerLevel < 15 && Index.RNG(0, 100) >= 80) // if player is below lvl 15, there's only 20% chance to spawn weak abomination 
            {

                return new Abomination(playerLevel/2 + 1);
            }
            else if (playerLevel >= 15)
            {
                return new Abomination(playerLevel);
            }
            else return null; // no more abominations
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Abomination(0).GetImage();
            else return null;
        }        
    }
}
