using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FirstPlayable_GageMcKenzie
{
    internal class Program
    {
        
        public static int turns = 50;
        static bool alive = true;
        static int enenmiesDaed = 0;
        static bool winNum = false;


        static Player player = new Player(100, 50, "Gage", 0, 5, 5, alive, 10);
        static List<Enemy> enemies = new List<Enemy>() 
        {
            
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 10, enemyPosY: 24, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 11, enemyPosY: 20, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 20, enemyPosY: 30, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 40, enemyPosY: 2, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 79, enemyPosY: 34, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 90, enemyPosY: 25, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 77, enemyPosY: 25, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 44, enemyPosY: 7, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 59, enemyPosY: 38, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),
            new ChunkyEnemy(maxHealth: 20, maxShield:0, name: "Heavy", enemyPosX: 100, enemyPosY: 20, player: player, damage: 10,isAlive: true, enemyLogo: '@', color: ConsoleColor.Red),

            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 89, enemyPosY: 5, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red),
            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 4, enemyPosY: 15, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red),
            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 50, enemyPosY: 5, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red),
            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 90, enemyPosY: 15, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red),
            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 100, enemyPosY: 5, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red),
            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 110, enemyPosY: 15, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red),
            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 34, enemyPosY: 5, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red),
            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 62, enemyPosY: 15, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red),
            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 42, enemyPosY: 5, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red),
            new SpeedyEnemy(maxHealth: 10, maxShield: 0, name: "Speedy Boi", enemyPosX: 56, enemyPosY: 15, player: player, damage: 5, isAlive: true, enemyLogo: 'I', color: ConsoleColor.Red)

        };
        static Borders borders = new Borders(player, enemies);

        static List<Items> items = new List<Items>()
        {
            new ChestItem(winNum,enemies, player, 1,21,  20 , '#', ConsoleColor.DarkGray),
            new ShieldItem(player, 15, 10, 2, '(', ConsoleColor.DarkCyan),
            new ShieldItem(player, 90, 1, 2, '(', ConsoleColor.DarkCyan),
            new ShieldItem(player, 110, 25, 2, '(', ConsoleColor.DarkCyan),
            new ShieldItem(player, 40, 16, 2, '(', ConsoleColor.DarkCyan),
            new ShieldItem(player, 60, 2, 2, '(', ConsoleColor.DarkCyan),
            new ShieldItem(player, 56, 10, 2, '(', ConsoleColor.DarkCyan),
            new ShieldItem(player, 120, 1, 2, '(', ConsoleColor.DarkCyan),
            new ShieldItem(player, 89, 25, 2, '(', ConsoleColor.DarkCyan),
            new ShieldItem(player, 23, 16, 2, '(', ConsoleColor.DarkCyan),
            new ShieldItem(player, 56, 2, 2, '(', ConsoleColor.DarkCyan),
            new HealItem(player, 20, 10, 2, 'H', ConsoleColor.DarkGreen),
            new HealItem(player, 50, 15, 2, 'H', ConsoleColor.DarkGreen),
            new HealItem(player, 66, 20, 2, 'H', ConsoleColor.DarkGreen),
            new HealItem(player, 45, 23, 2, 'H', ConsoleColor.DarkGreen),
            new HealItem(player, 13, 30, 2, 'H', ConsoleColor.DarkGreen),
            new HealItem(player, 23, 10, 2, 'H', ConsoleColor.DarkGreen),
            new HealItem(player, 100, 15, 2, 'H', ConsoleColor.DarkGreen),
            new HealItem(player, 90, 20, 2, 'H', ConsoleColor.DarkGreen),
            new HealItem(player, 12, 23, 2, 'H', ConsoleColor.DarkGreen),
            new HealItem(player, 67, 30, 2, 'H', ConsoleColor.DarkGreen),
            new ButtonItem(player, 39,5,1,'?', ConsoleColor.Cyan, borders),
            new ShopItem(player, 18,2, 1, 'H', ConsoleColor.DarkYellow, 1, 0),
            new ShopItem(player, 11,2,1, 'H', ConsoleColor.DarkYellow,1,0),
            new ShopItem (player, 14,2,1,'H', ConsoleColor.DarkYellow,1,0),
            new ShopItem(player, 73, 37, 1, '^', ConsoleColor.DarkYellow, 2, 2),
            new ShopItem(player, 76, 37, 1, '^', ConsoleColor.DarkYellow,2, 2),
            new ShopItem(player, 79, 37, 1, '^', ConsoleColor.DarkYellow,2,2),
            new ShopItem(player, 81, 2, 1, '(', ConsoleColor.DarkYellow,1,1),
            new ShopItem(player, 78, 2,1,'(',ConsoleColor.DarkYellow,1,1),
            new ShopItem(player, 75,2,1,'(',ConsoleColor.DarkYellow,1,1)
        };
        
        
        static GameHud gameHud = new GameHud( player, enemies);

        

        static Money gold = new Money(1, player);

        static Map map = new Map(player, enemies);
        static void Main(string[] args)
        {

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.CursorVisible = false;
            

            Playing();
            Console.Clear();
            if (player.IsALive() == false)
            {
                Console.WriteLine("Game Over");
            }
            else { Console.WriteLine("You Win"); }
            

            Console.ReadKey(true);

            Console.Clear();

        }
        static void Playing()
        {
            borders.AddBorders();
            Draw();
            while (turns != 0 && player.IsALive() == true )
            {
                Update();
                for (int i = 0; i < enemies.Count(); i++)
                {
                    if (enemies[i]._alive == false)
                    {
                        //enenmiesDaed += 1;
                        //enemies[i].Reset();
                        
                        //if(enenmiesDaed == 21)
                        //{
                            enemies.Remove(enemies[i]);
                        
                        
                    }
                    if(enemies.Count() == 0 )
                    {
                       turns = 0;
                    }
                }



            }
        }

        static void Draw()
        {
            Console.SetCursorPosition(0, 0);
            map.PrintMap();
            
            
            gameHud.PlayerHud();
            gameHud.EnemyHud();
            borders.DrawBorder();

            for (int i = 0; i < items.Count(); i++)
            {
                items[i].PlaceItem();
                if (items[i].PickedUp == true)
                {
                    items.Remove(items[i]);
                }
                
                
            }
            
            
            gold.drawMoney();
            player.DrawPlayer();
            for (int i = 0; i < enemies.Count(); i++)
            {
                enemies[i].DrawEnemy();
            }
                
            

            
        }

        static void Update()
        {
            borders.UpdateBorder();
            Draw();


            

            player.UpdatePlayer();
            for (int i = 0; i < enemies.Count(); i++)
            {
                if (player.currentPos.x == enemies[i]._enemyPos.x && player.currentPos.y == enemies[i]._enemyPos.y)
                {
                    player.TakeDamage(enemies[i].Damage());
                    player.PreviousPos();
                    //enemies[i].PrePos();


                }
                map.CheckPos();
                enemies[i].UpdateEnemy();
                
                if (player.currentPos.x == enemies[i]._enemyPos.x && player.currentPos.y == enemies[i]._enemyPos.y)
                {
                    enemies[i].TakeDamage(player.Damage());
                    enemies[i].PrePos();
                    player.PreviousPos();

                }
                for (int j = 0; j < enemies.Count(); j++)
                {
                    if (enemies[i] != enemies[j])
                    {
                        if (enemies[j]._enemyPos.x == enemies[i]._enemyPos.x && enemies[j]._enemyPos.y == enemies[i]._enemyPos.y)
                        {
                            
                            enemies[i].PrePos();
                            enemies[j].PrePos();


                        }
                    }
                }

                //if(enemies[i]._alive == false)
                //{
                //    enemies.Remove(enemies[i]);
                //}
            }
            

            player.IsALive();
            turns -= 0;
            Console.Clear();
            


        }
    }
}
