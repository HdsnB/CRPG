using System;
using System.Collections.Generic;
using System.Text;

namespace CRPG
{
    public class Item
    {
        public int ID;
        public string Name;
        public string NamePlural;

//Constructor
        public Item(int iD, string name, string namePlural)
        {
            ID = iD;
            Name = name;
            NamePlural = namePlural;
        }

        public Item() { }
    }
}
