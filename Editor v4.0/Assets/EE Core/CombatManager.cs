using EECore.Enums;
using EECore.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
            currentCombatant += 1;
            UpdateTurnOrder();
        }

        #region Rendering

        public static void RenderTurnOrder()
        {
            // this does nothing at the moment but should render 
            // the turn order, this includes creating portraits / highlighting
            // any that are presently selected
        }

        public static void RenderCurrentCharacterInformation()
        {
            // this does nothing at the moment but should update
            // the combat UI to have the current character's information
            // in the main combatant information panel
        }

        public static void RenderSelection(Combatant combatant) 
        {
            // this does nothing athte moment but should put 
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

        #endregion
    }
}
