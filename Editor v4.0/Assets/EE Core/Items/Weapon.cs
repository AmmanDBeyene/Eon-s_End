using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore.Items
{
    public abstract class Weapon : Item
    {
        public WeaponSkill basicSkill { get; protected set; }
        public WeaponSkill specialSkill { get; protected set; }

        protected Weapon(
            string name,
            string description)
            : base(name, description) { }

        protected Weapon(
            string name,
            string description,
            Modifier modifier)
            : base(name, description, modifier) { }

        public virtual void BasicAttack(List<Character> targets)
        {
            if (basicSkill == null)
            {
                return;
            }

            basicSkill.Use(targets);
        }

        public virtual void SpecialAttack(List<Character> targets)
        {
            if (specialSkill == null)
            {
                return;
            }

            specialSkill.Use(targets);
        }
    }

    public abstract class WeaponSkill : SkillItem
    {
        public WeaponSkill(
            string name,
            string description)
            : base(name, description) { }
    }
}
