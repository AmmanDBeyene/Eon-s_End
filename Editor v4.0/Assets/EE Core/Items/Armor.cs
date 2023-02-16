using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore.Items
{
    public abstract class Armor : Item
    {
        public Armor(
            string name, 
            string description)
            : base(name, description) { }

        public Armor(
            string name, 
            string description, 
            Modifier modifier)
            : base(name, description, modifier) { }
    }
}
