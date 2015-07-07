using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JackalEngine.Map;


namespace JackalEngine
{
    public class Game
    {





    }
    public enum CellType
    {
        Water = 0,
        Unreached,
        Empty,
        WithGold,
        WithCharacter,
        CharacterWithGold
    }
    public class GameMap
    {
        public const int _xSize = 10;
        public const int _ySize = 10;
        private Cell[,] map = new Cell[_xSize, _ySize];
        public GameMap()
        {
            InitMap();
        }
        private void InitMap()
        {
            for (int i = 0; i < _ySize; i++)
            {
                map[0, i] = new Cell(CellType.Water);
                map[_xSize - 1, i] = new Cell(CellType.Water);
            }
            for (int i = 0; i < _xSize; i++)
            {
                map[i, 0] = new Cell(CellType.Water);
                map[i, _ySize - 1] = new Cell(CellType.Water);
            }
            for (int i = 1; i < (_xSize - 1); i++)
                for (int j = 1; j < (_ySize - 1); j++)
                    map[i, j] = new Cell();

        }
        public Cell this[int xCoord, int yCoord]
        {
            get
            {
                return map[xCoord, yCoord];
            }
        }
    }
    public class Cell
    {
        public CellType Type { get; private set; }
        public Cell()
        {
            Type = CellType.Unreached;
        }
        public Cell(CellType type)
        {
            Type = type;
        }
        public override string ToString()
        {
            return "-------------" + Type.ToString() + "\n";
        }


    }
}
