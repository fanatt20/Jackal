using System.Collections.Generic;

namespace JackalEngine
{
    public class EndTurnInfo
    {
        private EndTurnInfo()
        {
        }

        public EndTurnInfo(List<Cell> changedCells, params CharInfo[] array)
        {
            ChangedCells = changedCells;
            CharInform = new CharInfo[array.Length];
            array.CopyTo(CharInform, 0);
        }

        public List<Cell> ChangedCells { get; private set; }
        public CharInfo[] CharInform { get; private set; }
    }
}