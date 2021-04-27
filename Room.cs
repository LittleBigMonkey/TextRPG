using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Room
    {
        public string name;
        public string info;

        public Dictionary<Cardinal, Room> exits = new Dictionary<Cardinal, Room>();
        public List<Item> items = new List<Item>();
        public Monster monster;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"You enter the {name}.");
            sb.AppendLine(info);
            sb.AppendLine();
            sb.Append(monster != null ? $"There is a {monster} in the center of the room..\n\n" : "");
            sb.AppendLine($"There is an exit on : { string.Join(", ", exits.Keys) }");
            sb.AppendLine(items.Count > 0 ? $"You see some items : \n{ string.Join("\n", items) }" : "You don't see any interesting item.");

            return sb.ToString();
        }
    }

    public enum Cardinal
    {
        North,
        South,
        East,
        West
    }
}
