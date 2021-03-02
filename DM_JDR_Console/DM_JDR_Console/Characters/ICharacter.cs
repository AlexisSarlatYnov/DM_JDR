using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_JDR_Console.Characters
{
    interface ICharacter
    {
        void Power(List<Character> characters);
        void Passive();
    }
}
