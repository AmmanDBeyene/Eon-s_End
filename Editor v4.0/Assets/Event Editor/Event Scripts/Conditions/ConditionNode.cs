using Assets.Event_Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Event_Editor.Event_Scripts;

namespace Assets.Event_Scripts.Event_Commands
{
    public abstract class ConditionNode : BlockNode
    {
        public ConditionNode() : base() { }
        public ConditionNode(IEventPipe next) : base(next) { }
        internal abstract bool IsMet();
    }
}