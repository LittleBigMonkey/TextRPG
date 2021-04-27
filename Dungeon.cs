using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Dungeon
    {
        public Room startingRoom;
        public Room endingRoom;

        public Dungeon()
        {
            Item staff = new Item { name = "Staff", rarity = Rarity.Legendary, effect = "You cast a powerful magic attack!!!" };
            Item potion = new Item { name = "Potion", rarity = Rarity.Common, effect = "You heal yourself!" };
            Item coin = new Item { name = "Coin", rarity = Rarity.Uncommon, effect = "There is nothing to buy here." };
            Item sword = new Item { name = "Sword", rarity = Rarity.Rare, effect = "You slash in the air.." };

            Monster dragon = new Monster { name = "large fire breathing dragon" };

            Room room0 = new Room { name = "Dungeon", info = "You see a large door." };
            Room room1 = new Room { name = "First room", info = "It's very dark here!", items = { sword, potion } };
            Room room2 = new Room { name = "Second room", info = "This room is full of magic.", items = { staff, coin } };
            Room room3 = new Room { name = "Third room", info = "There are squeletons of adventurers in the corner.", items = { coin, coin, potion, potion } };
            Room room4 = new Room { name = "Boss room", info = "The room is very large.", monster = dragon };

            room0.exits = new Dictionary<Cardinal, Room> { { Cardinal.North, room1 } };
            room1.exits = new Dictionary<Cardinal, Room> { { Cardinal.South, room0 }, { Cardinal.West, room2 }, { Cardinal.East, room3 } };
            room2.exits = new Dictionary<Cardinal, Room> { { Cardinal.East, room1 } };
            room3.exits = new Dictionary<Cardinal, Room> { { Cardinal.West, room1 }, { Cardinal.North, room4 } };
            room4.exits = new Dictionary<Cardinal, Room> { { Cardinal.South, room3 } };

            startingRoom = room0;
            endingRoom = room4;
        }
    }
}
