using Assets.EE_Core.Enums;
using EECore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore.Items
{
    public class TargetNode
    {
        public int skip { get; private set; }
        public Direction direction { get; private set; }
        public List<TargetNode> connections { get; private set; }

        public TargetNode(Direction direction) : this(0, direction) { }

        public TargetNode(int skip, Direction direction)
        {
            this.skip = skip;
            this.direction = direction;
            connections = new List<TargetNode>();
        }

        public TargetNode Connect(TargetNode node)
        {
            connections.Add(node);
            return node;
        }
    }

    public abstract class SkillItem : Item
    {
        public bool aoe { get; protected set; } = false;
        
        public TargetNode targetTree { get; protected set; }
        
        public int cost { get; protected set; } = 0;
        
        public Character owner { get; set; } = null;

        public CharacterFilterType characterFilter { get; protected set; }

        public SkillItem(
            string name, 
            string description) : this(name, description, new Modifier()) { }

        public SkillItem(
            string name, 
            string description, 
            Modifier modifier)
            : base(name, description, modifier) 
        {
            characterFilter = CharacterFilterType.Enemy;
        }

        public abstract void Use(List<Character> targets);
    }
}
