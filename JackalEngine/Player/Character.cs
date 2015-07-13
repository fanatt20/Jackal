using System;

namespace JackalEngine
{
    internal class Character:Point,IEquatable<Character>
    {
        public Cell CurrentCell;

        private Character() 
        {

        }

        public Character(int x, int y) : base(x,y)
        {
            CurrentCell = new Cell(CellType.Water);
            WithGold = false;
        }

        public int Gold { get; private set; }
        public int Death { get; private set; }

        public bool WithGold { get; internal set; }

        public CharInfo GetCharInfo()
        {
            return new CharInfo(Gold, Death, WithGold);
        }

        internal void Die(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
            Death++;
        }

        internal void TakeGold()
        {
            Gold++;
        }

        internal Point GetPoint()
        {
            return new Point(X,Y);
        }

        internal void ApplyPoint(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public bool Equals(Character other)
        {
            return (X == other.X && Y == other.Y && Gold == other.Gold && Death == other.Death);
        }
    }
}