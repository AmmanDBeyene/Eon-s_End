using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Event_Scripts.Event_Commands
{
    internal abstract class EventCommand : IEventCommand
    {
        private bool _active;
        public bool Complete { get; private set; }

        public List<IEventCondition> Conditions { get; private set; }

        public IEventCommand Next { get; protected set; }

        protected EventNode Caller { get; set; }

        public EventCommand() :this(null) { }

        public EventCommand(IEventCommand next)
        {
            _active = false;
            Complete = false;
            Conditions = new List<IEventCondition>();
            Next = next;
        }

        public IEventCommand Update(EventNode caller)
        {
            Caller = caller;

            // if update is called with the event completed this *probably*
            // means that we want the event to reset its state.
            if (Complete)
            {
                // reset state
                _active = false;
                Complete = false;
            }

            // check state
            if (!_active && ConditionsMet())
            {
                // if we arent active but all of our conditions are met 
                // our event command should be activated.
                _active = true; // event activated
                Complete = false; // just in case
                DoCommand();
            }

            // if a command is async and completes automatically this will prevent
            // there from being an extra update call before the event
            // is marked as complete. 

            if (_active && IsCommandComplete())
            {
                // if we are active and our command is complete 
                // our event command is complete.
                Complete = true;

                // signal that this event is completed and we should
                // move onto the next event.
                return Next;
            }

            // signal that this event is not over and still needs some waiting.
            return (IEventCommand) this;
        }

        public void SetNext(IEventCommand command)
        {
            Next = command;
        }

        private bool ConditionsMet()
        {
            foreach (IEventCondition condition in Conditions)
            {
                if (!condition.IsMet())
                {
                    return false;
                }
            }
            return true;
        }

        abstract protected bool IsCommandComplete();

        abstract protected void DoCommand();
    }
}
