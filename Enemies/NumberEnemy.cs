using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemp.Enemies
{
    internal class NumberEnemy : Enemy
    {
        static int WordLength;
        static double time = Math.Round(10.0 / (4 - Game.round), 3);
        private string options = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        internal override void sethp(int level, int round)
        {
            hp = ((level + (5 * (round - 1))) * 3);
        }
        internal override void setword()
        {
            word = string.Empty;
            Random random = new Random();
            for (int i = 0; i < WordLength; i++)
            {
                word += options[random.Next(0, options.Length)];
            }
            ShowWord(time);
        }
        internal override void setwordLength(int level, int round)
        {
            WordLength = level + (5 * (round - 1));
        }
    }
}
