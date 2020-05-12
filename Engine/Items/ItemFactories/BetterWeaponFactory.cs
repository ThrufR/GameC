using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class BetterWeaponFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> betterWeapon = new List<Item>()
            {
                new Bardiche(),
                new Quarterstaff(),
        
            };
            return betterWeapon[Index.RNG(0, betterWeapon.Count)];
        }
        public Item CreateNonMagicItem()
        {
            
            List<Item> betterWeapon = new List<Item>()
            {
                new Bardiche(),
                new Quarterstaff(),
            };
            return betterWeapon[Index.RNG(0, betterWeapon.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
