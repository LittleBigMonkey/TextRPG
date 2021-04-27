using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Player
    {
        public string name = string.Empty;
        public Dictionary<Item, int> inventory = new Dictionary<Item, int>();

        public Room currentRoom;

        public string Show(string arg)
        {
            return "You search your inventory.\n" +
                (inventory.Count > 0 ?
                string.Join("\n", inventory.Select(t => t.Key + " x " + t.Value)) :
                "There is nothing in your inventory.");
        }

        public string Take(string name)
        {
            var item = currentRoom.items.FirstOrDefault(Item => Item.name.ToLower() == name.ToLower());

            if (item is null) return string.Format("There is no {0} in this room.", name);

            currentRoom.items.Remove(item);

            if (inventory.ContainsKey(item)) inventory[item]++;
            else inventory.Add(item, 1);

            return string.Format("You put the {0} in your inventory!", item);
        }

        public string Drop(string name)
        {
            var item = inventory.Keys.FirstOrDefault(Item => Item.name.ToLower() == name.ToLower());

            if (item is null) return string.Format("There is no {0} in your inventory.", name);

            if (inventory[item] > 1) inventory[item]--;
            else inventory.Remove(item);

            currentRoom.items.Add(item);

            return string.Format("You drop the {0} on the floor!", item);
        }

        public string Use(string name)
        {
            var item = inventory.Keys.FirstOrDefault(Item => Item.name.ToLower() == name.ToLower());

            if (item is null) return string.Format("There is no {0} in your inventory.", name);

            var result = string.Format("You try to use the {0} !\n{1}", item, item.effect);

            if (item.rarity == Rarity.Legendary && currentRoom.monster != null)
            {
                result += $"\n\nYou destroy the {currentRoom.monster} with an omniscient power!";
                result += GetExplosion();
                currentRoom.monster = null;
            }

            return result;
        }

        public string Go(string arg)
        {
            if (Enum.TryParse(arg, true, out Cardinal cardinal) && currentRoom.exits.TryGetValue(cardinal, out Room room))
            {
                currentRoom = room;
                return string.Format("You take the {0} exit.", cardinal);
            }

            return string.Format("There is no {0} exit.", arg);
        }

        public string GetExplosion()
        {
            return
            "\n\n" +
            "\n\t                    __,-~~/ ~    `---." +
            "\n\t                 _ / _,---(      ,    )" +
            "\n\t               __ /        <    /   )  \\___" +
            "\n\t- ------===;;;'====------------------===;;;===----- -  -" +
            "\n\t                \\/  ~\"~\"~\"~\"~\"~\\~\"~)~\" /" +
            "\n\t                 (_(   \\  (     >    \\)" +
            "\n\t                  \\_(_ <         >_>'" +
            "\n\t                      ~ `-i' ::>|--\"" +
            "\n\n" +
            "\n\n" +
            "\n\n";
        }

    }
}
