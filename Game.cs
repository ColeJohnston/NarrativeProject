using ProjectTemp.Enemies;
using ProjectTemp.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemp
{
    internal class Game
    {
        //initialize rooms
        static Room characterroom = new CharacterRoom();
        static Room caseroom = new CaseRoom();
        static Room numberroom = new NumberRoom();
        static Room symbolroom = new SymbolRoom();
        static Room bossroom = new BossRoom();
        //done

        static public int level = 1;
        static public int round = 1;
        static int CurrentRoom = 1;
        static bool[] beatR = new bool[3];
        static bool[] beatL = new bool[5];
        public static void complete()
        {
            Room.complete(beatR, level, round);
            if(level != 5)
            {
                level++;
            }
            else
            {
                level = 1;
                round++;
            }
        }
        public static void introduction()
        {
            Console.WriteLine("Your father went missing in a cave system with only 1 letter telling you where and the solution to the puzzle. " +
                "\nThe letter reads, \"I don’t have much left in me, I am in the cave by the redwood forest north of our house.\"");
            Console.WriteLine("[Press Enter]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You know the cave, you’ve always been told to avoid it. You continue to read." +
                "\n“These beasts speak a foreign powerful language that does true physical harm to humans. The way you counter it? " +
                "\nYou must repeat exactly what they say. They are as weak to it as we are. The closer you are to repeating their phrases, the more it hurts them.\"");
            Console.WriteLine("[Press Enter]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("How long has he known about this for? Why did he go alone? Why did he go at all??? " +
                "\nYou read the final line of the message." +
                "\nCome rescue me, you are the only one I trust\"");
            Console.WriteLine("[Press Enter]");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You set out for the cave");
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("You have arrived. Would you like to [Enter] or [Flee]?");
            string firstchoice = Console.ReadLine().ToLower();
            if(firstchoice == "flee")
            {
                Console.Write("You are a ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("bitch ");
                Console.ResetColor();
                Console.Write("and ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("bitches ");
                Console.ResetColor();
                Console.WriteLine("aren't winners. ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("You Lose");
                Thread.Sleep(10000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Good choice. Now it is time for you to choose your character.");
                Console.WriteLine("You can either be [Difference] or [Trade-Off]");
                Console.WriteLine("\n\nDifference" +
                    "\n----------" +
                    "\nHP: 20" +
                    "\n*Damage taken is subtracted from damage output" +
                    "\n" +
                    "\n\n\n" +
                    "Trade-Off" +
                    "\n---------" +
                    "\nHP: 100" +
                    "\n*Recieves full damage, but also outputs full damage");
            }
        }
        public static void showHp()
        {
            Console.WriteLine("PLAYER HP: " + Player.hp + "\t \t \tENEMY HP: " + Enemy.hp);
            if(Player.shield > 0)
            {
                Console.WriteLine("SHIELD: " + Player.shield);
            }
        }
        public static void ChooseRoom()
        {
            string message = "Which woom would you like to go to?\n" +
                "[1] ";
            int temp = 1;
            for (int i = 1; i <= beatL.Length; i++)
            {
                if (beatL[i]) 
                {
                    temp++;
                    message += $"[{i}] "; 
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(message);
            do
            {
                CurrentRoom = int.Parse(Console.ReadLine());
            } while (CurrentRoom > temp);
            ChangeRoom(CurrentRoom);
        }
        public static void ChangeRoom(int choice)
        {
            switch (choice)
            {
                case 1:
                    characterroom.introduction(beatR, beatL);
                    break;
                case 2:
                    caseroom.introduction(beatR, beatL);
                    break;
                case 3:
                    numberroom.introduction(beatR, beatL);
                    break;
                case 4:
                    symbolroom.introduction(beatR, beatL);
                    break;
                case 5:
                    bossroom.introduction(beatR, beatL);
                    break;
            }
        }
        public static void GameOver()
        {
            Console.WriteLine("You lose");
            Environment.Exit(0);
        }
    }
}
