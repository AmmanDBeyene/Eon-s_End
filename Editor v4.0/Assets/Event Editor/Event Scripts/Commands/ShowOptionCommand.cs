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
    public class ShowOptionCommand : CommandNode
    {
        [Serialize]
        public bool _showFirst { get; set; }

        [Serialize]
        public string _textFirst { get; set; }

        [Serialize]
        public bool _showSecond { get; set; }

        [Serialize]
        public string _textSecond { get; set; }

        [Serialize]
        public bool _showThird { get; set; }

        [Serialize]
        public string _textThird { get; set; }

        public ShowOptionCommand(bool showFirst, string textFirst, bool showSecond, string textSecond, bool showThird, string textThird)
        {
            _showFirst = showFirst;
            _textFirst = textFirst;
            _showSecond = showSecond;
            _textSecond = textSecond;
            _showThird = showThird;
            _textThird = textThird;
        }

        internal override void DoCommand()
        {
            GameStateManager.dialogueBox.SetActive(true);
            UIDocument dbox = GameStateManager.dialogueBox.GetComponent<UIDocument>();

            VisualElement option1 = dbox.rootVisualElement.Find("Option1");
            VisualElement option2 = dbox.rootVisualElement.Find("Option2"); 
            VisualElement option3 = dbox.rootVisualElement.Find("Option3");

            Label text1 = (Label)option1.Find("OptionText1");
            Label text2 = (Label)option2.Find("OptionText1");
            Label text3 = (Label)option3.Find("OptionText1");

            text1.text = _textFirst;
            text2.text = _textSecond;
            text3.text = _textThird;

            option1.style.display = _showFirst ? DisplayStyle.Flex : DisplayStyle.None;
            option2.style.display = _showSecond ? DisplayStyle.Flex : DisplayStyle.None;
            option3.style.display = _showThird ? DisplayStyle.Flex : DisplayStyle.None;
        }

        internal override bool IsComplete()
        {
            return true;
        }
    }
}
