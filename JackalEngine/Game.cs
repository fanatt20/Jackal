using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JackalEngine.Map;


namespace JackalEngine
{
    public enum Side
    {
        Right = 0,
        Left,
        Up,
        Down
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
    public class TurnInfo
    {
        public int CharacterID { get; set; }
        public Side MovingSide { get; set; }
        private TurnInfo() { }
        public TurnInfo(int charID, Side moveTo)
        {
            CharacterID = charID;
            MovingSide = moveTo;

        }

    }
    internal class Character
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public Cell CurrentCell;
        private Character() { }
        public Character(int xCoordinate, int yCoordinate)
        {
            CurrentCell = new Cell(CellType.Water);
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
        public bool MoveTo(Side side)
        {
            if ((side == Side.Down && YCoordinate > (GameMap._ySize - 2)) ||
                (side == Side.Up && YCoordinate < 1) ||
                (side == Side.Right && XCoordinate > (GameMap._xSize - 2)) ||
                (side == Side.Left && XCoordinate < 1))
                return false;
            switch (side)
            {
                case Side.Down:
                    YCoordinate += 1;
                    break;
                case Side.Up:
                    YCoordinate -= 1;
                    break;
                case Side.Left:
                    XCoordinate -= 1;
                    break;
                case Side.Right:
                    XCoordinate += 1;
                    break;
                default:
                    throw new NotImplementedException("sry");
                    break;
            }
            return true;
        }

    }
    public class Game
    {

        private GameMap map = new GameMap();
        private List<Character> lst = new List<Character>();
        public Game()
        {
            map[map.XSize / 2, 0] = new Cell(CellType.WithCharacter);
            lst.Add(new Character(map.XSize / 2, 0));

        }

        public GameMap Move(TurnInfo info)
        {
            if (info.CharacterID >= lst.Count)
                throw new ArgumentOutOfRangeException(String.Format("No Character with ID={0}", info.CharacterID));
            Character ch = lst[info.CharacterID];
            if (ch.MoveTo(info.MovingSide))
            {
                
                switch (info.MovingSide)
                {
                    case Side.Right:
                        map[ch.XCoordinate - 1, ch.YCoordinate] = ch.CurrentCell;
                        break;
                    case Side.Left:
                        map[ch.XCoordinate + 1, ch.YCoordinate] = ch.CurrentCell;
                        break;
                    case Side.Up:
                        map[ch.XCoordinate, ch.YCoordinate + 1] = ch.CurrentCell;
                        break;
                    case Side.Down:
                        map[ch.XCoordinate, ch.YCoordinate - 1] = ch.CurrentCell;
                        break;
                    default:
                        break;
                }
                ch.CurrentCell = map[ch.XCoordinate, ch.YCoordinate];
                map[ch.XCoordinate, ch.YCoordinate] = new Cell(CellType.WithCharacter);
            }


            return map;
        }


    }

    public class GameMap
    {
        public const int _xSize = 10;
        public const int _ySize = 10;
        public int XSize { get { return _xSize; } }
        public int YSize { get { return _ySize; } }
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
            set
            {
                map[xCoord, yCoord] = value;
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
