using EECore.Enums;
using EECore.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore
{
    public abstract class Character
    {
        public string name              { get; }

        public double health            { get; }
        public double attack            { get; }
        public double defense           { get; }
        public double movementPoints    { get; }
        public double movementPointRegen { get; }
        public double speed             { get; }

        public StatRange HP             { get; }
        public StatRange ATK            { get; }
        public StatRange DEF            { get; }
        public StatRange MP             { get; }
        public StatRange MPR            { get; }
        public StatRange SPD            { get; }

        public int movementCost         { get; }

        private Weapon _weapon;
        public Weapon weapon
        {
            get { return _weapon; }
            set
            {
                _weapon = value;
                UpdateRanges();
            }
        }

        private Accessory _accessory1;
        public Accessory accessory1
        {
            get { return _accessory1; }
            set
            {
                _accessory1 = value;
                UpdateRanges();
            }

        }
        private Accessory _accessory2;
        public Accessory accessory2
        {
            get { return _accessory2; }
            set
            {
                _accessory2 = value;
                UpdateRanges();
            }
        }

        private Accessory _accessory3;
        public Accessory accessory3
        {
            get { return _accessory3; }
            set
            {
                _accessory3 = value;
                UpdateRanges();
            }
        }
        private Armor _topArmor;
        public Armor topArmor
        {
            get { return _topArmor; }
            set
            {
                _topArmor = value;
                UpdateRanges();
            }
        }
        private Armor _bottomArmor;
        public Armor bottomArmor
        {
            get { return _bottomArmor; }
            set
            {
                _bottomArmor = value;
                UpdateRanges();
            }
        }

        public Direction facing         { get; set; }

        public List<Modifier> modifiers { get; }

        public CharacterType characterType  { get; set; }

        public Character()
            : this("Nobody") { }

        public Character(string name)
            : this(name, 1, 1, 1, 1, 1, 1) { }

        public Character(
            string name,
            float health,
            float attack,
            float defense,
            float movementPoints,
            float movementPointRegen,
            float speed)
            : this(
                  name, 
                  health, 
                  attack, 
                  defense, 
                  movementPoints,
                  movementPointRegen,
                  speed, 
                  null, null, 
                  null, null, 
                  null, null) { }

        public Character(
            string name,
            float health,
            float attack,
            float defense,
            float movementPoints,
            float movementPointRegen,
            float speed,
            Weapon weapon,
            Accessory accessory1,
            Accessory accessory2,
            Accessory accessory3,
            Armor topArmor, 
            Armor bottomArmor)
        {
            modifiers = new List<Modifier>();

            this.name                = name;
            this.health              = health;
            this.attack              = attack;
            this.defense             = defense;
            this.movementPoints      = movementPoints;
            this.movementPointRegen  = movementPointRegen;
            this.speed               = speed;

            HP      = new StatRange();
            ATK     = new StatRange();
            DEF     = new StatRange();
            MP      = new StatRange();
            MPR     = new StatRange();
            SPD     = new StatRange();

            this.weapon          = weapon;
            this.accessory1      = accessory1;
            this.accessory2      = accessory2;
            this.accessory3      = accessory3;
            this.topArmor        = topArmor;
            this.bottomArmor     = bottomArmor;

            Cap();

            movementCost = 2;
        }

        public void Cap()
        {
            HP.Cap();
            ATK.Cap();
            DEF.Cap();
            MP.Cap();
            MPR.Cap();
            SPD.Cap();
        }

        private void UpdateRanges()
        {
            HP .UpdateMax((int)health           + HPMods());
            ATK.UpdateMax((int)attack           + ATKMods());
            DEF.UpdateMax((int)defense          + DEFMods());
            MP .UpdateMax((int)movementPoints   + MPMods());
            MPR.UpdateMax((int)movementPointRegen + MPRMods());
            SPD.UpdateMax((int)speed + SPDMods());
        }


        public int GetStatMods(string stat)
        {
            double baseStat = GetBaseStatMods(stat);
            foreach (Modifier mod in modifiers)
            {
                baseStat += mod.Get(stat);
            }

            return (int) Math.Ceiling(baseStat);
        }

        public int HPMods()
        {
            return GetStatMods("hp");
        }

        public int ATKMods()
        {
            return GetStatMods("atk");
        }

        public int DEFMods()
        {
            return GetStatMods("def");
        }

        public int SPDMods()
        {
            return GetStatMods("spd");
        }

        public int MPMods()
        {
            return GetStatMods("mp");
        }

        public int MPRMods() 
        {
            return GetStatMods("mpr");
        }

        private double GetBaseStatMods(string stat)
        {
            double baseStat = 0;
            baseStat += weapon      != null ?      weapon.modifier.Get(stat) : 0;
            baseStat += topArmor    != null ?    topArmor.modifier.Get(stat) : 0;
            baseStat += bottomArmor != null ? bottomArmor.modifier.Get(stat) : 0;
            baseStat += accessory1  != null ?  accessory1.modifier.Get(stat) : 0;
            baseStat += accessory2  != null ?  accessory2.modifier.Get(stat) : 0;
            baseStat += accessory3  != null ?  accessory3.modifier.Get(stat) : 0;
            return baseStat;
        }
    }
}
