
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Event_Scripts;
using Assets.Event_Scripts.Event_Commands;
using Unity.VisualScripting;

namespace Assets.Event_Editor.Event_Scripts
{
    internal class ConditionPipeSystem : IEventPipe
    {
        [Serialize]
        public List<ConditionNode> conditions { get; private set; }

        public ConditionPipeSystem()
        {
            conditions = new List<ConditionNode>();
        }

        public IEventPipe Flow()
        {
            foreach (ConditionNode condition in conditions)
            {
                if (condition.IsMet())
                {
                    return condition.next;
                }
            }

            return this;
        }

        public List<IEventPipe> Next()
        {
            List<IEventPipe> toReturn = new List<IEventPipe>();
            conditions.ForEach(i => toReturn.Add(i.next));
            return toReturn;
        }

        public void PropogateController(EventController controller)
        {
            conditions.ForEach(i => i.PropogateController(controller));
        }
    }
}
