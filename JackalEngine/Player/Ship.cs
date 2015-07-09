using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackalEngine
{
    internal class Ship
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public List<Character> Crew { get; private set; }


    }
}
