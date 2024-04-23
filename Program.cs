using ProjectTemp;
using ProjectTemp.Enemies;
using ProjectTemp.Rooms;
using System;
using System.Threading;

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
        while (Game.round < 4)
        {
            Fighting.StartFight();
            Fighting.Fight();
        }
        Game.Win();
    }
}