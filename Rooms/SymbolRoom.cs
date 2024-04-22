using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemp.Rooms
{
    internal class SymbolRoom : Room
    {
        internal override void introduction(bool[] beatR, bool[] beatL)
        {
            if (beatL[3])
            {
                Console.WriteLine("The beast is still lying dead on the floor with limbs removed. Venture on while you still can.");
            }
            else if (!beatR[0])
            {
                Console.WriteLine("Room 4 seems more empty. There is no noise, not even your steps are making noise. " +
                    "\nYou look around and realize why… There are no letters. There are no numbers. " +
                    "\nThere are just symbols on the wall. You quickly scan the room unable to find the beast. " +
                    "\nYou take a moment to mentally note every symbol you see. The beast suddenly falls from the ceiling, ready to attack. " +
                    "\nLuckily, you were able to notice the symbols: !, @, #, $, %, ^, &, *, (, )");
                //intro to room 4
            }
            else if (!beatR[1])
            {
                //second time in room 4
            }
            else
            {
                //final time in room 4
            }
            Thread.Sleep(25000);
            Fighting.Fight();
        }
    }
}
