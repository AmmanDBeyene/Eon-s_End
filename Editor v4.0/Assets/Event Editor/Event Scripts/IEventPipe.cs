

using Assets.Event_Scripts.Event_Commands;
using System.Collections.Generic;

namespace Assets.Event_Scripts
{
    public interface IEventPipe
    {
        public IEventPipe Flow();
        public List<IEventPipe> Next();
        public void PropogateController(EventController controller);
    }
}
