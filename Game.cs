using ProjectTemp.Enemies;
using ProjectTemp.Rooms;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Specialized;

namespace ProjectTemp
{
    internal class Game
    {
        static SaveData savedata;
        //initialize rooms
        static Room characterroom = new CharacterRoom();
        static Room caseroom = new CaseRoom();
        static Room numberroom = new NumberRoom();
        static Room symbolroom = new SymbolRoom();
        static Room bossroom = new BossRoom();
        //done

        static public int level = 1;
        static public int round = 1;
        static int NewRoom;
        static bool[] beatR = new bool[3];
        static bool[] beatL = new bool[5];
        public static void complete()
        {
            Room.complete(beatR, level, round);
            if (level != 5)
            {
                beatL[level - 1] = true;
                level++;
            }
            else
            {
                beatR[round - 1] = true;
                level = 1;
                round++;
            }
            CreateSave();
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
            Console.Clear();
            if (firstchoice == "flee")
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
            Console.WriteLine("\nPLAYER HP: " + Player.hp + "\t \t \tENEMY HP: " + Enemy.hp);
            if (Player.shield > 0)
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
                try
                {
                    NewRoom = int.Parse(Console.ReadLine());
                }
                catch { }
            } while (NewRoom > temp);
            ChangeRoom(NewRoom);
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
        public static void Win()
        {
            Console.WriteLine("Your father is there, he is all bones. Extremely malnourished. " +
                "\nYou rush to him as he shows no signs of life. You stare intently at his chest, yet there is no movement. " +
                "\nNo breathing, no heartbeat. You lose all remaining hope you had. Did you take too long? No, you did your best. " +
                "\nAll these thoughts and doubts rushing through your head as you stare at your deceased father when all of a sudden, one breath… " +
                "\nOne expansion in his chest and your heart is filled with hope again. He is alive, you can still rescue him. " +
                "\nYou drag him out of this horrid cave and bring him to the nearest hospital. You were just in time. " +
                "\nYou stare at your dad picturing what your life would have been like without him. He notices this and interrupts your thoughts saying " +
                "\n\"Holy shit you smell bad.\"" +
                "\nHe's probably right, all of this monster slaying really stank you up");
            reset();
        }
        public static void CreateSave()
        {
            const string Save = "Save.txt";
            using (FileStream fileStream = File.Create(Save))
            {
                savedata = new SaveData(Player.created, Player.difference, Player.shield, Player.doubler, Enemy.nap, level, round, Player.Items, Player.Parts,
                    Collectables.amount, Collectables.used, Player.hp, Collectables.NotShown);
                var bf = new BinaryFormatter();
                bf.Serialize(fileStream, savedata);
            }
        }
        public static void LoadSave()
        {
            const string Save = "Save.txt";
            using (FileStream fileStream = File.OpenRead(Save))
            {
                var bf = new BinaryFormatter();
                savedata = bf.Deserialize(fileStream) as SaveData;
                Player.created = savedata.created;
                Player.difference = savedata.difference;
                Player.shield = savedata.shield;
                Player.doubler = savedata.doubler;
                Enemy.nap = savedata.nap;
                level = savedata.Level;
                round = savedata.Round;
                Player.Items = savedata.Items;
                Player.Parts = savedata.Parts;
                Collectables.amount = savedata.Quantity;
                Collectables.used = savedata.Used;
                Player.hp = savedata.Hp;
                Collectables.NotShown = savedata.NotShown;
            }
        }
        public static void reset()
        {
            Player.created = false;
            Player.difference = false;
            Player.shield = 0;
            Player.doubler = false;
            Enemy.nap = 0;
            level = 1;
            round = 1;
            Player.Items.Clear();
            Player.Parts.Clear();
            Collectables.amount[0] = "3";
            Collectables.amount[1] = "Active";
            Collectables.amount[2] = "5";
            Collectables.amount[3] = "Inactive";
            for (int i = 0; i < Collectables.used.Length; i++)
            {
                Collectables.used[i] = false;
            }
            Collectables.NotShown = true;
            CreateSave();
        }
        public static void GameOver()
        {
            Console.WriteLine("You lose");
            reset();
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
