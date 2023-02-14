using Assets.Event_Scripts.Event_Commands;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Event_Scripts.Conditions
{
    public class InputCondition : ConditionNode
    {
        [Serialize]
        public readonly KeyCode _awaitedKey;

        [Serialize]
        public bool _pressed = false;

        public InputCondition(KeyCode awaitedKey, bool pressed)
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
