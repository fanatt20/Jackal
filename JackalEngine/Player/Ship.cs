using System.Collections.Generic;

namespace JackalEngine
{
    internal class Ship
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public List<Character> Crew { get; private set; }
    }
}