using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JackalEngine;

namespace JackalEngine
{
    public class Cell
    {
        public int XCoord { get; internal set; }
        public int YCoord { get; internal set; }
        public CellType Type { get; private set; }
        public Cell()
        {
            Type = CellType.Hidden;
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
