using Assets.Event_Scripts.Event_Commands;
using EECore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Event_Editor.Event_Scripts.Commands
{
    public class SetFlagCommand : CommandNode
    {
        [Serialize]
        public string _flag;

        [Serialize]
        public int _value;

        public SetFlagCommand(string flag, int value)
        {
            _flag = flag;
            _value = value;
        }

        internal override void DoCommand()
        {
            GameStateManager.flags[_flag] = _value;
        }

        internal override bool IsComplete()
        {
            return true;
        }
    }
}
