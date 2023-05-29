using EECore;
using EECore.Enums;
using EECore.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Progress;

namespace EECore.AI.Modules
{
    internal class AIZero : AIModule
    {
        public IEnumerator DoTurn(Combatant cpu)
        {
            // stupid AF AI
            // try to move as close to the player as possible
            // if close to the player attack with basic sword

            // Make sure we are not dead
            if (cpu.character.HP <= 0)
            {
                // not sure how we got here but you are dead. you literally are dead.
                yield break;
            }

            // calculate xz distance to all players
            int xzNearest = -1;
            Combatant nearestEnemy = null;

            CombatManager.combatants.ForEach(combatant =>
            {
                if (combatant.character.characterType == CharacterType.Enemy)
                {
                    return;
                }

                Vector3 distance = cpu.gameObject.transform.position - combatant.gameObject.transform.position;
                int xzDistance = (int)Math.Abs(distance.x) + (int)Math.Abs(distance.z);

                if (xzNearest == -1 || xzDistance < xzNearest)
                {
                    nearestEnemy = combatant;
                    xzNearest = xzDistance;
                }
            });

            // if there are no nearest enemies we dont have anything to do so we dont move
            if (nearestEnemy == null)
            {
                yield break;
            }

            cpu.showMovementObjects = true;
            cpu.plannedPosition = cpu.gameObject.transform.position;

            // while we are far from our target try to get close
            while (true)
            {
                yield return new WaitForSeconds(0.5f);

                // since we are further than one distance away we need to move closer
                // re-calculate plan xz
                Vector3 distance = nearestEnemy.gameObject.transform.position - cpu.plannedPosition;
                xzNearest = (int)Math.Abs(distance.x) + (int)Math.Abs(distance.z);

                // we're already close enough to attack, no need to move
                if (xzNearest <= 1)
                {
                    break;
                }

                // calculate direction to move
                Direction direction = distance.ToDirectionVector().ToDirection();

                // try to plan movement
                bool planSuccess = cpu.PlanMovement(direction);

                // if our movement plan (+1 move) does not exceed our mp cap we can plan our next move
                bool canPlanNext = cpu.MovementPlanCost() + cpu.character.movementCost <= cpu.character.MP;

                // if our previous plan was not a success we just give up on planning and stop. 
                if (!planSuccess)
                {
                    canPlanNext = false;
                }

                // if our xz is close enough or if we do not have enough MP to move again 
                // we confirm movement
                if (xzNearest <= 2 || !canPlanNext)
                {
                    // consume MP
                    cpu.character.MP.Modify(-cpu.MovementPlanCost());

                    // move the player
                    cpu.gameObject.transform.position = cpu.plannedPosition;

                    // reset temporary MP value
                    cpu.tempMP = new StatRange(cpu.character.MP);
                    cpu.tempMP.Cap();

                    // update MP value on ui
                    CombatManager.RenderCurrentCharacterInformation();

                    // hide movement nodules
                    cpu.CancelMovement();

                    break;
                }

                if (!canPlanNext)
                {
                    break;
                }
            }

            // while we have MP to attack
            while (true)
            {
                yield return new WaitForSeconds(0.5f);


                // re-calculate plan xz
                Vector3 distance = nearestEnemy.gameObject.transform.position - cpu.gameObject.transform.position;
                xzNearest = (int)Math.Abs(distance.x) + (int)Math.Abs(distance.z);

                // having found the nearest enemy we check if we are within one tile of them
                // this is where we'd attack as we no longer need to move

                if (xzNearest <= 1)
                {
                    // attack with basic weapon
                    SkillItem basicAction = cpu.SkillAtIndex(0);

                    // this is a super dumb CPU capable of only basic attacks. 
                    // if we dont have enough MP we dont attack
                    if (basicAction == null || basicAction.cost > cpu.character.MP)
                    {
                        yield break;
                    }

                    List<Combatant> targets = new List<Combatant>();
                    targets.Add(nearestEnemy);

                    // take mana cost for attack
                    cpu.character.MP.Modify(-basicAction.cost);

                    // attack our target using our basic action
                    basicAction.Use(targets);

                    // re-render hp bars
                    CombatManager.RenderHpBars();

                    // re-render mana bars
                    CombatManager.RenderCurrentCharacterInformation();

                    break;
                }
            }

            yield break;
        }
    }
}
