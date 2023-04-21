using Assets.Event_Editor.Event_Scripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.MemoryProfiler;
using UnityEngine;

namespace Assets.Event_Editor.Scripts
{
    public class CompoundBlock
    {
        private static string _compoundSavePath = "Assets/Event Editor/Compound Blocks";

        [SerializeField]
        public List<Block> blocks { get; protected set; } = new List<Block>();

        [SerializeField]
        public List<Connection> connections { get; protected set; }  = new List<Connection>();

        [SerializeField]
        public string name;

        public CompoundBlock(List<Block> blocks)
        {
            this.blocks = blocks;

            // generate connections list from blocks
            StaticEditor.connections.ForEach(i =>
            {
                Block outgoing = i.outgoing;
                Block incoming = i.incoming;

                if (connections.Contains(i))
                {
                    return;
                }

                if (blocks.Contains(outgoing) || blocks.Contains(incoming)) 
                {
                    connections.Add(i);
                }
            });

            this.name = "Name";
        }

        public void Save(string path)
        {
            try
            {
                // make sure our block positions and types are all ready for saving 
                blocks.ForEach(i => i.savePosition = i.visualElement.GlobalPosition());
                blocks.ForEach(i => i.saveNode = (BlockNode)i.visualElement.InterpretAs(i.nodeType));

                // write ourselves to a file
                File.WriteAllText(path, this.Serialize().json);
            }
            catch (Exception e)
            {
                StaticEditor.ShowError("An error has occured while creating a compound block. Check console for details.");
                Debug.LogError(e);
            }
        }

        public void CreateAt(Vector3 position)
        {
            int id = ++StaticEditor.compoundBlockIndex;

            Dictionary<Block, Block> cloned = new Dictionary<Block, Block>();

            // go through all connections and clone all blocks participating
            connections.ForEach(connection =>
            {
                // clone our incoming / outgoing blocks
                Block outgoing = connection.outgoing;
                Block incoming = connection.incoming;

                // populate the reassignment dictionary. 
                if (!cloned.ContainsKey(outgoing))
                {
                    cloned.Add(outgoing, outgoing.Clone());
                }

                if (!cloned.ContainsKey(incoming))
                {
                    cloned.Add(incoming, incoming.Clone());
                }
            });

            // create our clones
            cloned.Values.ToList().ForEach(block =>
            {
                block.compoundBlockId = id;
                StaticEditor.blocks.Add(block);
                block.CreateAt(block.savePosition);
            });

            List<Connection> newConnections = new List<Connection>();

            // restore our connections BUT with clones
            foreach (Connection connection in connections)
            {
                StaticEditor.outgoingBlock = cloned[connection.outgoing];
                StaticEditor.incomingBlock = cloned[connection.incoming];
                StaticEditor.builtConnection = new Connection(StaticEditor.outgoingBlock, StaticEditor.incomingBlock);

                StaticEditor.outgoingBlock.outgoingTo.Add(StaticEditor.incomingBlock);

                StaticEditor.connections.Add(StaticEditor.builtConnection);
                newConnections.Add(StaticEditor.builtConnection);

                // No need to try and change the pipe type of this block
                if (StaticEditor.outgoingBlock.pipeType != PipeType.None)
                {
                    continue;
                }

                // Set our pipe type to the incoming block's equivalent pipe type
                StaticEditor.outgoingBlock.pipeType = StaticEditor.incomingBlock.type.ToPipeType();
            }

            // re render new connections
            newConnections.ForEach(i => i.ReRender());

            // re render cloned blocks
            cloned.Values.ToList().ForEach(block => { block.RestoreData(); });
        }

        public static CompoundBlock Load(string path)
        {
            CompoundBlock cockData = null;

            try
            {
                SerializationData data = new SerializationData(File.ReadAllText(path));
                cockData = (CompoundBlock)data.Deserialize();
            }
            catch (Exception e)
            {
                StaticEditor.ShowError("An error has occured while loading a compound block. Check console for details.");
                Debug.LogError(e);
            }

            return cockData;
        }
    }
}
