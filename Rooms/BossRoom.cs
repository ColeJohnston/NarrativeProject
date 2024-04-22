using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemp.Rooms
{
    internal class BossRoom : Room
    {
        internal override void introduction(bool[] beatR, bool[] beatL)
        {
            if (beatL[4])
            {
                Console.WriteLine("The beast is still lying dead on the floor with limbs removed. Venture on while you still can.");
            }
            else if (!beatR[0])
            {
                //intro to boss
            }
            else if (!beatR[1])
            {
                //second time in boss
            }
            else
            {
                //final time in boss
            }
            Fighting.Fight();
        }
    }
}
