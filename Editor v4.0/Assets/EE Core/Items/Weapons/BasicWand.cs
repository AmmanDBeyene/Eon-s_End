using EECore;
using EECore.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.EE_Core.Items.Weapons
{
    class BasicWand : Weapon
    {
        public BasicWand() : base("Basic Wand",
               "Two sticks tied together in a cross to vaguely resemble a sword.")
        {
            modifier = new Modifier(0, 5, 3, 3, 2, -1);
            basicSkill = new Smack();
            specialSkill = null;
        }
    }

    public class Smack : WeaponSkill
    {
        public Smack() : base("Smack", "")
        {
            targetTree = new TargetNode(EECore.Enums.Direction.Up);
            cost = 1;
        }

        public override void Use(List<Combatant> targets)
        {
            if (owner == null || targets.Count <= 0)
            {
                return;
            }

            int damage = owner.ATK.Current() - owner.DEF.Current();
            if (damage > 0)
            {
                targets[0].character.HP.Modify(-damage);
            }
        }
    }
}
