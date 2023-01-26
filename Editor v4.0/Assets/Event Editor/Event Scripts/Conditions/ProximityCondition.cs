using System;
using UnityEngine;

namespace Assets.Event_Scripts.Conditions
{
    internal class ProximityCondition : IEventCondition
    {
        private GameObject _gameObjectFrom;
        private GameObject _gameObjectTo;
        private double _triggerLimit;

        public ProximityCondition(GameObject from, GameObject to, double limit)
        {
            _gameObjectFrom = from;
            _gameObjectTo = to;
            _triggerLimit = limit;
        }

        public bool IsMet()
        {
            double distance = (_gameObjectFrom.transform.position - _gameObjectTo.transform.position).magnitude;
            return distance <= _triggerLimit;
        }
    }
}
