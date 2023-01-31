

using Assets.Event_Scripts.Event_Commands;
using System.Collections.Generic;

namespace Assets.Event_Scripts
{
    internal interface IEventPipe
    {
        public IEventPipe Flow();
    }
}
