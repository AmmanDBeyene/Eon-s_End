using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Event_Scripts.Event_Commands
{
    internal abstract class CommandNode
    {
        public IEventPipe next { get; private set; }

        public CommandNode(IEventPipe next)
        {
            this.next = next;
        }

        internal abstract bool IsComplete();
        internal abstract void DoCommand();
    }
}
