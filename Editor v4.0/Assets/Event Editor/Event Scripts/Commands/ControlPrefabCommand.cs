using Assets.Event_Scripts.Event_Commands;
using EECore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Event_Editor.Event_Scripts.Commands
{
    internal class ControlPrefabCommand : CommandNode
    {
        [Serialize]
        public string _name;

        [Serialize]
        public Vector3 _position;

        public ControlPrefabCommand(string name, Vector3 position)
        {
            _name = name;
            _position = position;
        }

        internal override void DoCommand()
        {
            GameObject go = GameObject.Find(_name);
            if (go == null)
            {
                return;
            }

            go.transform.position = _position;
        }

        internal override bool IsComplete()
        {
            return true;
        }
    }
}
