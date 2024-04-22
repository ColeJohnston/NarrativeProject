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
                Thread.Sleep(30000);
                //intro to boss
            }
            else if (!beatR[1])
            {
                Console.WriteLine("This beast is getting to your head. It feels so overwhelming. " +
                    "\nThe only thing here to keep you here's the knowledge that there is more behind you than ahead of you at this moment. " +
                    "\nYour greatest challenge approaches");
                Thread.Sleep(15000);
                //second time in boss
            }
            else
            {
                Console.WriteLine("You’ve arrived here with a will stronger than you've ever had before. " +
                    "\nReady to take down your final challenge while on the brink of insanity.. " +
                    "\nThe beast expresses one final desperate attempt to take you down");
                //final time in boss
                Thread.Sleep(15000);
            }
            Fighting.Fight();
        }
    }
}
