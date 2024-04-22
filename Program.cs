using ProjectTemp;
using ProjectTemp.Enemies;
using ProjectTemp.Rooms;
using System;
class Program
{
    static void Main(string[] args)
    {
        //character select
        //introduce story
        Game.introduction();
        //begin room one
        Player player = new Player();
        player.CharacterSelect();
        player.SetHp();
        Console.Clear();
        Game.ChangeRoom(1);
        while (Game.round < 4)
        {
            Fighting.Fight();
        }
    }
}