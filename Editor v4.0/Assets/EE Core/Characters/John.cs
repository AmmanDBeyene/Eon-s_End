using EECore.Items.Weapons;
using UnityEngine;

namespace EECore.Characters
{
    public class John : Character
    {
        public John() : base("John", 10, 2, 5, 10, 2, 5)
        {
            weapon = new BasicSword();
            Debug.Log("John constructor called");

            characterType = Enums.CharacterType.Enemy;
        }
    }
}
