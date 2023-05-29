using EECore.Items.Accessories;
using EECore.Items.Weapons;
using UnityEngine;

namespace EECore.Characters
{
    public class James : Character
    {
        public James() : base("James", 10, 2, 5, 15, 5, 5) 
        {
            weapon = new BasicSword();
            accessory3 = new FireballRing();
            Cap();
        }
    }
}
