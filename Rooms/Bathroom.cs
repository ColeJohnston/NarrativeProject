using System;

namespace NarrativeProject.Rooms
{
    internal class Bathroom : Room
    {
        bool bathOn = false;
        internal override string CreateDescription() =>
@"In your bathroom, the [bath] is filled with hot water.
The [mirror] in front of you reflects your depressed face.
You can return to your [bedroom].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bath":
                    bathOn = true;
                    Console.WriteLine("You turn on the bath.");
                    break;
                case "mirror":
                if(bathOn)
                {
                    Console.WriteLine("You see the numbers 42069 written on the fog on your mirror.");
                }
                else
                {
                    Console.WriteLine("You see yourself");
                }
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
