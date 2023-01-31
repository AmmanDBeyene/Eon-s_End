using Assets.Event_Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Event_Scripts.Event_Commands
{
    internal abstract class ConditionNode
    {
        public IEventPipe next { get; private set; }
        public ConditionNode(IEventPipe next)
        {
            this.next = next;
        }

        internal abstract bool IsMet();
    }
}