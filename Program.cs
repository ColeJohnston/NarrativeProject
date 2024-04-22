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
        //begin room one
        Player player = new Player();
        player.CharacterSelect();
        player.SetHp();
        Fighting.StartFight();
        while (Game.round < 4)
        {
            Fighting.Fight();
        }
    }
}