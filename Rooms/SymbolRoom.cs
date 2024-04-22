using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Fighting.Fight();
        }
    }
}
