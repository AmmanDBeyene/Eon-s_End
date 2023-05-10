using Assets.Event_Editor.Scripts;
using Assets.Event_Scripts;
using Assets.Event_Scripts.Event_Commands;
using EECore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Event_Scripts.Commands
{
    public class HideTextCommand : CommandNode
    {
        public HideTextCommand() { }

        internal override void DoCommand()
        {
            GameStateManager.dialogueBox.SetActive(false);
        }

        internal override bool IsComplete()
        {
            return true;
        }
    }
}
