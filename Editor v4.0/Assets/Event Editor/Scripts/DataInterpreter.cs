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
using UnityEditor;
using Assets.Event_Editor.Event_Scripts.Conditions;

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

            else if (type == typeof(HideTextCommand))
            {
                return ToHideTextCommand(ve);
            }

            else if (type == typeof(SceneSwitchCommand))
            {
                return ToSceneSwitchCommand(ve);
            }

            else if (type == typeof(StartCombatCommand))
            {
                return ToStartCombatCommand(ve);
            }
            
            else if (type == typeof(ShowOptionCommand))
            {
                return ToShowOptionCommand(ve);
            }

            else if (type == typeof(SelectOptionCommand))
            {
                return ToSelectOptionCommand(ve);
            } 

            else if (type == typeof(SetFlagCommand))
            {
                return ToSetFlagCommand(ve);
            }

            else if (type == typeof(ControlPrefabCommand))
            {
                return ToControlPrefabCommand(ve);
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

            else if (type == typeof(NumFlagCondition))
            {
                return ToNumFlagCondition(ve);
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
            if (type == typeof(StartCombatCommand))
            {
                ve.SetupStartCombatCommand();
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

            else if (type == typeof(HideTextCommand))
            {
                ((HideTextCommand)node).RestoreTo(ve);
            }

            else if (type == typeof(SceneSwitchCommand))
            {
                ((SceneSwitchCommand)node).RestoreTo(ve);
            }

            else if (type == typeof(StartCombatCommand))
            {
                ((StartCombatCommand)node).RestoreTo(ve);
            }
            
            else if (type == typeof(ShowOptionCommand))
            {
                ((ShowOptionCommand)node).RestoreTo(ve);
            }
            
            else if (type == typeof(SelectOptionCommand))
            {
                ((SelectOptionCommand)node).RestoreTo(ve);
            }

            else if (type == typeof(SetFlagCommand))
            {
                ((SetFlagCommand)node).RestoreTo(ve);
            }

            else if (type == typeof(ControlPrefabCommand))
            {
                ((ControlPrefabCommand)node).RestoreTo(ve);
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

            else if (type == typeof(NumFlagCondition))
            {
                ((NumFlagCondition)node).RestoreTo(ve);
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

        private static HideTextCommand ToHideTextCommand(VisualElement ve)
        {
            return new HideTextCommand();
        }

        private static void RestoreTo(this HideTextCommand cmd, VisualElement ve)
        {
            // do literally nothing as there's nothing to do. 
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
            ve.SetDropdownValue("1", cmd._targetSceneName);
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
                }
            }

            Button b = (Button)ve.Find("3");
            b.clicked += () =>
            {
                foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
                {
                    string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                    name = name.Substring(0, name.Length - 6);
                    if (df.value == name)
                    {
                        // this is going to be the scene that we try to load in 
                        StaticEditor.OpenSceneForPointSelection(S.path, ve, "2");
                    }
                }
            };
        }

        private static StartCombatCommand ToStartCombatCommand(VisualElement ve)
        {
            return new StartCombatCommand(
                    ve.GetDropdownValue("1"),
                    ve.GetDropdownValue("2"),
                    ve.GetVector3FieldValue("3"),
                    ve.GetDropdownValue("4"),
                    ve.GetVector3FieldValue("5")
            );
        }

        private static void RestoreTo(this StartCombatCommand cmd, VisualElement ve)
        {
            ve.SetDropdownValue("1", cmd._targetSceneName);
            ve.SetDropdownValue("2", cmd._targetVSceneName);
            ve.SetVector3FieldValue("3", cmd._targetVPosition);
            ve.SetDropdownValue("4", cmd._targetDSceneName);
            ve.SetVector3FieldValue("5", cmd._targetDPosition);
        }

        private static void SetupStartCombatCommand(this VisualElement ve)
        {
            DropdownField df1 = (DropdownField)ve.Find("1");
            DropdownField df2 = (DropdownField)ve.Find("2");
            DropdownField df3 = (DropdownField)ve.Find("4");

            df1.choices.Clear();
            df2.choices.Clear();
            df3.choices.Clear();

            foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
            {
                if (S.enabled)
                {
                    string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                    name = name.Substring(0, name.Length - 6);
                    df1.choices.Add(name);
                    df2.choices.Add(name);
                    df3.choices.Add(name);
                }
            }

            Button b1 = (Button)ve.Find("6");
            Button b2 = (Button)ve.Find("7");
            b1.clicked += () =>
            {
                foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
                {
                    string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                    name = name.Substring(0, name.Length - 6);
                    if (df2.value == name)
                    {
                        // this is going to be the scene that we try to load in 
                        StaticEditor.OpenSceneForPointSelection(S.path, ve, "3");
                    }
                }
            };
            b2.clicked += () =>
            {
                foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
                {
                    string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                    name = name.Substring(0, name.Length - 6);
                    if (df3.value == name)
                    {
                        // this is going to be the scene that we try to load in 
                        StaticEditor.OpenSceneForPointSelection(S.path, ve, "5");
                    }
                }
            };


        }

        private static ShowOptionCommand ToShowOptionCommand(VisualElement ve)
        {
            return new ShowOptionCommand(
                ve.GetToggleValue("1"),
                ve.GetTextFieldValue("4"),
                ve.GetToggleValue("2"),
                ve.GetTextFieldValue("5"),
                ve.GetToggleValue("3"),
                ve.GetTextFieldValue("6")
            );
        }

        private static void RestoreTo(this ShowOptionCommand cmd, VisualElement ve)
        {
            ve.SetToggleValue("1", cmd._showFirst);
            ve.SetToggleValue("2", cmd._showSecond);
            ve.SetToggleValue("3", cmd._showThird);
            ve.SetTextFieldValue("4", cmd._textFirst);
            ve.SetTextFieldValue("5", cmd._textSecond);
            ve.SetTextFieldValue("6", cmd._textThird);
        }

        private static SelectOptionCommand ToSelectOptionCommand(VisualElement ve)
        {
            return new SelectOptionCommand(
                ve.GetRadioButtonGroupValue("1")
            );
        }

        private static void RestoreTo(this SelectOptionCommand cmd, VisualElement ve)
        {
            ve.SetRadioButtonGroupValue("1", cmd._optionToSelect);
        }

        private static SetFlagCommand ToSetFlagCommand(VisualElement ve)
        {
            return new SetFlagCommand(
                ve.GetTextFieldValue("1"),
                ve.GetIntFieldValue("2")
            );
        }

        private static void RestoreTo(this SetFlagCommand cmd, VisualElement ve)
        {
            ve.SetTextFieldValue("1", cmd._flag);
            ve.SetIntFieldValue("2", cmd._value);
        }

        private static ControlPrefabCommand ToControlPrefabCommand(VisualElement ve)
        {
            return new ControlPrefabCommand(
                ve.GetTextFieldValue("1"),
                ve.GetVector3FieldValue("2")
            );
        }

        private static void RestoreTo(this ControlPrefabCommand cmd, VisualElement ve)
        {
            ve.SetTextFieldValue("1", cmd._name);
            ve.SetVector3FieldValue("2", cmd._position);
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

        private static NumFlagCondition ToNumFlagCondition(VisualElement ve)
        {
            return new NumFlagCondition(
                ve.GetTextFieldValue("1"),
                ve.GetDropdownValue("2"),
                ve.GetIntFieldValue("3")
            );
        }

        private static void RestoreTo(this NumFlagCondition cnd, VisualElement ve)
        {
            ve.SetTextFieldValue("1", cnd._flag);
            ve.SetDropdownValue("2", cnd._check);
            ve.SetIntFieldValue("3", cnd._value);
        }

        #endregion
    }
}
