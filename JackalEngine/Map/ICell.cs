using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JackalEngine.Map;

namespace JackalEngine.Interfaces
{
    public interface ICell
    {
        bool IsOpenend { get; }
        int XCoordinate { get; }
        int YCoordinate { get; }
        ICellType Type { get; }
         IItem[] HaveItems{get;}

    }
}
