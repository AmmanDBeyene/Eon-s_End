using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore.Items
{
    public class Modifier
    {
        public float health             { get; }
        public float attack             { get; }
        public float defense            { get; }
        public float movementPoints     { get; }
        public float movementPointRegen { get; }
        public float speed              { get; }

        public int duration             { get; }
        public bool permanent           { get; }

        public Modifier() : this (0, 0, 0, 0, 0, 0) { }
        
        public Modifier(
            float health,
            float attack,
            float defense,
            float movementPoints,
            float movementPointRegen,
            float speed)
        {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
            this.movementPoints = movementPoints;
            this.movementPointRegen = movementPointRegen;
            this.speed = speed;
        }

        public double Get(string stat)
        {
            switch (stat.ToLower())
            {
                case "hp":
                case "health":
                    return health;
                case "atk":
                case "attack":
                    return attack;
                case "def":
                case "defense":
                    return defense;
                case "mp":
                case "movement":
                case "movementpoints":
                case "movement points":
                    return movementPoints;
                case "mpr":
                case "mpregen":
                case "mp regen":
                case "movementpointregen":
                case "movementpointsregen":
                case "movement point regen":
                case "movement points regen":
                    return movementPointRegen;
                case "spd":
                case "speed":
                    return speed;
            }
            return 0;
        }
    }
}
