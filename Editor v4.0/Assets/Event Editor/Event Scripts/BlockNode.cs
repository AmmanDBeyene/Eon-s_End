using Assets.Event_Scripts;
using Unity.VisualScripting;

namespace Assets.Event_Editor.Event_Scripts
{
    public abstract class BlockNode
    {
        [Serialize]
        public IEventPipe next { get; protected set; }

        public BlockNode() : this(null) { }
        public BlockNode(IEventPipe next)
        {
            this.next = next;
        }

        internal void ConnectTo(IEventPipe next)
        {
            this.next = next;
        }
    }
}
