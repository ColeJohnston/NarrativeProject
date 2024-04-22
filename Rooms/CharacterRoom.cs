using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectTemp.Rooms
{
    internal class CharacterRoom : Room
    {
        internal override void introduction(bool[] beatR, bool[] beatL)
        {
            if (beatL[0])
            {
                Console.WriteLine("The beast is still lying dead on the floor with limbs removed. Venture on while you still can.");
            }
            else if (!beatR[0])
            {
                Console.WriteLine("" +
                    "“You approach the room, it seems quiet. " +
                    "\nThere are symbols on the walls, they look like lowercase letters. " +
                    "\nSuddenly a beast appears, yet weirdly quiet but definitely threatening you. " +
                    "\nYou remember your dad’s note. The beast begins to speak");
            }
            else if (!beatR[1])
            {
                Console.WriteLine("You find yourself once again in the room with the first set of cryptic symbols. " +
                    "\nDespite its familiarity, a sense of unease grips you as you tread the well-worn path." +
                    "\n IT appears and begins to speak again");
            }
            else
            {
                Console.WriteLine("You arrive again, for the final time. Knowing this beast will be even tougher this time." +
                    "\n it appears again, just as it did twice before, and begins to speak");
            }
            Thread.Sleep(15000);
            Console.Clear();
            Fighting.Fight();
        }
    }
}