using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class AmuletFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> amulets = new List<Item>()
            {
                new AmuletOfButcher(),
            };
            return amulets[Index.RNG(0, amulets.Count)];
        }
        public Item CreateNonMagicItem()
        {
            return null;
        }
        public Item CreateNonWeaponItem()
        {
            List<Item> amulets = new List<Item>()
            {
                new AmuletOfButcher(),
            };
            return amulets[Index.RNG(0, amulets.Count)];
        }
    }
}
