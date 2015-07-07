using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JackalEngine.Interfaces
{
  public  interface IPlayer
    {
        ICharacter[] GetCharactersCollection();
        int PlayerGold { get; }
        ICharacter this[int index] { get; }

    }
}
