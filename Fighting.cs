﻿using ProjectTemp.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Game.ChangeRoom(level);
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
            int level = Game.level;
            int round = Game.round;
            switch (level)
            {
                case 1:
                    while(Player.hp > 0 && Enemy.hp > 0)
                    {
                        ChE.setword();
                    }
                    break;
                case 2:
                    while (Player.hp > 0 && Enemy.hp > 0)
                    {
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
