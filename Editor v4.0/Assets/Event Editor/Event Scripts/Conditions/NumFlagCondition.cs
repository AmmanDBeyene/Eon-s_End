using Assets.Event_Scripts.Event_Commands;
using EECore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Event_Editor.Event_Scripts.Conditions
{
    public class NumFlagCondition : ConditionNode
    {
        [Serialize]
        public string _flag;

        [Serialize]
        public string _check;

        [Serialize]
        public int _value;

        public NumFlagCondition(string flag, string check, int value)
        {
            _flag = flag;
            _check = check;
            _value = value;
        }

        internal override bool IsMet()
        {
            if (!GameStateManager.flags.ContainsKey(_flag))
            {
                return false;
            }

            int lhs = _value;
            int rhs = GameStateManager.flags[_flag];

            //==,!=,<,>,>=,<=,
            switch (_check)
            {
                case "==":
                    return lhs == rhs;
                case "!=":
                    return lhs != rhs;
                case "<":
                    return lhs < rhs;
                case ">":
                    return lhs > rhs;
                case ">=":
                    return lhs >= rhs;
                case "<=":
                    return lhs <= rhs;
            }

            return false;
        }
    }
}
