using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemp.Rooms
{
    internal abstract class Room
    {
        internal abstract void introduction(bool[] beatR, bool[] beatL);
        internal static void complete(bool[] beatR, int level, int round)
        {
            string[] parts = { "arms", "legs", "head+torso" };
            if(level != 5)
            {
                Console.WriteLine($"\nCongrats on beating beast {level}, it only gets harder from here." +
    "\nWould you like to [Continue] to the next room" +
    "\n or stop to [Admire] the room some more");
            }
            else
            {
                Console.WriteLine("Now that the boss is dead, You can saftely nap.");
                Console.WriteLine("Napping restores 50% of your missing hp, but gives you 25% less reading time for future words");
                Console.WriteLine("Would you like to nap?");
                Console.WriteLine("[Y] or [N]");
                string temp;
                temp = Console.ReadLine().ToUpper();
                if(temp == "Y")
                {
                    Player.nap();
                    Console.WriteLine("NEW HP: " + Player.hp);
                }
                Console.WriteLine($"\nWow!! you beat boss {round}/3, Congrats. Now you can choose One item from the shop");
                Collectables.shop();
            }
            string choice = Console.ReadLine();
            if (!beatR[0])
            {
                switch (choice)
                {
                    case "Continue":
                        Console.WriteLine("Wait, before you go, dont forget to [Collect] the arms");
                        Console.ReadLine();
                        break;
                    case "Admire":
                        Console.WriteLine("The walls haven't changed. Still full of letters. Would you like to [Sit] for a moment and look for words in the walls?");
                        choice = Console.ReadLine();
                        if (choice == "Sit")
                        {
                            //start 15 second timer
                            Console.WriteLine("YOU FOUND SOMETHING!!!" +
                                "\nPress enter to read it");
                            Console.ReadLine();
                            switch (level)
                            {
                                case 1:
                                    Console.WriteLine("The word reads \"gullible\"");
                                    break;
                                case 2:
                                    Console.WriteLine("The word reads \"GuLlIbLe\"");
                                    break;
                                case 3:
                                    Console.WriteLine("The word reads \"Gu1LibL3\"");
                                    break;
                                case 4:
                                    Console.WriteLine("The word reads \"gullible\"");
                                    Console.WriteLine("Weird... this beast never used letters before now");
                                    break;
                                case 5:
                                    Console.WriteLine("The word reads \"Gu1L!bL3\"");
                                    break;
                            }
                            Console.WriteLine("You feel like a fool, more than ever before");
                            Console.WriteLine("Before you leave, don't forget to [Collect] the beasts arms");
                            Console.ReadLine();
                        }
                        break;
                }
            }
            else if (!beatR[1])
            {
                switch (choice)
                {
                    case "Continue":
                        Console.WriteLine("Wait, before you go, dont forget to [Collect] the legs");
                        Console.ReadLine();
                        break;
                    case "Admire":
                        Console.WriteLine("The walls haven't changed. Still full of letters. Don't waste anymore time here");
                        Console.WriteLine("Before you leave, don't forget to [Collect] the beasts legs");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                switch (choice)
                {
                    case "Continue":
                        Console.WriteLine("You've been through this... you need to [Collect] the torso and head");
                        Console.ReadLine();
                        break;
                    case "Admire":
                        Console.WriteLine("The walls haven't changed. Still full of letters. Don't waste anymore time here");
                        Console.WriteLine("Before you leave, don't forget to [Collect] the beasts legs");
                        Console.ReadLine();
                        break;
                }
            }
            Console.WriteLine("You've collected [" + parts[round - 1] + level + "]");
            Player.PartAdd(parts[round - 1] + level);
            Player.ShowInventory();
            Console.WriteLine("[Continue] to the next room");
            Console.ReadLine();
        }
    }
}
