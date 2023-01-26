using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Event_Scripts.Event_Commands
{
    internal interface IEventCommand
    {  
        public void SetNext(IEventCommand command);
        public IEventCommand Update(EventNode caller);
    }
}
