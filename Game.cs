using ProjectTemp.Enemies;
using ProjectTemp.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
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

        static public int level = 5;
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
