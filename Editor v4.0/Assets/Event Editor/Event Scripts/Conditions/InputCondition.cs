using Assets.Event_Scripts.Event_Commands;
using System;
using UnityEngine;

namespace Assets.Event_Scripts.Conditions
{
    internal class InputCondition : ConditionNode
    {
        private readonly KeyCode _awaitedKey;
        private bool _pressed = false;

        public InputCondition(IEventPipe next, KeyCode awaitedKey, bool pressed) : base(next)
        {
            _awaitedKey = awaitedKey;
            _pressed = pressed;
        }
        internal override bool IsMet()
        {
            return _pressed ? Input.GetKeyDown(_awaitedKey) : Input.GetKeyUp(_awaitedKey);
        }
    }
}
