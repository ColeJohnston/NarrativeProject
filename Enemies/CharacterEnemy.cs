using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemp.Enemies
{
    internal class CharacterEnemy : Enemy
    {
        static int WordLength;
        static double time = 5;
        private string options = "abcdefghijklmnopqrstuvwxyz";
        internal override void sethp(int level, int round)
        {
            hp = ((level + (5 * (round - 1))) * 5);
        }
        internal override void setword()
        {
            word = string.Empty;
            Random random = new Random();
            for(int i = 0; i < WordLength; i++)
            {
                word += options[random.Next(0, options.Length)];
            }
            ShowWord(time);
        }
        internal override void setwordLength(int level, int round)
        {
            WordLength = level + (5 * (round-1));
        }
    }
}
