using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    public class Block
    {
        public bool deleted { get; private set; }
        public VisualElement visualElement { get; private set; }
        public Block(VisualElement ve)
        {
            visualElement = ve;
            deleted = false;
        }

        public void Delete()
        {
            visualElement.parent.Remove(visualElement);
            deleted = true;
        }
    }
}
