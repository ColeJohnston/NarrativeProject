using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                Console.WriteLine("This room seems like the hardest challenge yet. There are noises coming from all sides of the room… what happened? " +
                    "\nWhat is going on, what is this feeling filling my head. You inspect the walls and… What the fuck is that? Is it math? " +
                    "\nIt has letters, numbers, and symbols. You look towards the back of the room and notice the most horrid creature one could imagine. " +
                    "\nIt sees your disgust with it and begins crying. you feel bad and begin contemplating giving up and letting this beast bless you with the sweet relief of death. " +
                    "\nSeeing this contemplation, it becomes agressive and tries to make the decision for you");
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
            Thread.Sleep(30000);
            Fighting.Fight();
        }
    }
}
