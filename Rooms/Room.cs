using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemp.Rooms
{
    internal abstract class Room
    {
        internal abstract void introduction(bool[] beatR, bool[] beatL);
        internal static void complete(bool[] beatR, int level, int round)
        {
            string choice = "temp";
            string[] parts = { "arms", "legs", "head+torso" };
            if(level != 5)
            {
                Console.WriteLine($"\nCongrats on beating beast {level}, it only gets harder from here." +
    "\nWould you like to [Continue] to the next room" +
    "\n or stop to [Admire] the room some more");
                choice = Console.ReadLine();
            }
            else
            {
                Player.PartAdd(parts[round - 1] + level);
                string temp;
                Console.WriteLine("The boss is dead and delimbed. Now that he is out of the way, you notice 5 monster shaped holes in the wall...");
                Console.WriteLine("Come to think of it, you've collected many body parts... eww. Would you like to maybe insert those into the slots in the wall?" +
                    "\n or would you like to hold on to those." +
                    "\n[Hold] or [Insert]");
                temp = Console.ReadLine().ToLower();
                if(temp == "insert")
                {
                    Player.RemoveLimbs();
                }
                else { Console.WriteLine("Eww"); }
                Console.WriteLine("The boss had a very comfy bed and now that he is disposed of, You can saftely nap.");
                Console.WriteLine("Napping restores 50% of your missing hp, but gives you 25% less reading time for future words");
                Console.WriteLine("Would you like to nap?");
                Console.WriteLine("[Y] or [N]");
                temp = Console.ReadLine().ToUpper();
                if(temp == "Y")
                {
                    Player.nap();
                    Console.WriteLine("NEW HP: " + Player.hp);
                }
                Console.WriteLine($"\nSince you beat boss {round}/3 you can choose One item from the shop");
                Collectables.shop();
            }
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
                            for(int i = 15; i > 0; i--)
                            {
                                Console.WriteLine(i);
                                Thread.Sleep(1000);
                            }
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
            if (level != 5)
            {
                Console.WriteLine("You've collected [" + parts[round - 1] + level + "]");
                Console.WriteLine("[Press Enter] to See inventory");
                Player.PartAdd(parts[round - 1] + level);
                Console.ReadLine();
                Console.Clear();
                Player.ShowInventory();
                Console.WriteLine("\n[Press Enter] to continue to the next room");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
