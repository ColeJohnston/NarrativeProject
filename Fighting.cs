using ProjectTemp.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemp
{
    internal class Fighting
    {
        static Enemy ChE = new CharacterEnemy();
        static Enemy CaE = new CaseEnemy();
        static Enemy NE = new NumberEnemy();
        static Enemy SE = new SymbolEnemy();
        static Enemy boss = new Boss();
        public static void StartFight()
        {
            int level = Game.level;
            int round = Game.round;
            switch (level)
            {
                case 1:
                    ChE.setwordLength(level, round);
                    ChE.sethp(level, round);
                    break;
                case 2:
                    CaE.setwordLength(level, round);
                    CaE.sethp(level, round);
                    break;
                case 3:
                    Console.WriteLine("LEVEL: " + level);
                    NE.setwordLength(level, round);
                    NE.sethp(level, round);
                    break;
                case 4:
                    SE.setwordLength(level, round);
                    SE.sethp(level, round);
                    break;
                case 5:
                    boss.setwordLength(level, round);
                    boss.sethp(level, round);
                    break;
            }
        }
        public static void Fight()
        {
            Fighting.StartFight();
            int level = Game.level;
            int round = Game.round;
            Console.WriteLine("LOOK HERE FUCKER: " + level);
            switch (level)
            {
                case 1:
                    while(Player.hp > 0 && Enemy.hp > 0)
                    {
                        Console.WriteLine("LEVEL: " + level);
                        Console.WriteLine(Player.hp);
                        ChE.setword();
                    }
                    break;
                case 2:
                    while (Player.hp > 0 && Enemy.hp > 0)
                    {
                        Console.WriteLine("HP" + Enemy.hp);
                        CaE.setword();
                    }
                    break;
                case 3:
                    while (Player.hp > 0 && Enemy.hp > 0)
                    {
                        NE.setword();
                    }
                    break;
                case 4:
                    while (Player.hp > 0 && Enemy.hp > 0)
                    {
                        SE.setword();
                    }
                    break;
                case 5:
                    while (Player.hp > 0 && Enemy.hp > 0)
                    {
                        boss.setword();
                    }
                    break;
            }
        }
    }
}
