using ProjectTemp;
using ProjectTemp.Enemies;
using ProjectTemp.Rooms;
using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

[Serializable]
public class SaveData
{
    public bool created;
    public bool difference;
    public int shield;
    public bool doubler;
    public int nap;
    public int Level;
    public int Round;
    public List<string> Items;
    public List<string> Parts;
    public string[] Quantity;
    public bool[] Used;
    public int Hp;
    public bool NotShown;
    public SaveData(bool created, bool difference, int shield, bool doubler, int nap, int level, int round, List<string> items, List<string> parts, string[] quantity, bool[] used, int hp, bool notShown)
    {
        this.created = created;
        this.difference = difference;
        this.shield = shield;
        this.doubler = doubler;
        this.nap = nap;
        Level = level;
        Round = round;
        Items = items;
        Parts = parts;
        Quantity = quantity;
        Used = used;
        Hp = hp;
        NotShown = notShown;
    }
}
    class Program
    {
    static void Main(string[] args)
    {
        if (!File.Exists("Save.txt"))
        {
            Game.CreateSave();
        }
        Game.LoadSave();
        //character select
        //introduce story
        if (Player.created)
        {
            Console.WriteLine("Welcome Back");
            while (true)
            {
                Console.WriteLine("New game or continue?");
                string choice = Console.ReadLine().ToLower();
                if (choice == "new game")
                {
                    Game.reset();
                    Game.CreateSave();
                    Console.Clear();
                    break;
                }
                else if (choice == "continue")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("That was an invalid option, please try again.");
                }
            }
        }
        if (!Player.created)
        {
            Game.introduction();
            Player player = new Player();
            player.CharacterSelect();
            player.SetHp();
            Console.Clear();
        }
        while (Game.round < 4)
        {
            Fighting.StartFight();
            Fighting.Fight();
        }
        Game.Win();
    }
}