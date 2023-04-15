using EECore.Items.Accessories;
using EECore.Items.Weapons;
using UnityEngine;

namespace EECore.Characters
{
    public class Joe : Character
    {
        public Joe() : base("Joe", 10, 2, 5, 10, 2, 5) 
        {
            accessory1 = new FireballRing();
        }
    }
}
