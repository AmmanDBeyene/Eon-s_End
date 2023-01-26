

using Assets.Event_Scripts.Event_Commands;
using System.Collections.Generic;

namespace Assets.Event_Scripts
{
    internal class EventNode
    {
        private List<IEventCommand> _commands = new List<IEventCommand>();

        private IEventCommand _currentCommand = null;

        // bool to prohibit manipulation of command chain during runtime
        private bool _running = false; 

        public EventNode Next = null;

        public bool Complete { get; protected set; } = false;
        
        public EventNode() { }
        
        public void AddEventCommand(IEventCommand command)
        {
            if (_running)
            {
                return;
            }

            if (_currentCommand == null)
            {
                _currentCommand = command;
            }

            _commands.Add(command);
            UpdateCommandConnections();
        }
        
        public void Update()
        {
            if (_currentCommand == null)
            {
                return; // if we have run out of commands to do .. we have run out of commands
                        // dont do anything else. (also if this isnt here errors will occur)
            }

            _running = true;
            _currentCommand = _currentCommand.Update(this);

            // if we have run out of commands to proccess stop proccessing commands
            if (_currentCommand == null)
            {
                Complete = true; 
            }
        }

        private void UpdateCommandConnections()
        {
            if (_running || _commands.Count == 0)
            {
                return;
            }
            // loop through elements in reverse
            for (int i = _commands.Count - 2; i >= 0; i--)
            {
                IEventCommand command = _commands[i];
                IEventCommand nextCommand = _commands[i + 1];

                // connect command nodes
                command.SetNext(nextCommand);
            }
        }
    }
}
