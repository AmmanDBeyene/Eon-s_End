using EECore.Enums;
using System.Collections.Generic;

namespace EECore.Items.Accessories
{
    class FireballRing : Accessory
    {
        public FireballRing() : base(
            "Fireball Ring", 
            "A ring capable of conjuring a fireball")
        {
            //         ~
            //        ~~~
            //       ~~@~~   
            TargetNode n0 = new TargetNode(Direction.Up);

            //         ~
            //        ~~~
            //       ~@#@~   
            TargetNode n0a = n0.Connect(new TargetNode(Direction.Left));
            TargetNode n0b = n0.Connect(new TargetNode(Direction.Right));

            //         ~
            //        ~~~
            //       @###@   
            n0a.Connect(new TargetNode(Direction.Left));
            n0b.Connect(new TargetNode(Direction.Right));

            //         ~
            //        @@@
            //       #####   
            n0a.Connect(new TargetNode(Direction.Up));
            n0b.Connect(new TargetNode(Direction.Up));
            TargetNode n0c = n0.Connect(new TargetNode(Direction.Up));

            //         @
            //        ###
            //       ##o##  
            n0c.Connect(new TargetNode(Direction.Up));

            targetTree = n0;

            // supposedly a -1 skip means the target node does not offset itself
            TargetNode c0 = new TargetNode(-1, Direction.Up);
            c0.Connect(new TargetNode(Direction.Up));
            c0.Connect(new TargetNode(Direction.Right));
            c0.Connect(new TargetNode(Direction.Down));
            c0.Connect(new TargetNode(Direction.Left));

            aoeTree = c0;

            cost = 9;
        }

        public override void Use(List<Combatant> targets)
        {
            if (owner == null || targets.Count <= 0)
            {
                return;
            }

            targets.ForEach(t =>
            {
                int damage = (int)(owner.ATK.Current() - t.character.DEF.Current() / 3.0);
                if (damage > 0)
                {
                    targets[0].character.HP.Modify(-damage);
                }
            });
        }
    }
}
