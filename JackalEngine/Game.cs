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
        CharacterWithGold,
        Ship
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
        public int Gold { get; private set; }
        public int Death { get; private set; }
        public CharInfo GetCharInfo()
        {
            return new CharInfo(Gold, Death);
        }
        public void Die() { Death++; }
        public void TakeGold() { Gold++; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public bool WithGold { get; set; }
        public Cell CurrentCell;
        private Character() { }
        public Character(int xCoordinate, int yCoordinate)
        {
            CurrentCell = new Cell(CellType.Water);
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            WithGold = false;
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
        public bool OpositeMove(Side side)
        {
            if ((side == Side.Down && YCoordinate < 1) ||
                (side == Side.Up && YCoordinate > (GameMap._ySize - 2)) ||
                (side == Side.Right && XCoordinate < 1) ||
                (side == Side.Left && XCoordinate > (GameMap._xSize - 2)))
                return false;
            switch (side)
            {
                case Side.Down:
                    YCoordinate -= 1;
                    break;
                case Side.Up:
                    YCoordinate += 1;
                    break;
                case Side.Left:
                    XCoordinate += 1;
                    break;
                case Side.Right:
                    XCoordinate -= 1;
                    break;
                default:
                    throw new NotImplementedException("sry");
                    break;
            }
            return true;
        }

    }
    internal class Ship
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public List<Character> Crew { get; private set; }


    }
    public class EndTurnInfo
    {
        public GameMap Map { get; private set; }
        public CharInfo[] CharInform { get; private set; }
        private EndTurnInfo() { }
        public EndTurnInfo(GameMap map, params CharInfo[] array)
        {
            Map = map;
            CharInform = new CharInfo[array.Length];
            array.CopyTo(CharInform, 0);

        }
    }
    public class CharInfo
    {
        public int Death { get; private set; }
        public int Gold { get; private set; }
        private CharInfo() { }
        public CharInfo(int gold, int death)
        {
            Death = death;
            Gold = gold;

        }
    }
    public class Game
    {

        private int goldMapCapacity = 17;

        private GameMap map = new GameMap();
        private List<Character> lst = new List<Character>();
        public GameMap Map { get { return map; } }
        private void RestoreCell(GameMap map, Side side, Character ch)
        {
            switch (side)
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
        }

        private void SaveCurrentCell(GameMap map, Character ch)
        {
            int x = ch.XCoordinate;
            int y = ch.YCoordinate;
            ch.CurrentCell = map[ch.XCoordinate, ch.YCoordinate];
        }

        private void GenerateCell(GameMap map, int x, int y)
        {
            var rnd = new Random();
            if (rnd.Next(6) == 0 && goldMapCapacity > 0)
            {
                goldMapCapacity--;
                map[x, y] = new Cell(CellType.WithGold);
            }
            else
            {
                map[x, y] = new Cell(CellType.Empty);
            }



        }

        public Game(int charNumber)
        {
            for (int i = 0; i < charNumber; i++)
            {
                map[map.XSize / 2, i * (map.YSize - 1)] = new Cell(CellType.WithCharacter);
                lst.Add(new Character(map.XSize / 2, i * (map.YSize - 1)));
                lst[i].CurrentCell = new Cell(CellType.Ship);
            }
        }
        private bool CanMoveInThatCell(GameMap map, Character ch)
        {
            if (map[ch.XCoordinate, ch.YCoordinate].Type == CellType.Water)
                return false;
            if (map[ch.XCoordinate, ch.YCoordinate].Type == CellType.WithCharacter)
                return false;
            if (map[ch.XCoordinate, ch.YCoordinate].Type == CellType.CharacterWithGold)
                return false;
            return true;
        }

        public EndTurnInfo Move(TurnInfo info)
        {
            if (info.CharacterID >= lst.Count)
                throw new ArgumentOutOfRangeException(String.Format("No Character with ID={0}", info.CharacterID));
            Character ch = lst[info.CharacterID];
            if (ch.MoveTo(info.MovingSide))
            {
                if (!CanMoveInThatCell(map, ch))
                {
                    ch.OpositeMove(info.MovingSide);
                }
                else
                {
                    RestoreCell(map, info.MovingSide, ch);
                    CheckActionsOnThatCell(map, ch);
                    SaveCurrentCell(map, ch);
                    map[ch.XCoordinate, ch.YCoordinate] = new Cell(ch.WithGold ? CellType.CharacterWithGold : CellType.WithCharacter);
                }
            }
            List<CharInfo> chrs = new List<CharInfo>();
            foreach (var item in lst)
            {
                chrs.Add(item.GetCharInfo());
            }
            return new EndTurnInfo(map, chrs.ToArray());
        }

        private void CheckActionsOnThatCell(GameMap map, Character ch)
        {
            int x = ch.XCoordinate, y = ch.YCoordinate;
            if (map[x, y].Type == CellType.Unreached)
                GenerateCell(map, x, y);
            if (map[x, y].Type == CellType.WithGold)
            {
                if (!ch.WithGold)
                {
                    ch.WithGold = true;
                    map[x, y] = new Cell(CellType.Empty);
                }
            }
            if (map[x, y].Type == CellType.Ship && ch.WithGold)
            {
                ch.WithGold = false;
                ch.TakeGold();
            }

            if (map[x, y].Type == CellType.WithCharacter || map[x, y].Type == CellType.CharacterWithGold)
            {
                var ch2 = FindCharacterByPosition(x, y);

            }

        }

        private Character FindCharacterByPosition(int x, int y)
        {
            foreach (var ch in lst)
            {
                if (ch.XCoordinate == x && ch.YCoordinate == y)
                    return ch;
            }
            return null;
        }


    }

    public class GameMap
    {
        public const int _xSize = 20;
        public const int _ySize = 20;
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
