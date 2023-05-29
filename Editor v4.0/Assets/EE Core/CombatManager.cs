using Assets.Event_Editor.Scripts;
using EECore.Enums;
using EECore.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace EECore
{
    internal static class CombatManager
    {
        internal static List<Combatant> combatants = new List<Combatant>();

        private static int currentCombatant = -1;
        internal static List<Combatant> turnOrder = new List<Combatant>();

        internal static GameObject targetingObject = null;

        // this needs to be set at runtime to a game object
        internal static GameObject targetBox = null;

        internal static string uiMode = "";

        internal static GameObject tileTargetObject = null;
        internal static GameObject unitTargetObject = null;
        internal static GameObject unitTargetOptionObject = null;
        internal static GameObject moveStraightObject = null;
        internal static GameObject moveOverObject = null;
        internal static GameObject moveCornerObject = null;
        internal static GameObject moveArrowObject = null;
        internal static GameObject moveStartObject = null;
        internal static UIDocument combatUIDocument = null;
        internal static GameObject combatantSelectorObject = null;
        internal static GameObject combatantHpBar = null;

        internal static Texture2D playerBackground = null;

        internal static void AddCombatant(Character character, GameObject gameObject)
        {
            // Check if combatant has already been added to the list. 
            Combatant repeat = combatants.Find(i => i.character == character);

            if (repeat != null)
            {
                return; // Combatant already exists in combatanat list. 
            }

            combatants.Add(new Combatant(character, gameObject));
        }

        public static void UpdateTurnOrder()
        {
            // the turn order has not expired yet, regeneration not available
            if (currentCombatant < turnOrder.Count && currentCombatant != -1)
            {
                return;
            }

            // our current combatant's turn is outside the current turn order

            // Clear the turn order just in case our combatant list has changed
            turnOrder.Clear();

            // sort the combatants by speed stat
            combatants.Sort((x, y) => x.character.SPD.Current().CompareTo(y.character.SPD.Current()));

            // regenerate the turn order
            combatants.ForEach(i => turnOrder.Add(i));

            // set current combatant to zero
            currentCombatant = 0;
        }

        public static Combatant CurrentCombatant()
        {
            // try getting the current combatant
            // update the turn order just incase the current combatant has not been assigned yet.
            UpdateTurnOrder();

            return combatants[currentCombatant];
        }

        public static void EndTurn()
        {
            // regen MP for the current combatant
            Combatant combatant = CurrentCombatant();
            combatant.character.MP.Modify(combatant.character.MPR);

            currentCombatant += 1;
            UpdateTurnOrder();
        }

        public static bool GeneralVictory()
        {
            foreach (Combatant c in combatants)
            {
                if (c.character.characterType == CharacterType.Enemy)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool GeneralDefeat()
        {
            foreach (Combatant c in combatants)
            {
                if (c.character.characterType == CharacterType.Ally)
                {
                    return false;
                }
            }
            return true;
        }

        #region Rendering

        public static void RenderTurnOrder()
        {
            // this does nothing at the moment but should render 
            // the turn order, this includes creating portraits / highlighting
            // any that are presently selected

            // All Parts
            // We loop throught the characters in the turn order,
            // loading in their portraits and highlighting the one that is selected
            for (int i = 0; i < turnOrder.Count; i++)
            {
               Texture2D portrait = turnOrder[i].character.portrait;
            }
        }

        public static void RenderHpBars()
        {
            combatants.ForEach(i =>
            {
                i.UpdateHpBar();
            });
        }

        public static void RenderCurrentCharacterInformation()
        {
            // this does nothing at the moment but should update
            // the combat UI to have the current character's information
            // in the main combatant information panel

            if (combatUIDocument == null || combatants.Count <= 0)
            {
                return;
            }

            // Get root
            VisualElement root = combatUIDocument.rootVisualElement;
            Combatant combatant = CurrentCombatant();

            // Set player name
            Label name = (Label)root.Find("PlayerName");
            name.text = combatant.character.name;

            // Set mp bar values
            RenderBar(root.Find("mpBar"), combatant.character.MP, true);

            // Set hp bar values
            RenderBar(root.Find("hpBar"), combatant.character.HP, false);
        }

        private static void RenderBar(VisualElement bar, StatRange stat, bool isMp)
        {
            Combatant combatant = CurrentCombatant();

            VisualElement displayText = bar.Find("DisplayText");

            Label displayValue = (Label)displayText.Find("Value");
            Label displayMaxValue = (Label)displayText.Find("MaxValue");

            VisualElement barFull = bar.Find("FullBar");
            VisualElement barLoss = bar.Find("LossBar");
            VisualElement barGain = bar.Find("GainBar");

            float curStat = stat;
            float maxStat = stat.Max();
            int statChange = 0;

            // Calculate our stat changes
            if (isMp)
            {
                if (uiMode == "player-action")
                {
                    statChange = -combatant.selectedAction.cost;
                }
                else if (uiMode == "player-move")
                {
                    statChange = -combatant.MovementPlanCost();
                }
            } else
            {
                // health stat changes ... somehow???
            }
            

            if (statChange < 0)
            {
                // change the color of our display value to be a "loss" color
                displayValue.style.color = Extensions.ColorFrom(82, 205, 197, 255);
                barLoss.style.width = new Length((-statChange) / maxStat * 100, LengthUnit.Percent);
                barGain.style.width = 0;
            }
            else if (statChange > 0)
            {
                // change the color of our display value to be a "gain" color
                displayValue.style.color = Extensions.ColorFrom(255, 106, 0, 255);
                barGain.style.width = new Length(statChange / maxStat * 100, LengthUnit.Percent);
                barLoss.style.width = 0;
            }
            else
            {
                // change the color of our display value to be a "normal" color
                displayValue.style.color = Color.white;
                barGain.style.width = 0;
                barLoss.style.width = 0;
            }

            displayValue.text = $"{curStat + statChange}";
            displayMaxValue.text = $"{maxStat}";

            // Update stat bar values

            barFull.style.width = new Length((curStat + statChange) / maxStat * 100, LengthUnit.Percent);
        }

        public static void RenderSelection(Combatant combatant) 
        {
            // this does nothing at the moment but should put 
            // the passes combatant's details in the secondary 
            // combatant information panel
        }

        public static void RenderActionMenu()
        {
            // this does nothing at the moment but should graphically
            // update the action menu to be 
            // a) in the proper state
            // b) selecting the right ability 
            // c) with the proper description text

            // We need to check that our UI Document exists and there is at least 1 combatant
            if (combatUIDocument == null || combatants.Count <= 0)
            {
                return;
            }

            VisualElement player = combatUIDocument.rootVisualElement.Find("Player");
            
            // Check how much of the action menu is to be rendered at this current step:
            if (uiMode != "player-action")
            {
                // If the current state does not need the action menu to be rendered we try to hide it. 
                HideActionMenu();
                return; // Rendering ends here. 
            }

            // The current state needs the action menu to be rendered so we show it. 
            ShowActionMenu();

            // Part a) and b)
            // We loop through all 5 abilities that exist (what if there are less?)
            for (int i = 0; i < 5; i++)
            {
                // We calculate the id of our ability
                string abilityID = "Action" + (i + 1);
                // We find the ability itself
                VisualElement ability = (VisualElement)combatUIDocument.rootVisualElement.Find(abilityID);
                // We find the name of this ability
                Label abilityName = (Label)combatUIDocument.rootVisualElement.Find(abilityID).Find("ActionLabel");
                // We find the mp cost of this ability
                Label abilityCost = (Label)combatUIDocument.rootVisualElement.Find(abilityID).Find("ActionValue");
                // We check if the ability is empty
                if (CurrentCombatant().SkillAtIndex(i) == null)
                {
                    // If there are no values for our ability name and cost, we set them as empty strings
                    abilityName.text = "";
                    abilityCost.text = "";
                }
                else
                {
                    // We set our name and mp cost to their proper values (from the combatant)
                    abilityName.text = CurrentCombatant().SkillAtIndex(i).name;
                    abilityCost.text = CurrentCombatant().SkillAtIndex(i).cost.ToString();
                }

                // We check if the skill is selected, and, if so, display it as such
                if (CurrentCombatant().selectedAction == CurrentCombatant().SkillAtIndex(i))
                {
                    // It is the selected skill so we apply the "selected-action style"
                    ability.ClearClassList();
                    ability.AddToClassList("selected-action");
                }
                else
                {
                    // It is not the selected skill so we apply the "deselected-action style"
                    ability.ClearClassList();
                    ability.AddToClassList("deselected-action");

                }

                // We check if the skill is unafordable, and, if so, display it as such
                if (CurrentCombatant().SkillAtIndex(i)?.cost > CurrentCombatant().character.MP)
                {
                    // Our cost is higher then our MP so we apply the "unaffordable-skill style" and "unaffordable-cost style"
                    abilityName.ClearClassList();
                    abilityName.AddToClassList("unaffordable-skill");
                    abilityCost.ClearClassList();
                    abilityCost.AddToClassList("unaffordable-cost");

                }
                else
                {
                    // Our cost is lower than our MP so we apply the "affordable-skill style" and "affordable-cost style
                    abilityName.ClearClassList();
                    abilityName.AddToClassList("affordable-skill");
                    abilityCost.ClearClassList();
                    abilityCost.AddToClassList("affordable-cost");
                }

            }


            // Part c)
            // We find the ability description
            Label abilityDescription = (Label)combatUIDocument.rootVisualElement.Find("AbilityDescription");
            // We change the ability text to the the description provided by our current combatant
            abilityDescription.text = CurrentCombatant().selectedAction.description;
        }

        private static void ShowActionMenu()
        {
            VisualElement root = combatUIDocument.rootVisualElement;

            VisualElement actionsMenu = root.Find("Actions");
            VisualElement header = actionsMenu.Find("TopHeader");
            VisualElement description = actionsMenu.Find("AbilityDescription");
            VisualElement player = actionsMenu.Find("Player");

            // Show all abilities
            new[] { 1, 2, 3, 4, 5 }.ToList().ForEach(i => {
                actionsMenu.Find($"Action{i}").visible = true;
            });

            // Show header and description
            header.visible = true;
            description.visible = true;

            // Change the action menu background to be visible
            actionsMenu.style.backgroundColor = Extensions.ColorFrom(6, 12, 27, 217);

            // hide the current player background as it has an overlapping effect
            player.style.backgroundImage = null;
        }

        private static void HideActionMenu()
        {
            VisualElement root = combatUIDocument.rootVisualElement;

            VisualElement actionsMenu = root.Find("Actions");
            VisualElement header = actionsMenu.Find("TopHeader");
            VisualElement description = actionsMenu.Find("AbilityDescription");
            VisualElement player = actionsMenu.Find("Player");


            // Hide all abilities
            new[] { 1, 2, 3, 4, 5 }.ToList().ForEach(i => {
                actionsMenu.Find($"Action{i}").visible = false;
            });

            // Hide header and description
            header.visible = false;
            description.visible = false;

            // Change the action menu background to be transparent
            actionsMenu.style.backgroundColor = Extensions.ColorFrom(6, 12, 27, 0);

            // show the player background to the player background
            player.style.backgroundImage = new StyleBackground(playerBackground);
        }

        #endregion

        #region SFX

        public static void SFX_NotEnoughMP()
        {
            // play the not enough MP sfx. 
        }

        public static void SFX_CantMove()
        {
            // play the wall collision / invalid movement sfx;
        }

        // Do we need a SFX for dmg? (on player or enemies after a move happened, could use for heal too)
        // Or a visual indicator?

        #endregion
    }
}
