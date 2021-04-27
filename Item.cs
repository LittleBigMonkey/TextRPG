using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Item
    {
        public string name;
        public Rarity rarity;
        public string effect;

        public override string ToString() => rarity + " " + name;
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary
    }
}
