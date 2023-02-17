using EECore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.UI.GridLayoutGroup;

namespace EECore.Items.Weapons
{
    public class BasicSword : Weapon
    {
        public BasicSword() : base("Basic Sword",
            "Two sticks tied together in a cross to vaguely resemble a sword.")
        {
            modifier = new Modifier(0, 10, 3, 3, 2, -1);
            basicSkill = new Slash();
            specialSkill = new HeavySlash();
        }
    }

    public class HeavySlash : WeaponSkill
    {
        public HeavySlash() : base("Heavy Slash", "")
        {
            TargetNode n1 = new TargetNode(Direction.Up);
            TargetNode n3 = new TargetNode(Direction.Left);
            TargetNode n4 = new TargetNode(Direction.Right);

            targetTree = n1;
            n1.Connect(n3);
            n1.Connect(n4);
        }

        public override void Use(List<Character> targets)
        {
            if (owner == null)
            {
                return;
            }

            foreach (Character target in targets)
            {
                int damage = (int)(owner.ATK.Current() - (owner.DEF.Current() / 2.0));
                if (damage > 0)
                {
                    target.HP.Modify(-damage);
                }
                else
                {
                    target.HP.Modify(-2);
                }
            }
        }
    }

    public class Slash : WeaponSkill
    {
        public Slash() : base("Slash", "")
        {
            targetTree = new TargetNode(Enums.Direction.Up);
        }

        public override void Use(List<Character> targets)
        {
            if (owner == null || targets.Count <= 0)
            {
                return;
            }

            int damage = owner.ATK.Current() - owner.DEF.Current();
            if (damage > 0)
            {
                targets[0].HP.Modify(-damage);
            }
        }
    }
}
