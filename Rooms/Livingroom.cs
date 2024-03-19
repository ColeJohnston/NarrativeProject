using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class Livingroom : Room
    {
        internal override string CreateDescription() =>
@"You are in the Living room.
The [door] in front of you takes you outside.
There is a [couch] to your left.
Behind you is the [bedroom].
";
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "door":
                    Console.WriteLine("You leave the house, but become scared of the ouside, returning quickly");
                    break;
                case "couch":
                    Console.WriteLine("You sit down, though its not too comfy");
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        }
}
