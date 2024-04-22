using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Console.WriteLine("\noingus boingus we are here");
            }
            else if (!beatR[1])
            {
                //second time in room 2
            }
            else
            {
                //final time in room 2
            }
            Fighting.Fight();
        }
    }
}
