using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackalEngine.Interfaces
{
   public interface ICharacter
    {
        bool IsDead { get; }
        bool CanMove { get; }
        void SetItem(IItem item);
        IItem[] HaveItem { get; }
    }
}
