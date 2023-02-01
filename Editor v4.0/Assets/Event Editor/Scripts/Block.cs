using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    public class Block
    {
        public bool deleted { get; private set; }
        public bool created { get; private set; }
        public VisualElement visualElement { get; private set; }
        public BlockManipulator manipulator { get; private set; }
        public List<Block> outgoingTo { get; private set; }
        private VisualTreeAsset _factoryAsset { get; set; }

        public BlockType type { get; private set; }
        public PipeType pipeType { get; set; }
        public Block(VisualTreeAsset asset, BlockType type)
        {
            outgoingTo = new List<Block>();
            deleted = false;
            created = false;

            _factoryAsset = asset;
            this.type = type;

            pipeType = PipeType.None;
        }

        public void CreateAt(Vector3 globalPosition)
        {
            // We really should not create this block again if it has already been created once
            if (created)
            {
                return;
            }

            // Create the Block which this tile represents
            VisualElement block = _factoryAsset.Instantiate();

            // Create connector which will house the block
            VisualElement connector = Extensions.Create("Assets/Event Editor/UI/Connector.uxml");

            // Set position to absolute so the placement of this connector
            // does not affect the placement of any other block connector pairs. 
            connector.style.position = Position.Absolute;

            // Put block in connector "Connector" component
            connector.Find("Connector").Add(block);

            // Change our connector color based on block type
            connector.Find("Connector").style.backgroundColor = type == BlockType.Command
                ? new Color(12 / 255.0f, 152 / 255.0f, 200 / 255.0f)
                : new Color(252 / 255.0f, 152 / 255.0f, 56 / 255.0f);

            // Attach a drag and drop manipulator to our block connector pair 
            // so we can move the whole thing around
            manipulator = new BlockManipulator(connector, this);

            // Find the absolute positioning area within the canvas
            VisualElement area = StaticEditor.canvas.Find("AbsoluteArea");

            // Add our block connector pair to the absolute area
            area.Add(connector);

            // Set the connector position to the target position using our offset
            connector.transform.position = connector.WorldToLocal(globalPosition);

            // Make sure the connector is snapped into a snappable place
            manipulator.ForceSnap();

            // Mark this block as created
            created = true;

            // Store a reference to our created block / connector pair
            visualElement = connector;
        }

        public void UpdateState()
        {
            if (outgoingTo.Count <= 0)
            {
                pipeType = PipeType.None;
            }
        }

        public void Delete()
        {
            // Delete linked visual element
            visualElement.parent.Remove(visualElement);

            // Remove self from blocks list
            StaticEditor.blocks.Remove(this);

            // Remove any linked connectors
            StaticEditor.connections
                .FindAll(i => i.outgoing == this || i.incoming == this)
                .ForEach(i => i.Delete());

            // Update any blocks with a pipe to this block
            StaticEditor.blocks
                .FindAll(i => i.outgoingTo.Contains(this))
                .ForEach(i => i.UpdateState());

            deleted = true;
        }
    }
}
