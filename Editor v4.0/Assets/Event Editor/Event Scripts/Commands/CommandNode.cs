
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Event_Editor.Event_Scripts;

namespace Assets.Event_Scripts.Event_Commands
{
    public abstract class CommandNode : BlockNode
    {
        public CommandNode() : base() { }
        public CommandNode(IEventPipe next) : base(next) { }
        internal abstract bool IsComplete();
        internal abstract void DoCommand();
    }
}
