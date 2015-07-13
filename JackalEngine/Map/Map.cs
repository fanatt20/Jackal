using System.Collections.Generic;

namespace JackalEngine
{
    public class Map
    {
        public const int XSize = 20;
        public const int YSize = 20;
        private readonly List<Cell> _changedCells = new List<Cell>();
        private readonly Cell[,] _map = new Cell[XSize, YSize];

        public Map()
        {
            InitMap();
        }

        public Cell this[int xCoord, int yCoord]
        {
            get { return _map[xCoord, yCoord]; }
            set
            {
                _map[xCoord, yCoord] = value;
                _map[xCoord, yCoord].XCoord = xCoord;
                _map[xCoord, yCoord].YCoord = yCoord;
                _changedCells.Add(_map[xCoord, yCoord]);
            }
        }

        public List<Cell> ChangedCells(bool clearColl)
        {
            var res = new List<Cell>();
            res.AddRange(_changedCells);
            if (clearColl)
                _changedCells.Clear();
            return res;
        }

        private void InitMap()
        {
            for (var i = 0; i < YSize; i++)
            {
                _map[0, i] = new Cell(CellType.Water);
                _map[XSize - 1, i] = new Cell(CellType.Water);
            }
            for (var i = 0; i < XSize; i++)
            {
                _map[i, 0] = new Cell(CellType.Water);
                _map[i, YSize - 1] = new Cell(CellType.Water);
            }
            for (var i = 1; i < (XSize - 1); i++)
                for (var j = 1; j < (YSize - 1); j++)
                    _map[i, j] = new Cell();
        }
    }
}