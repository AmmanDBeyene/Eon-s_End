
using System;
using UnityEngine;
using Assets.Event_Scripts.Event_Commands;
using Unity.VisualScripting;

namespace Assets.Event_Scripts.Conditions
{
    public class ProximityCondition : ConditionNode
    {
        [Serialize]
        public GameObject _gameObjectFrom;

        [Serialize]
        public GameObject _gameObjectTo;

        [Serialize]
        public double _triggerLimit;

        [Serialize]
        public bool _inside;

        public ProximityCondition(GameObject from, GameObject to, double limit, bool inside)
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
