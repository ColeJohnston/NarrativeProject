using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemp.Rooms
{
    internal class CaseRoom : Room
    {
        internal override void introduction(bool[] beatR, bool[] beatL)
        {
            if (beatL[1])
            {
                Console.WriteLine("The beast is still lying dead on the floor with limbs removed. Venture on while you still can.");
            }
            else if (!beatR[0])
            {
                Console.WriteLine("\nYou approach the second room, this room is much louder and upon inspecting the walls, " +
                    "\nyou see the same letters from before but with a mix of capital and lowercase letters. Just as you realize this, " +
                    "\nyour second challenge appears and begins to speak:");
            }
            else if (!beatR[1])
            {
                //second time in room 2
            }
            else
            {
                //final time in room 2
            }
            Thread.Sleep(15000);
            Console.Clear();
            Fighting.Fight();
        }
    }
}
