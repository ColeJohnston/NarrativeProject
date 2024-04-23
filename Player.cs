using ProjectTemp.Enemies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemp
{
    internal class Player
    {
        public static bool created = false;
        public static bool difference;
        static public int hp;
        static public int shield = 0;
        static public List<string> Parts = new List<string>();
        static public List<string> Items = new List<string>();
        public static bool doubler = false;
        internal void CharacterSelect()
        {

            Console.WriteLine("\n\nMake your choice");
            while (true)
            {
            Console.WriteLine("[Difference] or [Trade-Off]");
            string selection = Console.ReadLine().ToLower();
            Console.Clear();
                if (selection == "difference")
                {
                    Console.WriteLine("You selected Difference, Stay smart");
                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    Console.Clear();
                    difference = true;
                    created = true;
                    break;
                }
                else if (selection == "trade-off")
                {
                    Console.WriteLine("You selected Trade-Off, Stay strong");
                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    Console.Clear();
                    difference = false;
                    created = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option, try again");
                }
            }
            
        }
        internal static void RemoveLimbs()
        {
            int i = Parts.Count;
            if(i == 5)
            {
                if (Parts[0] == "arms1")
                {
                    Console.WriteLine("You inserted the 5 pairs of arms into the 5 seperate holes." +
                        "\n you hear clicking but nothing else happens.");
                }
                else if (Parts[0] == "legs1")
                {
                    Console.WriteLine("You inserted the 5 pairs of legs into the leg holes." +
                        "\n there is more clicking but nothing else.");
                }
                else
                {
                    Console.WriteLine("You inserted the final set of parts into the holes. Suddenly a door begins to open.");
                }
            }
            else if(i == 10)
            {
                if (Parts[0] == "arms1")
                {
                    Console.WriteLine("You inserted the arms and legs into their respective holes." +
                        "\n You hear lots of clicking but nothing seems to budge.");
                }
                else
                {
                    Console.WriteLine("You inserted the final set of part into their respective holes. Suddenly a door begins to open.");
                }
            }
            else
            {
                Console.WriteLine("You inserted each complete monster into a slot in the wall. Suddenly a door begins to open.");
            }
            Parts.Clear();
        }
        internal void SetHp()
        {
            if (difference)
            {
                hp = 20;
            }
            else
            {
                hp = 100;
            }
        }
        internal static void showitems()
        {
            Console.Clear();
            Console.WriteLine("Inventory: ");
            Console.WriteLine("---------");
            foreach(string item in Items)
            {
                Console.WriteLine($"({Collectables.amount[Array.IndexOf(Collectables.items, item)]}) {item}");

            }
            UseItem();
        }
        internal static void ShowInventory()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Consumables" +
                            "\n-----------");
            Console.ResetColor();
            foreach (var item in Items)
            {
                Console.WriteLine(item + ", ");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nParts:" +
                "\n-----");
            Console.ResetColor();
            foreach (var item in Parts) { Console.WriteLine(item + ", ");}
        }
        internal static void UseItem()
        {
            string choice;
            bool active = false;
            Console.WriteLine("To use an item, type the items name" +
                "\nTo exit, type exit");
            choice = Console.ReadLine();
            if(choice.ToLower() == "exit")
            {
                Console.Clear();
            }
            else if(Items.Any(x => x == choice))
            {
                switch (choice)
                {
                    case "cheat":
                        Collectables.amount[0] = (int.Parse(Collectables.amount[0]) - 1).ToString();
                        if (Collectables.amount[0] == "0")
                        {
                            Items.Remove("cheat");
                        }
                        Console.WriteLine("Word now displayed, press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(Enemy.word);
                        break;
                    case "replay":
                        Collectables.amount[2] = (int.Parse(Collectables.amount[2]) - 1).ToString();
                        if (Collectables.amount[2] == "0")
                        {
                            Items.Remove("replay");
                        }
                        Console.WriteLine("Press enter to replay the word for 10 more seconds");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(Enemy.word);
                        Thread.Sleep(10000);
                        Console.Clear();
                        break;
                    case "shield":
                        Collectables.amount[3] = "Active";
                        if (!active)
                        {
                            active = true;
                            Player.shield = 20;
                            Console.Write("Shield is now active. Press Enter to continue your round");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                }
            }
        }
        internal static void PartAdd(string item)
        {
            Parts.Add(item);
        }
        internal static void ItemsAdd(string item)
        {
            Items.Add(item);
            if(item == "doubler")
            {
                doubler = true;
            }
        }
        internal static void updatehp(int damage)
        {
            if(shield >= -damage)
            {
                shield += damage;
            }
            else if(shield < -damage)
            {
                damage += shield;
                hp += damage;
            }
            if(hp <= 0)
            {
                Game.GameOver();
            }
        }
        internal static void nap()
        {
            Enemy.nap += 1;
            if (difference)
            {
                hp += (20 - hp) / 2;
            }
            else { hp += (100 - hp) / 2; }
        }
    }
}
