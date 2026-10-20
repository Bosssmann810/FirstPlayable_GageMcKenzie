using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_GageMcKenzie
{
    internal class Map
    {
        
        static string _mapData = @"MapFile.txt";
        string[] _newMapData = File.ReadAllLines(_mapData);
        Player _player;
       List <Enemy> _enemy;

        static int borderPosX;
        static List<(int, int)> _border = new List<(int, int)>();
        static List<(int, int)> _damageBorder = new List<(int, int)>();
        static char charInMap;
        //static Dictionary<char, ConsoleColor> mapChars = new Dictionary<char, ConsoleColor>()
        //{
        //    {'`', ConsoleColor.Green},
        //    {'~', ConsoleColor.Blue},
        //    {'^', ConsoleColor.White},
        //    {'*', ConsoleColor.Yellow},
        //    {'_', ConsoleColor.DarkRed}
        //};

        public Map(Player player, List<Enemy> enemy)
        {
            _player = player;
            _enemy = enemy;
        }

        public void PrintMap()
        {
            
            
            int bottem = 0;
            int mapPosy = 0;
            int mapPosx = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('┌');
            for (int l = 0; l < _newMapData[0].Length; l++)
            {
                _border.Add((l, mapPosy));
                Console.Write('-');

            }
            Console.Write("┐");
            Console.WriteLine(" ");
            for (int i = 0; i < _newMapData.GetLength(0); i++)
            {
                mapPosx += 1;

                

                _border.Add((borderPosX, i));
                _border.Add((borderPosX, i + 1));
                Console.Write('|');
                for (int j = 0; j < _newMapData[i].Length; j++)
                {

                    mapPosy += 1;

                    

                    if (_newMapData[i][j] == '`')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(_newMapData[i][j]);
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    if (_newMapData[i][j] == '[')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(_newMapData[i][j]);
                        _border.Add((j + 1, i + 1));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (_newMapData[i][j] == ']')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(_newMapData[i][j]);
                        _border.Add((j + 1, i + 1));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (_newMapData[i][j] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(_newMapData[i][j]);
                        _border.Add((j + 1, i + 1));
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    if (_newMapData[i][j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(_newMapData[i][j]);
                        _border.Add((j + 1, i + 1));
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    /*
                    if (_newMapData[i][j] == '_')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(_newMapData[i][j]);
                        charInMap = _newMapData[i][j];
                        _damageBorder.Add((j + 1, i + 1));

                        CheckPos();
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    */
                    if (_newMapData[i][j] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(_newMapData[i][j]);

                        _border.Add((j + 1, i + 1));
                    }
                    if (mapPosx == _newMapData.GetLength(0))
                    {
                        for (int l = 0; l < _newMapData[0].Length; l++)
                        {
                            _border.Add((bottem, mapPosx + 1));
                            bottem += 1;

                        }

                    }


                    borderPosX += 1;
                }
                mapPosy = 0;
                Console.WriteLine('|');
                _border.Add((borderPosX + 1, i));
                _border.Add((borderPosX + 1, i + 1));
                borderPosX = 0;
            }
            Console.Write('└');
            for (int l = 0; l < _newMapData[0].Length; l++)
            {
                Console.Write('-');

            }
            Console.WriteLine("┘");

        }

        public void CheckPos()
        {
            for (int i = 0; i < _damageBorder.Count(); i++)
            {
                
                    if (_player.currentPos.y == _damageBorder[i].Item2 && _player.currentPos.x == _damageBorder[i].Item1)
                    {
                        _player.TakeDamage(10);
                        _player.PreviousPos();
                        
                    }
                    for (int j = 0; j < _enemy.Count(); j++) {
                        if (_enemy[j]._enemyPos.y == _damageBorder[i].Item2 && _enemy[j]._enemyPos.x == _damageBorder[i].Item1)
                        {
                            _enemy[j].PrePos();
                            _enemy[j].TakeDamage(10);
                            
                        }
                    }
            }

            for (int i = 0; i < _border.Count(); i++)
            {
                if (_player.currentPos.y == _border[i].Item2 && _player.currentPos.x == _border[i].Item1)
                {

                    _player.PreviousPos();

                }
                for (int j = 0; j < _enemy.Count(); j++)
                {
                    if (_enemy[j]._enemyPos.y == _border[i].Item2 && _enemy[j]._enemyPos.x == _border[i].Item1)
                    {
                        _enemy[j].PrePos();
                    }
                }
            }


        }
    }
}
