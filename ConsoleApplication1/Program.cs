using JackalEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConsoleApplication1
{
    class Program
    {
        class Exit : Exception { }
        static int player = 0;
        static void Main(string[] args)
        {
            
            TurnInfo info;
            Game game = new Game(2);
            Application.Run(new Form1(game));
            Console.Title = "Jackal";
            Console.CursorVisible = false;
        NotExit:
            PrintMap(game.Map);
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
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    goto NotExit;
                                    }
            }
        }

        private static TurnInfo WaitForTurn()
        {
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
                    Console.CursorLeft = 0;
                    goto Repeat;
                    break;
            }
            // return new TurnInfo(0, side);
            return new TurnInfo(player == 0 ? player++ : player--, side);
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
                    picture = '♦';
                    break;
                case CellType.Character:
                    picture = '☺';
                    break;
                case CellType.CharacterWithGold:
                    picture = '☻';
                    break;
                case CellType.Ship:
                    picture = '⌂';
                    break;
            }
            Console.Write(picture);
        }

    }
}
