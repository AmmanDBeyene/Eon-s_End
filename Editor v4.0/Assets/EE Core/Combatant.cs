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
    public class Combatant
    {
        // general combatant stuff
        internal Character character { get; private set; }
        internal GameObject gameObject { get; private set; }

        // skill & targeting combatant stuff
        internal int outerActionSelectedIndex { get; private set; } = 0;
        internal SkillItem selectedAction { get; private set; } = null;
        internal Dictionary<Direction, GameObject> targetingObjects { get; private set; }
        internal bool showTargetingObjects { get; set; }
        internal bool showTargetOverheadMarkers { get; set; }
        internal bool showAoeTargetingObjects { get; set; }
        internal Vector3 aoeTargetPosition { get; set; }
        private List<Vector3> targetObjectCreationCache { get; set; }
        private int selectedTargetIndex { get; set; } = 0;
        private List<GameObject> targetOverheadMarkers { get; }
        private List<Combatant> combatantTargets { get; }
        private List<Combatant> combatantTargetOptions { get; }
        private GameObject aoeTargetingObject { get; set; }

        // movement planning combatant stuff
        internal bool showMovementObjects { get; set; }
        internal Vector3 plannedPosition { get; set; }
        private GameObject currentUnitIndicator { get; set; }
        private List<Direction> movementPlan { get; }
        private List<GameObject> movementObjects { get; }
        public StatRange tempMP { get; set; }
        
        internal Combatant(Character character, GameObject gameObject)
        {
            this.character = character;
            this.gameObject = gameObject;

            targetingObjects = new Dictionary<Direction, GameObject>();
            targetObjectCreationCache = new List<Vector3>();
            targetOverheadMarkers = new List<GameObject>();
            combatantTargets = new List<Combatant>();
            combatantTargetOptions = new List<Combatant>();

            movementPlan = new List<Direction>();
            movementObjects = new List<GameObject>();

            UpdateSelectedAbility();
        }

        #region Skill Selection and Targeting

        public List<Combatant> Targets()
        {
            return combatantTargets;
        }

        public void ActionSelectionUp()
        {
            outerActionSelectedIndex += 1;
            if (outerActionSelectedIndex >= ActionTotal())
            {
                outerActionSelectedIndex = 0;
            }

            UpdateSelectedAbility();
        }

        public void ActionSelectionDown()
        {
            outerActionSelectedIndex -= 1;
            if (outerActionSelectedIndex < 0)
            {
                outerActionSelectedIndex = ActionTotal() - 1;
            }

            UpdateSelectedAbility();
        }

        public void SingleTargetSelectionPrevious()
        {
            selectedTargetIndex--;
            if (selectedTargetIndex < 0)
            {
                selectedTargetIndex = combatantTargetOptions.Count - 1;
            }
            UpdateTargets();
        }

        public void SingleTargetSelectionNext()
        {
            selectedTargetIndex++;
            if (selectedTargetIndex >= combatantTargetOptions.Count)
            {
                selectedTargetIndex = 0;
            }
            UpdateTargets();
        }

        public void AoeTargetChangeTile(Direction direction)
        {
            // find our new potential target position
            Vector3 newPos = aoeTargetPosition + direction.ToVector3();

            // check if this new position contains a range target object
            GameObject nodeAtPosition = GetTargetNodeAt(newPos);

            if (nodeAtPosition == null)
            {
                // this is an invalid move, do not continue changing tiles
                return;
            }

            // update target position with new position
            aoeTargetPosition = newPos;

            // update aoe targeting visual
            UpdateSelectedTile();

            // update targets for the new generated visual
            UpdateTargets();
        }

        public void DirectionalTargeting(int direction)
        {
            GenerateTargetingObjectsFromItemInDirection(selectedAction, direction);
            UpdateTargets();
        }

        public void UpdateSelectedAbility()
        {
            selectedAction = SkillAtIndex(OuterToInnerIndex(outerActionSelectedIndex));
            CombatManager.RenderActionMenu();
            GenerateTargetingObjectsFromItem(selectedAction);
        }

        public void UpdateSelectedTile()
        {
            GenerateAoeTargetingObjectsFromItem(selectedAction);
        }

        public int OuterToInnerIndex(int indexOuter)
        {
            int counter = 0;
            for (int i = 0; i < 5; ++i)
            {
                if (SkillAtIndex(i) != null)
                {
                    if (counter == indexOuter)
                    {
                        return i;
                    }
                    counter++;
                }
            }

            return -1;
        }

        public SkillItem SkillAtIndex(int innerIndex)
        {
            if (innerIndex == 0) { return character?.weapon?.basicSkill; }
            if (innerIndex == 1) { return character?.weapon?.specialSkill; }
            if (innerIndex == 2) { return character?.accessory1; }
            if (innerIndex == 3) { return character?.accessory2; }
            if (innerIndex == 4) { return character?.accessory3; }

            return null;
        }

        public int ActionTotal()
        {
            int sum = 0;

            for (int i = 0; i < 5; ++i)
            {
                if (SkillAtIndex(i) != null)
                {
                    sum += 1;
                }
            }

            return sum;
        }

        public void UpdateTargets()
        {
            if (selectedAction.directionalAoe)
            {
                // Directional AOE
                SelectDirectionalAoeTargets();
            }
            else if (selectedAction.aoeTree != null)
            {
                // Targeted AOE (technically the same as Directional AOE calculation) 
                SelectAoeTargets();
            }
            else
            {
                // Single Target
                SelectSingleTarget();
            }

            UpdateOverheadMarkers();
        }

        private Combatant GetCombatantIn(GameObject targetingNode)
        {
            // find the first combatant which is contained by this targeting node gameobject.
            // this combatant will be null if no combatant is found
            return CombatManager.combatants.Find(
                c => targetingNode.GetComponent<BoxCollider>().bounds.Contains(c.gameObject.transform.position));
        }

        private bool CombatantMatchesItemFilter(SkillItem item, Combatant c)
        {
            CharacterFilterType filter = item.characterFilter;

            // if we are filtering on self return if the current combatant is ourself
            if (filter == CharacterFilterType.Self)
            {
                return c == this;
            }

            CharacterType type = c.character.characterType;

            // aside from the special self case return if our filter matches our combatant's chara type
            return filter.BasicMatches(type);
        }

        private GameObject GetTargetNodeAt(Vector3 position)
        {
            GameObject targetNode = null;

            // for every targeting object for every direction
            // for every box collider which these targeting objects have
            // find the box collider which contains our point and return the game obejct with that collider
            targetingObjects.Values.ToList().Find(
                o =>
                {
                    BoxCollider matchingCollider = o.GetComponentsInChildren<BoxCollider>().ToList().Find(c => c.bounds.Contains(position));
                    targetNode = matchingCollider?.gameObject;
                    return matchingCollider != null;
                });
            return targetNode;
        }

        private void SelectDirectionalAoeTargets()
        {
            // clear stale target array
            combatantTargets.Clear();

            // copy all target options into combatant targets as a directional AOE
            // hits all of the targets in its current selection
            combatantTargetOptions.ForEach(t => combatantTargets.Add(t));
        }

        private void SelectAoeTargets()
        {
            // clear stale target array
            combatantTargets.Clear();

            // copy all target options into combatant targets as a directional AOE
            // hits all of the targets in its current selection
            combatantTargetOptions.ForEach(t => combatantTargets.Add(t));
        }

        private void SelectSingleTarget()
        {
            // clear stale target array
            combatantTargets.Clear();

            if (combatantTargetOptions.Count <= 0)
            {
                return;
            }

            // current combat target is the target at the selected index
            combatantTargets.Add(combatantTargetOptions[selectedTargetIndex]);

            // render the target selection in the target selection window;
            CombatManager.RenderSelection(combatantTargetOptions[selectedTargetIndex]);
        }

        private void UpdateOverheadMarkers()
        {
            float markerVerticalOffset = 2.0f;

            // destroy all old overhead markers
            targetOverheadMarkers.ForEach(i => GameObject.Destroy(i));
            targetOverheadMarkers.Clear();

            // if we are not showing overhead markers let's not make any new ones :)
            if (!showTargetOverheadMarkers)
            {
                return;
            }

            // compare targeting lists
            combatantTargetOptions.ForEach(
                t =>
                {
                    GameObject marker = combatantTargets.Contains(t)
                        ? GameObject.Instantiate(CombatManager.unitTargetObject, gameObject.transform)
                        : GameObject.Instantiate(CombatManager.unitTargetOptionObject, gameObject.transform);
                    marker.transform.position = t.gameObject.transform.position + Vector3.up * markerVerticalOffset;
                    targetOverheadMarkers.Add(marker);
                }
            );
        }

        private void GenerateTargetingObjectsFromItemInDirection(SkillItem item, int direction)
        {
            if (item == null)
            {
                return;
            }

            targetObjectCreationCache.Clear();

            combatantTargetOptions.Clear();

            targetingObjects.Values.ToList().ForEach(i => GameObject.Destroy(i));

            if (showTargetingObjects)
            {
                targetingObjects[direction.ToDirection()] = ConstructTargetingObjectFromTree(item, direction);
            }

            character.facing = direction.ToDirection();
        }

        private void GenerateTargetingObjectsFromItem(SkillItem item)
        {
            if (item == null)
            {
                return;
            }

            targetObjectCreationCache.Clear();

            combatantTargetOptions.Clear();

            targetingObjects.Values.ToList().ForEach(i => GameObject.Destroy(i));

            if (showTargetingObjects)
            {
                targetingObjects[Direction.Up] = ConstructTargetingObjectFromTree(item, 0);
                targetingObjects[Direction.Right] = ConstructTargetingObjectFromTree(item, 1);
                targetingObjects[Direction.Down] = ConstructTargetingObjectFromTree(item, 2);
                targetingObjects[Direction.Left] = ConstructTargetingObjectFromTree(item, 3);
            }
        }

        private void GenerateAoeTargetingObjectsFromItem(SkillItem item)
        {
            if (item == null)
            {
                return;
            }

            if (aoeTargetingObject != null)
            {
                GameObject.Destroy(aoeTargetingObject);
            }

            combatantTargetOptions.Clear();

            targetObjectCreationCache.Clear();

            if (showAoeTargetingObjects)
            {
                aoeTargetingObject = ConstructAoeTargetingObjectFromTree(item);
            }
        }

        private GameObject ConstructTargetingObjectFromTree(SkillItem item, int direction)
        {
            GameObject root = new GameObject("targetObjectRoot");
            root.transform.position = gameObject.transform.position;
            ConstructTargetingObjectFromTreeHelper(item.targetTree, gameObject.transform.position, direction, root, item);

            return root;
        }

        private GameObject ConstructAoeTargetingObjectFromTree(SkillItem item)
        {
            GameObject root = new GameObject("targetObjectRoot");
            root.transform.position = aoeTargetPosition;
            ConstructAoeTargetingObjectFromTreeHelper(item.aoeTree, aoeTargetPosition, 0, root, item);

            return root;
        }

        private void ConstructTargetingObjectFromTreeHelper(TargetNode node, Vector3 lastPosition, int rotation, GameObject root, SkillItem item)
        {
            if (node == null || root == null)
            {
                return;
            }

            // Get the potential position of this node. 
            // rotate based on our rotation value
            Vector3 nodePos = lastPosition +
                Quaternion.AngleAxis(90 * rotation, Vector3.up) *
                node.direction.ToVector3() * (1 + node.skip);

            nodePos.RoundXZ();
            Debug.Log($"Pos <{nodePos.x}, {nodePos.y}, {nodePos.z}>");


            // If the potential position of this node has already been covered don't place it. 
            if (targetObjectCreationCache.Contains(nodePos))
            {
                return;
            }

            // If we arent ignoring walls and our node position is different than our last position
            // we draw a ray from lastPos to nodePos to check if there's a wall in the way. 
            if (!item.ignoreWalls && (nodePos - lastPosition).magnitude > 0)
            {
                RaycastHit hit = Extensions.Cast(lastPosition, nodePos);
                if (hit.transform != null && !hit.transform.tag.Equals("IgnoreCollision"))
                {
                    return; // return because we have hit a wall.
                }
            }

            // Draw a ray from our potential position down to the floor to
            // check if there's actually ground at the index where we are trying to create 
            // this target box
            RaycastHit floorHit = Extensions.Cast(nodePos, nodePos + Vector3.down * 0.6f);
            if (floorHit.transform == null || floorHit.transform.tag.Equals("IgnoreCollision"))
            {
                return; // return because there is not a floor
            }

            // Wall check condluded, we can add a new targetCube to our 
            // root game object at our new calculated position
            GameObject targetBox = GameObject.Instantiate(CombatManager.targetBox, root.transform, false);
            targetBox.transform.position = nodePos;

            // now that we have created our target box we can check if there are any targets it selects:
            Combatant c = GetCombatantIn(targetBox);

            if (c != null && CombatantMatchesItemFilter(item, c))
            {
                combatantTargetOptions.Add(c);
            }

            targetObjectCreationCache.Add(nodePos);

            // Recurse into the next nodes
            node.connections.ForEach(i => ConstructTargetingObjectFromTreeHelper(i, nodePos, rotation, root, item));
        }

        private void ConstructAoeTargetingObjectFromTreeHelper(TargetNode node, Vector3 lastPosition, int rotation, GameObject root, SkillItem item)
        {
            if (node == null || root == null)
            {
                return;
            }

            // Get the potential position of this node. 
            // rotate based on our rotation value
            Vector3 nodePos = lastPosition +
                Quaternion.AngleAxis(90 * rotation, Vector3.up) *
                node.direction.ToVector3() * (1 + node.skip);

            nodePos.RoundXZ();

            // If the potential position of this node has already been covered don't place it. 
            if (targetObjectCreationCache.Contains(nodePos))
            {
                return;
            }

            // If we arent ignoring walls and our node position is different than our last position
            // we draw a ray from lastPos to nodePos to check if there's a wall in the way. 
            if (!item.aoeIgnoreWalls && (nodePos - lastPosition).magnitude > 0)
            {
                RaycastHit hit = Extensions.Cast(lastPosition, nodePos);
                if (hit.transform != null && !hit.transform.tag.Equals("IgnoreCollision"))
                {
                    return; // return because we have hit a wall.
                }
            }

            // Draw a ray from our potential position down to the floor to
            // check if there's actually ground at the index where we are trying to create 
            // this target box
            RaycastHit floorHit = Extensions.Cast(nodePos, nodePos + Vector3.down * 0.6f);
            if (floorHit.transform == null || floorHit.transform.tag.Equals("IgnoreCollision"))
            {
                return; // return because there is not a floor
            }

            // Wall check condluded, we can add a new targetCube to our 
            // root game object at our new calculated position
            GameObject targetBox = GameObject.Instantiate(CombatManager.tileTargetObject, root.transform, false);
            targetBox.transform.position = nodePos;

            // now that we have created our target box we can check if there are any targets it selects:
            Combatant c = GetCombatantIn(targetBox);

            if (c != null && CombatantMatchesItemFilter(item, c))
            {
                combatantTargetOptions.Add(c);
            }

            targetObjectCreationCache.Add(nodePos);

            // Recurse into the next nodes
            node.connections.ForEach(i => ConstructAoeTargetingObjectFromTreeHelper(i, nodePos, rotation, root, item));
        }

        #endregion

        #region Movement (Planning)

        public void PlanMovement(Direction direction)
        {
            // if a move is not valid we do not allow for its planning
            if (!MoveValid(direction))
            {
                return;
            }

            // update our movement plan
            UpdateMovementPlan(direction);

            // re-render our movement plan
            ConstructMovementPlanObjects();
        }

        /// <summary>
        /// Cancel the current movement plan. 
        /// </summary>
        public void CancelMovement()
        {
            movementObjects.ForEach(o => GameObject.Destroy(o));
            movementObjects.Clear();
            movementPlan.Clear();
        }

        public int MovementPlanCost()
        {
            return movementPlan.Count * character.movementCost;
        }

        private bool MoveValid(Direction direction)
        {
            int planCost = MovementPlanCost();
            int remainingMP = tempMP.Current() - planCost;
            bool cancelsOut = false;

            if (movementPlan.Count > 0)
            {
                // see if this move cancels out with the last one 
                cancelsOut = movementPlan.Last().IsOpposite(direction);
            }

            // if we have zero OR GOD FORBID ~NEGATIVE MP~ prevent movement. 
            // AND if we are planning to move in a way that does not cancel out with
            // our previous movement. 
            if (remainingMP <= 0 && !cancelsOut)
            {
                CombatManager.SFX_NotEnoughMP(); // play not enough MP sfx
                return false;
            }


            Vector3 nodePos = plannedPosition + direction.ToVector3();
            if ((nodePos - plannedPosition).magnitude > 0)
            {
                RaycastHit hit = Extensions.Cast(plannedPosition, nodePos);
                if (hit.transform != null)
                {
                    CombatManager.SFX_CantMove();
                    return false;
                }
            }

            // Draw a ray from our potential position down to the floor to
            // check if there's actually ground at the index where we are trying to move through
            RaycastHit floorHit = Extensions.Cast(nodePos, nodePos + Vector3.down * 0.6f);
            if (floorHit.transform == null)
            {
                CombatManager.SFX_CantMove();
                return false; 
            }

            return true;
        }

        private void UpdateMovementPlan(Direction direction)
        {
            if (movementPlan.Count <= 0)
            {
                movementPlan.Add(direction);
                return;
            }

            // check last item on direction list
            Direction previous = movementPlan.Last();

            if (previous.IsOpposite(direction))
            {
                // we have a request to cancel the last step in our movement 
                // remove the last step. 
                movementPlan.RemoveAt(movementPlan.End());
                return;
            }

            // no special cases otherwise. add our new movement to the plan list
            movementPlan.Add(direction);
        }

        private void ConstructMovementPlanObjects()
        {
            Vector3 offset = new Vector3(0, -0.4f, 0);

            // delete all movement objects from list
            movementObjects.ForEach(o => GameObject.Destroy(o));
            movementObjects.Clear();

            // stop construction if there is no movement plan or if the movement tiles are to not be displayed. 
            if (movementPlan.Count <= 0 || !showMovementObjects)
            {
                return;
            }

            plannedPosition = gameObject.transform.position;

            GameObject start = GameObject.Instantiate(CombatManager.moveStartObject);
            start.transform.position = plannedPosition + offset;
            start.transform.Rotate(0, movementPlan.First().ToInt() * 90, 0);
            movementObjects.Add(start);

            //Direction last = movementPlan.First();
            plannedPosition += movementPlan.First().ToVector3();

            // start moving rhough our movement plan
            for (int i = 1; i < movementPlan.Count; ++i)
            {
                Direction curr = movementPlan[i];
                Direction last = movementPlan[i - 1];

                // place node at plannined position
                if (curr == last)
                {
                    // put a straight piece
                    GameObject straight = GameObject.Instantiate(CombatManager.moveStraightObject);
                    straight.transform.position = plannedPosition + offset;
                    straight.transform.Rotate(0, curr == Direction.Left || curr == Direction.Right ? 0 : 90, 0);
                    movementObjects.Add(straight);
                }
                else
                {
                    // put a corner piece with the right rotation?
                    float rotation = last.CornerType(curr) * 90;
                    GameObject corner = GameObject.Instantiate(CombatManager.moveCornerObject);
                    corner.transform.position = plannedPosition + offset;
                    corner.transform.Rotate(0, rotation, 0);
                    movementObjects.Add(corner);
                }

                // update planned position
                plannedPosition += curr.ToVector3();
            }

            GameObject arrow = GameObject.Instantiate(CombatManager.moveArrowObject);
            arrow.transform.position = plannedPosition + offset;
            arrow.transform.Rotate(0, 90 * movementPlan.Last().ToInt(), 0);
            movementObjects.Add(arrow);
        }

        #endregion
    }
}
