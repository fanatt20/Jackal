﻿using JackalEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        class Exit : Exception { }
        static int player=0;
        static void Main(string[] args)
        {
            TurnInfo info;
            Game game = new Game(2);
            try
            {
                while (true)
                {
                    info = WaitForTurn();
                    PrintMap(game.Move(info));
                }

            }
            catch (Exit)
            {
                Console.WriteLine("Exit");
            }
            Console.ReadKey();

        }

        private static TurnInfo WaitForTurn()
        {
            TurnInfo result;
            Side side;
        Repeat:
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    throw new Exit();
                    break;
                case ConsoleKey.UpArrow:
                    side = Side.Up;
                    break;
                case ConsoleKey.DownArrow:
                    side = Side.Down;
                    break;
                case ConsoleKey.RightArrow:
                    side = Side.Right;
                    break;
                case ConsoleKey.LeftArrow:
                    side = Side.Left;
                    break;
                default:
                    goto Repeat;
                    break;
            }
            return new TurnInfo(player==0?player++:player--, side);
        }

        private static void PrintMap(GameMap map)
        {
            Console.Clear();
            for (int j = 0; j < GameMap._xSize; j++)
            {
                for (int i = 0; i < GameMap._ySize; i++)
                {
                    DrawCell(map[i, j]);

                }
                Console.WriteLine();
            }
        }

        private static void DrawCell(Cell cell)
        {
            char picture = '0';
            switch (cell.Type)
            {
                case CellType.Unreached:
                    picture = '░';
                    break;
                case CellType.Water:
                    picture = '▒';
                    break;
                case CellType.WithGold:
                    picture = '☼';
                    break;
                case CellType.Empty:
                    picture = '♠';
                    break;
                case CellType.WithCharacter:
                    picture = '☺';
                    break;
                case CellType.CharacterWithGold:
                    picture = '☻';
                    break;
            }
            Console.Write(picture);
        }

    }
}
