using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackalEngine.Interfaces
{
   public interface IMapGenerator
    {
        ICell GenerateCell(IMap map);
    }
}
