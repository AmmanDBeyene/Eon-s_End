
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Event_Scripts;
using Assets.Event_Scripts.Event_Commands;

namespace Assets.Event_Editor.Event_Scripts
{
    internal abstract class CommandPipeSystem : IEventPipe
    {
        public CommandNode command { get; private set; }
        private bool _active { get; set; } 
        public CommandPipeSystem(CommandNode command)
        {
            this.command = command;

            _active = false;
        }
        public IEventPipe Flow()
        {
            if (!_active)
            {
                command.DoCommand();
                _active = true;
            }

            if (_active && command.IsComplete())
            {
                _active = false; 
                return command.next;
            }

            return this;
        }
    }
}
