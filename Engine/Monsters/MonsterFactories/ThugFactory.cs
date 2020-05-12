using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{

    [Serializable]
    class ThugFactory : MonsterFactory
    {
        // this factory produces thugs 

        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (playerLevel >= 2) // if player is above level two, create a Thug
            {
                return new Thug(playerLevel);
            }
            else return null; // no more thugs
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Thug(0).GetImage();
            else return null;
        }
    }
}
