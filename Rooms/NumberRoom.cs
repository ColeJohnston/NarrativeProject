using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemp.Rooms
{
    internal class NumberRoom : Room
    {
        internal override void introduction(bool[] beatR, bool[] beatL)
        {
            if (beatL[2])
            {
                Console.WriteLine("The beast is still lying dead on the floor with limbs removed. Venture on while you still can.");
            }
            else if (!beatR[0])
            {
                Console.WriteLine("You begin to notice the ramping difficulty. This room seems to have everything ranging from a-Z as well as 0-9 scribbled on the walls, " +
                    "\nceiling and even the floor you’re walking on. As expected, beast number 3 appears hootin and hollerin");
                //intro to room 3
            }
            else if (!beatR[1])
            {
                //second time in room 3
            }
            else
            {
                //final time in room 3
            }
            Thread.Sleep(15000);
            Console.Clear();
            Fighting.Fight();
        }
    }
}
