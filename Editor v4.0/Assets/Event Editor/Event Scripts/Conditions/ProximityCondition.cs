
using System;
using UnityEngine;
using Assets.Event_Scripts.Event_Commands;
using Unity.VisualScripting;
using EECore;

namespace Assets.Event_Scripts.Conditions
{
    public class ProximityCondition : ConditionNode
    {
        [Serialize]
        public GameObject _gameObjectFrom;

        [Serialize]
        public GameObject _gameObjectTo;

        [Serialize]
        public float _triggerLimit;

        [Serialize]
        public bool _inside;

        public ProximityCondition(float limit, bool inside)
        {
            _triggerLimit = limit;
            _inside = inside;   
        }

        internal override bool IsMet()
        {
            _gameObjectFrom = controller.Self();
            _gameObjectTo = GameStateManager.player;

            if (_gameObjectTo == null || _gameObjectFrom == null)
            {
                return false;
            }

            double distance = (_gameObjectFrom.transform.position - _gameObjectTo.transform.position).magnitude;

            return _inside ? distance <= _triggerLimit : distance > _triggerLimit;
        }
    }
}
