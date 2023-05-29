using EECore;
using EECore.Enums;
using EECore.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CombatController : MonoBehaviour
{
    public GameObject tileTargetObject;
    public GameObject unitTargetObject;
    public GameObject unitTargetOptionObject;
    public GameObject moveStraightObject;
    public GameObject moveCornerObject;
    public GameObject moveArrowObject;
    public GameObject moveOverObject;
    public GameObject moveStartObject;
    public GameObject combatUIObject;
    public GameObject combatantSelectorObject;
    public GameObject combatantHpBar;
    public Texture2D playerBackground;

    // Start is called before the first frame update
    void Start()
    {
        CombatManager.uiMode = "start-combat";
        CombatManager.tileTargetObject = tileTargetObject;
        CombatManager.unitTargetObject = unitTargetObject;
        CombatManager.unitTargetOptionObject = unitTargetOptionObject;
        CombatManager.moveStraightObject = moveStraightObject;
        CombatManager.moveArrowObject = moveArrowObject;
        CombatManager.moveOverObject = moveOverObject;
        CombatManager.moveCornerObject = moveCornerObject;
        CombatManager.moveStartObject = moveStartObject;
        CombatManager.playerBackground = playerBackground;
        CombatManager.combatantSelectorObject = combatantSelectorObject;
        CombatManager.combatantHpBar = combatantHpBar;
        CombatManager.combatUIDocument = combatUIObject.GetComponent<UIDocument>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Combatant c = CombatManager.CurrentCombatant();
            Debug.Log($"mode: {CombatManager.uiMode} | MP: {c?.character.MP.Current()}");
        }

        if (CombatManager.uiMode == "start-combat")
        {
            CombatManager.UpdateTurnOrder(); // set the turn order at the start of combat
            CombatManager.uiMode = "turn-start-delegation";

            // render the action menu to make sure it is in the proper state. 
            CombatManager.RenderActionMenu();
        }

        if (CombatManager.uiMode == "end-turn-input")
        {
            if (CombatManager.combatants.Count <= 0)
            {
                // if there are no combatants we wait for them to show up. 
                return;
            }

            Combatant combatant = CombatManager.CurrentCombatant();
            
            combatant.showTargetingObjects = false;
            combatant.showMovementObjects = false;
            combatant.CancelMovement();
            combatant.UpdateSelectedAbility();
            combatant.HideMarker();

            CombatManager.EndTurn();

            // do combat over checks here 

            // VICTORY
            if (CombatManager.GeneralVictory())
            {
                // do victory thing here lmao
            }

            // DEFEAT
            if (CombatManager.GeneralDefeat())
            {
                // do defeat thing here lmao
            }

            // NEITHER (combat continues) 
            CombatManager.uiMode = "turn-start-delegation";
        }

        if (CombatManager.uiMode == "turn-start-delegation")
        {
            // render the current combatant information
            CombatManager.RenderCurrentCharacterInformation();
            Combatant combatant = CombatManager.CurrentCombatant();
            combatant.ShowMarker();

            CombatManager.RenderHpBars();

            if (combatant.character.characterType != CharacterType.Ally)
            {
                CombatManager.uiMode = "start-cpu-turn";
            }
            else
            {
                CombatManager.uiMode = "start-player-turn";
            }
        }

        // If it is the start of an enemy's turn we start working on figuring out what move we should do. 
        // the reason these all are separated into different sections is because they each will have graphics that'll happen.
        //if (CombatManager.uiMode == "start-cpu-turn")
        //{
        //    CombatManager.uiMode = "working-cpu-turn";
        //}

        // The working -> finished will be something that happens outside of this update loop. 
        // It'll likely be changed by some other controller. 
        // But for now. Here.
        //if (CombatManager.uiMode == "working-cpu-turn")
        //{
        //    CombatManager.uiMode = "finish-cpu-turn";
        //}

        if (CombatManager.uiMode == "finish-cpu-turn")
        {
            CombatManager.CurrentCombatant().HideMarker();
            CombatManager.EndTurn();
            CombatManager.uiMode = "turn-start-delegation";
        }

        // The start -> turn home will be something that happens outside of this update loop.
        // It'll likely he changed by some other controller. 
        // But for now. Here.
        if (CombatManager.uiMode == "start-player-turn")
        {
            CombatManager.uiMode = "player-move";
            Combatant combatant = CombatManager.CurrentCombatant();
            combatant.showMovementObjects = true;
            combatant.plannedPosition = combatant.gameObject.transform.position;

            // reset temporary MP value
            combatant.tempMP = new StatRange(combatant.character.MP);
            combatant.tempMP.Cap();
        }

        if (CombatManager.uiMode == "player-move")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                CombatManager.uiMode = "player-action";

                Combatant combatant = CombatManager.CurrentCombatant();
                combatant.showTargetingObjects = true;
                combatant.showMovementObjects = false;
                combatant.CancelMovement();
                combatant.UpdateSelectedAbility();

                // reset temporary MP value
                combatant.tempMP = new StatRange(combatant.character.MP);
                combatant.tempMP.Cap();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                CombatManager.uiMode = "end-turn-input";
                return;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                // confirm movement plan.
                CombatManager.uiMode = "player-post-move-planning";
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                // cancel movement plan
                CombatManager.CurrentCombatant().CancelMovement(); 
            }

            // Movement planning mode
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // move up
                CombatManager.CurrentCombatant().PlanMovement(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // move right
                CombatManager.CurrentCombatant().PlanMovement(Direction.Right);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // move down
                CombatManager.CurrentCombatant().PlanMovement(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // move left
                CombatManager.CurrentCombatant().PlanMovement(Direction.Left);
            }

        }

        else if (CombatManager.uiMode == "player-action")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                CombatManager.uiMode = "player-move";
                Combatant combatant = CombatManager.CurrentCombatant();
                combatant.plannedPosition = combatant.gameObject.transform.position;
                combatant.showTargetingObjects = false;
                combatant.showMovementObjects = true;
                combatant.UpdateSelectedAbility();

                // reset temporary MP value
                combatant.tempMP = new StatRange(combatant.character.MP);
                combatant.tempMP.Cap();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                CombatManager.uiMode = "end-turn-input";
                return;
            }

            // Ability selection

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CombatManager.CurrentCombatant().ActionSelectionDown();

                // update MP consumption value on ui
                CombatManager.RenderCurrentCharacterInformation();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CombatManager.CurrentCombatant().ActionSelectionUp();

                // update MP consumption value on ui
                CombatManager.RenderCurrentCharacterInformation();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {

                Combatant combatant = CombatManager.CurrentCombatant();
                SkillItem item = combatant.selectedAction;

                // verify that we even have enough MP to perform this action
                if (combatant.tempMP < item.cost)
                {
                    // GO BACK, GO BACK NOW WE CANT USE IT
                    CombatManager.SFX_NotEnoughMP();
                    return;
                }

                CombatManager.uiMode = "player-post-action-selection";

                // hide the action menu
                CombatManager.RenderActionMenu();
            }
        }

        if (CombatManager.uiMode == "player-post-move-planning")
        {
            Combatant combatant = CombatManager.CurrentCombatant();

            if (combatant.MovementPlanCost() > 0)
            {
                // consume MP
                combatant.character.MP.Modify(-combatant.MovementPlanCost());

                // move the player
                combatant.gameObject.transform.position = combatant.plannedPosition;

                // reset temporary MP value
                combatant.tempMP = new StatRange(combatant.character.MP);
                combatant.tempMP.Cap();

                // update MP value on ui
                CombatManager.RenderCurrentCharacterInformation();
            }

            combatant.CancelMovement();
            CombatManager.uiMode = "player-move";
        }

        if (CombatManager.uiMode == "player-post-action-selection")
        {
            Combatant combatant = CombatManager.CurrentCombatant();
            SkillItem item = combatant.selectedAction;

            if (item.directionalAoe)
            {
                // Directional AOE
                CombatManager.uiMode = "player-action-direction-selection";

                // show overhead markers
                combatant.showTargetOverheadMarkers = true;
                combatant.DirectionalTargeting(combatant.character.facing.ToInt());
                return;
            }
            else if (item.aoeTree != null)
            {
                // Targeted AOE
                CombatManager.uiMode = "player-action-floor-selection";
                combatant.showAoeTargetingObjects = true;
                combatant.showTargetOverheadMarkers = true;
                combatant.aoeTargetPosition = combatant.gameObject.transform.position;
                combatant.UpdateSelectedTile();
                combatant.UpdateTargets();
                return;
            } else
            {
                // Single Target
                CombatManager.uiMode = "player-action-target-selection";
                combatant.showTargetOverheadMarkers = true;
                combatant.UpdateTargets();
                return;
            }
        }

        if (CombatManager.uiMode == "player-action-direction-selection")
        {
            if (Input.GetKeyDown(KeyCode.Z) && CombatManager.CurrentCombatant().Targets().Count > 0)
            {
                CombatManager.uiMode = "player-action-activation";
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                CombatManager.uiMode = "end-turn-input";
                return;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                CombatManager.uiMode = "player-action";

                Combatant combatant = CombatManager.CurrentCombatant();
                combatant.UpdateSelectedAbility();

                // hide overhead markers
                combatant.showTargetOverheadMarkers = false;
                combatant.UpdateTargets();

                // show the action menu
                CombatManager.RenderActionMenu();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // face up
                CombatManager.CurrentCombatant().DirectionalTargeting(0);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // face right
                CombatManager.CurrentCombatant().DirectionalTargeting(1);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // face down
                CombatManager.CurrentCombatant().DirectionalTargeting(2);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // face left
                CombatManager.CurrentCombatant().DirectionalTargeting(3);
            }
        }

        else if (CombatManager.uiMode == "player-action-floor-selection")
        {
            if (Input.GetKeyDown(KeyCode.Z) && CombatManager.CurrentCombatant().Targets().Count > 0)
            {
                CombatManager.uiMode = "player-action-activation";
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                CombatManager.uiMode = "end-turn-input";
                return;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                CombatManager.uiMode = "player-action";
                Combatant combatant = CombatManager.CurrentCombatant();
                combatant.showAoeTargetingObjects = false;
                combatant.showTargetOverheadMarkers = false;
                combatant.UpdateSelectedTile();
                combatant.UpdateTargets();

                // show the action menu
                CombatManager.RenderActionMenu();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CombatManager.CurrentCombatant().AoeTargetChangeTile(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CombatManager.CurrentCombatant().AoeTargetChangeTile(Direction.Right);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CombatManager.CurrentCombatant().AoeTargetChangeTile(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CombatManager.CurrentCombatant().AoeTargetChangeTile(Direction.Left);
            }
        }

        else if (CombatManager.uiMode == "player-action-target-selection")
        {
            if (Input.GetKeyDown(KeyCode.Z) && CombatManager.CurrentCombatant().Targets().Count > 0)
            {
                CombatManager.uiMode = "player-action-activation";
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                CombatManager.uiMode = "end-turn-input";
                return;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                CombatManager.uiMode = "player-action";

                Combatant combatant = CombatManager.CurrentCombatant();

                // hide overhead markers
                combatant.showTargetOverheadMarkers = false;
                combatant.UpdateTargets();

                // show the action menu
                CombatManager.RenderActionMenu();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CombatManager.CurrentCombatant().SingleTargetSelectionPrevious();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CombatManager.CurrentCombatant().SingleTargetSelectionNext();
            }
        }

        if (CombatManager.uiMode == "player-action-activation")
        {
            Combatant combatant = CombatManager.CurrentCombatant();
            SkillItem item = combatant.selectedAction;

            // subtract MP
            combatant.character.MP.Modify(-item.cost);

            // reset temporary MP value
            combatant.tempMP = new StatRange(combatant.character.MP);
            combatant.tempMP.Cap();

            // try activate skill on current targets
            combatant.selectedAction.Use(combatant.Targets());

            CombatManager.RenderHpBars();

            // update mp value after action
            CombatManager.RenderCurrentCharacterInformation();

            // move state to post action activation (this should be done by something external in the future)
            CombatManager.uiMode = "player-action-post-activation";
        }

        if (CombatManager.uiMode == "player-action-post-activation")
        {
            CombatManager.uiMode = "player-action";
            Combatant combatant = CombatManager.CurrentCombatant();
            combatant.showAoeTargetingObjects = false;
            combatant.showTargetOverheadMarkers = false;
            combatant.UpdateSelectedAbility();
            combatant.UpdateSelectedTile();
            combatant.UpdateTargets();
        }
    }
}
