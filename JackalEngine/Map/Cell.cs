using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JackalEngine.Map;
using JackalEngine.Interfaces;

namespace JackalEngine.Map
{
    class Cell : ICell
    {

        public bool IsOpenend
        {
            get;
            private set;
        }

        public int XCoordinate
        {
            get;
            private set;
        }

        public int YCoordinate
        {
            get;
            private set;
        }

        public ICellType Type
        {
            get;
            private set;
        }

        public IItem[] HaveItems
        {
            get{
                return items.ToArray();
            }
        }
        private List<IItem> items;
    }
}
