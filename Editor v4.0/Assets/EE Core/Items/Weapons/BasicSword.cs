using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore.Items.Weapons
{
    public class BasicSword : Weapon
    {
        public BasicSword() : base("Basic Sword",
            "Two sticks tied together in a cross to vaguely resemble a sword.")
        {
            modifier = new Modifier(0, 10, 3, 3, 2, -1);
        }

        public override void BasicAttack()
        {

        }

        public override void Use()
        {

        }
    }
}
