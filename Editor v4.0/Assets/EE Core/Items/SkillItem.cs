using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore.Items
{
    public abstract class SkillItem : Item
    {
        public SkillItem(
            string name, 
            string description)
            : base(name, description) { }

        public SkillItem(
            string name, 
            string description, 
            Modifier modifier)
            : base(name, description, modifier) { }

        public abstract void Use();
    }
}
