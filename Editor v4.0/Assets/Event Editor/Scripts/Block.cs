using System;
using System.Collections.Generic;

using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UIElements;

using Assets.Event_Scripts;
using Assets.Event_Editor.Event_Scripts;
using Assets.Event_Scripts.Event_Commands;

namespace Assets.Event_Editor.Scripts
{
    public class Block
    {
        [DoNotSerialize]
        public bool deleted { get; private set; }

        [DoNotSerialize]
        public bool created { get; private set; }

        [DoNotSerialize]
        public VisualElement visualElement { get; private set; }

        [DoNotSerialize]
        public BlockManipulator manipulator { get; private set; }

        [DoNotSerialize]
        public List<Block> outgoingTo { get; private set; }

        [Serialize]
        private string _assetString { get; set; }

        public BlockType type { get; private set; }
        public PipeType pipeType { get; set; }

        public Vector3 savePosition;
        public BlockNode saveNode;
        public Type nodeType;

        public Block(string assetString, BlockType type, Type nodeType)
        {
            outgoingTo = new List<Block>();

            deleted = false;
            created = false;

            _assetString = assetString;
            this.type = type;

            pipeType = PipeType.None;
            this.nodeType = nodeType;
        }

        public void RestoreData()
        {
            if (saveNode == null)
            {
                return; // can't restore data from nothing
            }

            saveNode.RestoreTo(visualElement, nodeType);
        }

        public IEventPipe Compile()
        {
            if (outgoingTo.Count <= 0 || saveNode == null)
            {
                return null; // there is no event pipe to compile
            }

            switch (pipeType)
            {
                case PipeType.Command:
                    CommandPipeSystem mps = new CommandPipeSystem((CommandNode)outgoingTo[0].saveNode);
                    saveNode.ConnectTo(mps);
                    return mps;

                case PipeType.Condition:
                    ConditionPipeSystem nps = new ConditionPipeSystem();
                    outgoingTo.ForEach(i => nps.conditions.Add((ConditionNode)i.saveNode));
                    saveNode.ConnectTo(nps);
                    return nps;
            }

            return null;
        }

        public void CreateAt(Vector3 globalPosition)
        {
            // We really should not create this block again if it has already been created once
            if (created)
            {
                return;
            }

            // Create the Block which this tile represents
            VisualElement block = Extensions.Load(_assetString).Instantiate();


            // Find all dropdowns
            List<DropdownField> dropdowns = new List<DropdownField>();
            block
                .FindAll(typeof(DropdownField))
                .ForEach(i => dropdowns.Add((DropdownField)i));

            // Set all single value dropdowns to their default value
            dropdowns
                .FindAll(i => i.choices.Count == 1)
                .ForEach(i => i.value = i.choices[0]);


            // Find all radio button groups and set them to always be on their default 
            // value
            List<RadioButtonGroup> radioButtons = new List<RadioButtonGroup>();
            block
                .FindAll(typeof(RadioButtonGroup))
                .ForEach(i => ((RadioButtonGroup)i).value = 0);

            // Set up the contents of the block
            block.SetUp(nodeType);

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

            // Add our block connector pair to the absolute area
            StaticEditor.area.Add(connector);

            // Set the connector position to the target position using our offset
            connector.transform.position = connector.WorldToLocal(globalPosition);

            // Make sure the connector is snapped into a snappable place
            manipulator.ForceSnap();

            // Mark this block as created
            created = true;

            // Store a reference to our created block / connector pair
            visualElement = connector;

            outgoingTo = new List<Block>();
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
