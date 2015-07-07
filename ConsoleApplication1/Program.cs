using JackalEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            GameMap map = new GameMap();
            PrintMap(map);
            Console.ReadKey();
           
        }

        private static void PrintMap(GameMap map)
        {
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
            char picture='0';
            switch (cell.Type)
            {
                case CellType.Unreached:
                    picture= '░';
                    break;
                case CellType.Water:
                    picture='▒';
                    break;
                
            }
            Console.Write(picture);
        }
        
    }
}
