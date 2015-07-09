using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackalEngine
{
    public class CharInfo
    {
        public int Death { get; private set; }
        public int Gold { get; private set; }
        public bool WithGold { get; private set; }
        private CharInfo() { }
        public CharInfo(int gold, int death, bool withGold)
        {
            Death = death;
            Gold = gold;
            WithGold = withGold;

        }
    }
}
