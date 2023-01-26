using System;
using UnityEngine;

namespace Assets.Event_Scripts.Conditions
{
    internal class InputCondition : IEventCondition
    {
        private readonly KeyCode _awaitedKey;

        public InputCondition(KeyCode awaitedKey)
        {
            _awaitedKey = awaitedKey;
        }
        public bool IsMet()
        {
            return Input.GetKeyDown(_awaitedKey);
        }
    }
}
