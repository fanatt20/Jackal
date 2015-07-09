using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackalEngine
{
    public class EndTurnInfo
    {
        public List<Cell> ChangedCells { get; private set; }
        public CharInfo[] CharInform { get; private set; }
        private EndTurnInfo() { }
        public EndTurnInfo(List<Cell> changedCells, params CharInfo[] array)
        {
            ChangedCells = changedCells;
            CharInform = new CharInfo[array.Length];
            array.CopyTo(CharInform, 0);

        }
    }
}
