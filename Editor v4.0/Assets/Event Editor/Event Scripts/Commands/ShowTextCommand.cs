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
            VisualElement root = dbox.rootVisualElement;
            Label content = (Label)root.Find("MainText");
            content.text = _text;

            VisualElement portraitBackground = root.Find("PortraitBackground");
            VisualElement leftFiller = root.Find("LeftFiller");
            VisualElement portrait = root.Find("Portrait");

            string cname = _name.ToLower();
            _portrait = null;

            if (cname == "(you)" || cname == "you")
            {
                _portrait = GameStateManager.youPort;
            }
            if (cname.Contains("bear") && cname.Contains("despair"))
            {
                _portrait = GameStateManager.bearPort;
            }
            if (cname.Contains("demon"))
            {
                _portrait = GameStateManager.demonPort;
            }

            if (_portrait == null)
            {
                portraitBackground.style.display = DisplayStyle.None;
                leftFiller.style.display = DisplayStyle.None;
            } else
            {
                portraitBackground.style.display = DisplayStyle.Flex;
                leftFiller.style.display = DisplayStyle.Flex;
                portrait.style.backgroundImage = _portrait;
            }

            Label name = (Label)root.Find("CharName");
            name.text = _name;
        }

        internal override bool IsComplete()
        {
            return true;
        }
    }
}
