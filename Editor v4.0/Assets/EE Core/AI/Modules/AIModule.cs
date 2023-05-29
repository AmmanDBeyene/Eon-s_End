using EECore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore.AI.Modules
{
    interface AIModule
    {
        public abstract IEnumerator DoTurn(Combatant cpu);
    }
}
