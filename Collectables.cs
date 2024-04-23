using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemp
{
    internal class Collectables
    {
        internal static bool NotShown = true;
        public static string[] items = { "cheat", "doubler", "replay", "shield"};
        public static string[] amount = { "3", "Active", "5", "Inactive"};
        internal static bool[] used = { false, false, false, false };
        public static string[] description = { 
                "Shows the symbols and allows you to copy symbol for symbol, half damage","" +
                "doubles the damage you do, doesn’t reduce damage taken as difference though","" +
                "shows the symbols again","" +
                "gives you a shield to cover the rest of the round"
        };
        public static string[] chosen = new string[2];
        public static void shop()
        {
            int temp;
            Random random = new Random();
            do
            {
                temp = random.Next(items.Length);
                chosen[0] = items[temp];
            } while (used[temp]);
            do
            {
                temp = random.Next(items.Length);
                chosen[1] = items[temp];
            } while (chosen[1] == chosen[0] || used[temp]);
            Console.WriteLine($"({amount[Array.IndexOf(items, chosen[0])]}) {chosen[0]} - {description[Array.IndexOf(items, chosen[0])]}");
            Console.WriteLine($"({amount[Array.IndexOf(items, chosen[1])]}) {chosen[1]} - {description[Array.IndexOf(items, chosen[1])]}");
            Console.WriteLine("Please choose one");
            while (true)
            {
                string choice = Console.ReadLine();
                if (chosen.Any(x => x == choice.ToLower()))
                {
                    used[Array.IndexOf(items, choice)] = true;
                    Console.WriteLine("Item added " + choice);
                    if(NotShown)
                    {
                        Console.WriteLine("You may now type \"i\" to access your inventory during battles");
                        NotShown = false;
                    }
                    if(choice == "doubler")
                    {
                        Console.WriteLine("Your damage is now doubled");
                    }
                    Player.ItemsAdd(choice);
                    break;
                }
                else { Console.WriteLine("Invalid choice, try again"); }
            }
            Console.WriteLine("[Press Enter]");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
