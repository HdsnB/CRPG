using System;
using System.Collections.Generic;
using System.Text;

namespace CRPG
{
    public class HealingPotion: Item
    {
        public int AmountToHeal;

        public HealingPotion(int id, string name, string namePlural, int amountToHeal) : base(id, name, namePlural)
        {
            AmountToHeal = amountToHeal;

        }

    }
}
