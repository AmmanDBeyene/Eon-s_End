using Assets.Event_Editor.Scripts;
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
    public class SelectOptionCommand : CommandNode
    {
        [Serialize]
        public string _optionToSelect { get; set; }

        public SelectOptionCommand(string optionToSelect)
        {
            _optionToSelect = optionToSelect;
        }

        private void Select(VisualElement ve)
        {
            ve.style.BorderColor(Color.white);
            ve.style.BorderWidth(1);
            ve.style.backgroundColor = new Color(1, 1, 1, 46.0f / 255.0f);
        }

        private void Deselect(VisualElement ve)
        {
            ve.style.BorderWidth(0);
            ve.style.backgroundColor = new Color(0, 0, 0, 0);
        }

        internal override void DoCommand()
        {
            GameStateManager.dialogueBox.SetActive(true);
            UIDocument dbox = GameStateManager.dialogueBox.GetComponent<UIDocument>();

            VisualElement option1 = dbox.rootVisualElement.Find("Option1");
            VisualElement option2 = dbox.rootVisualElement.Find("Option2");
            VisualElement option3 = dbox.rootVisualElement.Find("Option3");

            if (_optionToSelect == "Option 1")
            {
                Select(option1);
                Deselect(option2);
                Deselect(option3);
            } else if (_optionToSelect == "Option 2")
            {
                Select(option2);
                Deselect(option1);
                Deselect(option3);
            } else if (_optionToSelect == "Option 3")
            {
                Select(option3);
                Deselect(option2);
                Deselect(option1);
            }

        }

        internal override bool IsComplete()
        {
            return true;
        }
    }
}
