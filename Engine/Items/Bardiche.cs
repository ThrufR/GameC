using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    [Serializable]
    class Bardiche : Axe
    {
        public Bardiche() : base("item0009")
        {
            StrMod = 15;
            ArMod = 3;
            GoldValue = 100;
            PublicName = "Bardiche";
        }
        public override void ApplyBuffs(Engine.CharacterClasses.Player currentPlayer, List<string> otherItems)
        {
            if (currentPlayer.Strength >= 25)
            {
                currentPlayer.ArmorBuff += ArMod + (currentPlayer.Strength - 25) / 2;
                //If player is tough enough, he can use large bardiche to defend himself.
            }
        }
    }
}
