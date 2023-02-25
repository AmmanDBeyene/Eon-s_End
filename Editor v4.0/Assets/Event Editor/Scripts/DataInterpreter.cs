using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine.UIElements;
using UnityEngine;

using Assets.Event_Scripts.Event_Commands;
using Assets.Event_Scripts.Conditions;
using Assets.Event_Editor.Event_Scripts;
using Assets.Event_Editor.Event_Scripts.Commands;

namespace Assets.Event_Editor.Scripts
{
    public static class DataInterpreter
    {
        public static object InterpretAs(this VisualElement ve, Type type)
        {
            // Commands
            if (type == typeof(ShowTextCommand))
            {
                return ToShowTextCommand(ve);
            }

            else if (type == typeof(SceneSwitchCommand))
            {
                return ToSceneSwitchCommand(ve);
            }

            // Conditions
            else if (type == typeof(InputCondition))
            {
                return ToInputCondition(ve);
            }

            else if (type == typeof(ProximityCondition))
            {
                return ToProximityCondition(ve);
            }

            return null;
        }

        public static void SetUp(this VisualElement ve, Type type)
        {
            if (type == typeof(SceneSwitchCommand))
            {
                ve.SetupSceneSwitchCommand();
                return;
            }
        }

        public static void RestoreTo(this BlockNode node, VisualElement ve, Type type)
        {
            // Commands
            if (type == typeof(ShowTextCommand))
            {
                ((ShowTextCommand)node).RestoreTo(ve);
            }

            else if (type == typeof(SceneSwitchCommand))
            {
                ((SceneSwitchCommand)node).RestoreTo(ve);
            }

            // Conditions
            else if (type == typeof(InputCondition))
            {
                ((InputCondition)node).RestoreTo(ve);
            }

            else if (type == typeof(ProximityCondition))
            {
                ((ProximityCondition)node).RestoreTo(ve);
            }

            // Restoration Complete
        }

        #region Commands

        private static ShowTextCommand ToShowTextCommand(VisualElement ve)
        {
            return new ShowTextCommand(
                ve.GetTextFieldValue("1"),
                (Texture2D) ve.GetObjectFieldValue("2"),
                ve.GetRadioButtonGroupValue("3") == "Left",
                ve.GetTextFieldValue("4")
            );
        }

        private static void RestoreTo(this ShowTextCommand cmd, VisualElement ve)
        {
            ve.SetTextFieldValue("1", cmd._name);
            ve.SetObjectFieldValue("2", cmd._portrait);
            ve.SetRadioButtonGroupValue("3", cmd._positionLeft ? "Left" : "Right");
            ve.SetTextFieldValue("4", cmd._text);
        }


        private static SceneSwitchCommand ToSceneSwitchCommand(VisualElement ve)
        {
            return new SceneSwitchCommand(
                    ve.GetDropdownValue("1"),
                    ve.GetVector3FieldValue("2")
            );
        }

        private static void RestoreTo(this SceneSwitchCommand cmd, VisualElement ve)
        {
            ve.SetTextFieldValue("1", cmd._targetSceneName);
            ve.SetVector3FieldValue("2", cmd._targetPlayerPosition);
        }

        private static void SetupSceneSwitchCommand(this VisualElement ve)
        {
            DropdownField df = (DropdownField)ve.Find("1");
            
            df.choices.Clear();

            foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
            {
                if (S.enabled)
                {
                    string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                    name = name.Substring(0, name.Length - 6);
                    df.choices.Add(name);
                    Debug.Log(name);
                }
            }
        }

        #endregion

        #region Conditions

        private static InputCondition ToInputCondition(VisualElement ve)
        {
            return new InputCondition(
                (KeyCode) Enum.Parse(typeof(KeyCode), ve.GetDropdownValue("1")),
                ve.GetDropdownValue("3") == "Pressed"
            );
        }

        private static void RestoreTo(this InputCondition cnd, VisualElement ve)
        {
            ve.SetDropdownValue("1", $"{cnd._awaitedKey}");
            ve.SetDropdownValue("3", cnd._pressed ? "Pressed" : "Released");
        }

        private static ProximityCondition ToProximityCondition(VisualElement ve)
        {
            return new ProximityCondition(
                ve.GetFloatFieldValue("2"),
                ve.GetDropdownValue("1") == "inside"
            );
        }

        private static void RestoreTo(this ProximityCondition cnd, VisualElement ve)
        {
            ve.SetDropdownValue("1", cnd._inside ? "inside" : "outside");
            ve.SetFloatFieldValue("2", cnd._triggerLimit);
        }

        #endregion
    }
}
