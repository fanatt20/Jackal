using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace JackalEngine
{
    internal class Ship
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public List<Character> Crew { get { return _crew.ToList(); } }
        private readonly List<Character> _crew;

        public void KillCharacter(Character character)
        {
            if (!Crew.Contains(character))
                throw new ArgumentException("No such member on this Ship");
            var index = Crew.IndexOf(character);
            Crew[index].Die(XCoordinate, YCoordinate);
        }
        public int TotalGold()
        {
            int result = 0;
            foreach (var character in _crew)
            {
                result += character.Gold;
            }
            return result;
        }

        private Ship()
        {

        }
        public Ship(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            _crew = new List<Character> { new Character(xCoordinate, yCoordinate) { CurrentCell = new Cell(CellType.Ship) } };


        }
    }
}