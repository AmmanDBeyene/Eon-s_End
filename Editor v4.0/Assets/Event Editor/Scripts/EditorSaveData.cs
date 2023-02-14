using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Event_Editor.Scripts
{
    public class EditorSaveData
    {
        [SerializeField]
        public List<Block> blocks = new List<Block>();

        [SerializeField]
        public List<Connection> connections = new List<Connection>();

        public EditorSaveData(List<Block> blocks, List<Connection> connections)
        {
            this.blocks = blocks;
            this.connections = connections;
        }
    }
}
