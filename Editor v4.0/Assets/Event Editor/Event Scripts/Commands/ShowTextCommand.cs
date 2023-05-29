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
    public class ShowTextCommand : CommandNode
    {
        [Serialize]
        public string _name { get; set; }

        [Serialize]
        public Texture2D _portrait { get; set; }

        [Serialize]
        public bool _positionLeft { get; set; }

        [Serialize]
        public string _text { get; set; }

        public ShowTextCommand(string name, Texture2D portrait, bool positionLeft, string text)
        {
            _name = name;
            _portrait = portrait;
            _positionLeft = positionLeft;
            _text = text;
        }

        internal override void DoCommand()
        {
            GameStateManager.dialogueBox.SetActive(true);
            UIDocument dbox = GameStateManager.dialogueBox.GetComponent<UIDocument>();
            Label lbl = (Label)dbox.rootVisualElement.Find("MainText");
            dbox.rootVisualElement.Find("Action1").Find("ActionLabel");
            lbl.text = _text;
        }

        internal override bool IsComplete()
        {
            return true;
        }
    }
}
