using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackalEngine
{
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
}
