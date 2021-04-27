using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Game
    {
        Dungeon dungeon;
        Player player;

        bool isRunning = false;

        public void Run()
        {
            isRunning = true;

            dungeon = new Dungeon();
            player = new Player { currentRoom = dungeon.startingRoom };

            while (isRunning)
            {
                Console.Clear();
                Display(player.currentRoom);
                Display("\nWhat do you do ?\n");

                var (cmd, arg) = ReadInput();
                var result = Execute(cmd, arg);

                Console.Clear();
                Display(result);
            }
        }

        (string cmd, string arg) ReadInput()
        {
            string input = Console.ReadLine();
            var command = input.Split(' ');

            if (command.Length != 2) return ("error", "error");
            else return (command[0], command[1]);
        }

        string Execute(string command, string arg)
        {
            switch (command.ToLower())
            {
                case "show": return player.Show(arg);
                case "take": return player.Take(arg);
                case "drop": return player.Drop(arg);
                case "use": return player.Use(arg);
                case "go": return player.Go(arg);
                case "quit": return Quit();
                default: return "Invalid command.";
            }
        }

        string Quit()
        {
            isRunning = false;
            return "Thank you for playing!";
        }

        void Display(object obj) => Display(obj.ToString());

        void Display(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }

            Thread.Sleep(500);
        }
    }
}
