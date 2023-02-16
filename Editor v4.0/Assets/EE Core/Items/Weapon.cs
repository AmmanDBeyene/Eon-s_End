using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore.Items
{
    public abstract class Weapon : SkillItem
    {
        public Weapon(
            string name, 
            string description)
            : base(name, description) { }

        public Weapon(
            string name, 
            string description,
            Modifier modifier)
            : base(name, description, modifier) { }

        public abstract void BasicAttack();
    }
}
