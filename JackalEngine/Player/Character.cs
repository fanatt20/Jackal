using System;

namespace JackalEngine
{
    internal class Character
    {
        public Cell CurrentCell;

        private Character()
        {
        }

        public Character(int xCoordinate, int yCoordinate)
        {
            CurrentCell = new Cell(CellType.Water);
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            WithGold = false;
        }

        public int Gold { get; private set; }
        public int Death { get; private set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public bool WithGold { get; set; }

        public CharInfo GetCharInfo()
        {
            return new CharInfo(Gold, Death, WithGold);
        }

        public void Die(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Death++;
        }

        public void TakeGold()
        {
            Gold++;
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
            }
            return true;
        }
    }
}