using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackalEngine.Interfaces
{
    public interface IMap
    {
        ICell[] GetCellsColletion();
        ICell this[int xCoordinate,int yCoordinate] { get; }

    }
}
