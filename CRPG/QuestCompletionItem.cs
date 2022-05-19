using System;
using System.Collections.Generic;
using System.Text;

namespace CRPG
{
    public class QuestCompletionItem
    {
        public Item Details;
        public int Quantity;

        public QuestCompletionItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
