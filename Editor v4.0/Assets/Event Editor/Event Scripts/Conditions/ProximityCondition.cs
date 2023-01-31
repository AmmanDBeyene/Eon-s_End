
using System;
using UnityEngine;
using Assets.Event_Scripts.Event_Commands;

namespace Assets.Event_Scripts.Conditions
{
    internal class ProximityCondition : ConditionNode
    {
        private GameObject _gameObjectFrom;
        private GameObject _gameObjectTo;
        private double _triggerLimit;
        private bool _inside;

        public ProximityCondition(IEventPipe next, GameObject from, GameObject to, double limit, bool inside) : base(next)
        {
            _gameObjectFrom = from;
            _gameObjectTo = to;
            _triggerLimit = limit;
            _inside = inside;   
        }

        internal override bool IsMet()
        {
            double distance = (_gameObjectFrom.transform.position - _gameObjectTo.transform.position).magnitude;

            return _inside ? distance <= _triggerLimit : distance > _triggerLimit;
        }
    }
}
