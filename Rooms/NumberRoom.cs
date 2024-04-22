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
                Console.WriteLine("Back to the number room… maybe you’ll try running. No, you know that wont work. " +
                    "\nYou fear the worst for your dad. He can't die, you can't let it happen. " +
                    "\nFeeling this courage filling your veins you challenge the beast again");
                //second time in room 3
            }
            else
            {
                Console.WriteLine("So many numbers, so many letters, so much chaos. The walls feel as though they are creeping in. " +
                    "\nYou feel stuck. You feel so small in such a big world. How can one feel so closed in while feeling so little. " +
                    "\nThe beast has arrived again.");
                //final time in room 3
            }
            Thread.Sleep(15000);
            Console.Clear();
            Fighting.Fight();
        }
    }
}
