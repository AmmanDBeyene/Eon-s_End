using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore.Items
{
    public abstract class Weapon : Item
    {
        private WeaponSkill _basicSkill;
        public WeaponSkill basicSkill {
            get { return _basicSkill; }
            protected set
            {
                _basicSkill = value;
                if (_basicSkill != null)
                {
                    _basicSkill.owner = owner;
                }
            } 
        }

        private WeaponSkill _specialSkill;
        public WeaponSkill specialSkill
        {
            get { return _specialSkill; }
            protected set
            {
                _specialSkill = value;
                if (_specialSkill != null)
                {
                    _specialSkill.owner = owner;
                }
            }
        }

        protected Weapon(
            string name,
            string description)
            : base(name, description) { }

        protected Weapon(
            string name,
            string description,
            Modifier modifier)
            : base(name, description, modifier) { }

        public virtual void BasicAttack(List<Combatant> targets)
        {
            if (basicSkill == null)
            {
                return;
            }

            basicSkill.Use(targets);
        }

        public virtual void SpecialAttack(List<Combatant> targets)
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
