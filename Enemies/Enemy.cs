using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ProjectTemp.Enemies
{
    internal abstract class Enemy
    {
        static int dealt = 0;
        static int recieved = 0;
        public static int hp;
        public static int nap = 0;
        string attempt = string.Empty;
        public static string word = string.Empty;
        internal abstract void sethp(int level, int round);
        internal abstract void setword();
        internal abstract void setwordLength(int level, int round);
        public void ShowWord(double time)
        {
            Game.showHp();
            Console.WriteLine(word);
            Thread.Sleep((int)(time*1000 * (Math.Pow(0.75,nap))));
            Console.Clear();
            Game.showHp();
            attempt = Console.ReadLine();
            if (attempt == "i" && Game.round > 1)
            {
                Player.showitems();
                attempt = Console.ReadLine();
                guess(word, attempt);
            }
            else
            {
                guess(word, attempt);
            }
        }
        public static void guess(string word, string guess)
        {
            for(int i = 0; i < word.Length; i++)
            {
                if(i < guess.Length)
                {
                    if (guess[i]== word[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        dealt++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        recieved++;
                    }
                    Console.Write(guess[i]);
                }
                else
                {
                    recieved++;
                }
                Console.ResetColor();
            }
            for (int i = word.Length; i < guess.Length; i++)
            {
                recieved++;
                Console.ForegroundColor= ConsoleColor.Red;
                Console.Write(guess[i]);
                Console.ResetColor();
            }
            if (Player.difference)
            {
                dealt -= recieved;
                if(dealt > 0)
                {
                    updatehp(dealt);
                }
                else
                {
                    Player.updatehp(dealt);
                }
                dealt = 0;
                recieved = 0;
            }
            else
            {
                updatehp(dealt);
                Player.updatehp(recieved);
                dealt = 0;
                recieved = 0;
            }
            Console.WriteLine();
        }
        internal static void updatehp(int damage)
        {
            if (Player.doubler)
            {
                damage *= 2;
            }
            hp -= damage;
            if (hp <= 0)
            {
                Game.complete();
            }
        }

    }
}
