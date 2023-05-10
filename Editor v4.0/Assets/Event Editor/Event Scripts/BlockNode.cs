using Assets.Event_Scripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Event_Editor.Event_Scripts
{
    public abstract class BlockNode
    {
        [Serialize]
        public IEventPipe next { get; protected set; }
        public EventController controller { get; protected set; }

        public BlockNode() : this(null) { }
        public BlockNode(IEventPipe next)
        {
            this.next = next;
        }

        internal void ConnectTo(IEventPipe next)
        {
            this.next = next;
        }

        internal void PropogateController(EventController controller)
        {
            Debug.Log("Propogating ...", controller);
            // Make sure the controller propogation eventually concludes. 
            if (this.controller != null)
            {
                return;
            }

            this.controller = controller;

            // propogate through next pipe
            next.PropogateController(controller);
        }
    }
}
