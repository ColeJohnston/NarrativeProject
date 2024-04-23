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
                Console.WriteLine("You approach the second room, this room is much louder and upon inspecting the walls, " +
                    "\nyou see the same letters from before but with a mix of capital and lowercase letters. Just as you realize this, " +
                    "\nyour second challenge appears and begins to speak:");
            }
            else if (!beatR[1])
            {
                Console.WriteLine("You arrive here again. Its not too hard. You ready yourself as the beast appears from the shadows once again. " +
                    "\nThe beast shouts");
                //second time in room 2
            }
            else
            {
                Console.WriteLine("This is insane. Are you going insane? What is going on here? The walls are moving, the floor is shaking. " +
                    "\nYou're beginning to feel nauseous and dizzy the longer you stay. Focus up, the beast is here again");
                //final time in room 2
            }
            Thread.Sleep(15000);
            Console.Clear();
            Fighting.Fight();
        }
    }
}
