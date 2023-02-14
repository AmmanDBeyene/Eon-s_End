using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    class DotManipulator : PointerManipulator
    {
        private Block _parent { get; set; }
        private bool _enabled { get; set; }
        public DotType type { get; private set;}
        public DotManipulator(VisualElement target, Block parent, DotType type)
        {
            // Set manipulator target
            this.target = target;

            _parent = parent;
            this.type = type;
        }

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerDownEvent>(PointerDownHandler);
            target.RegisterCallback<PointerMoveEvent>(PointerMoveHandler);
            target.RegisterCallback<PointerUpEvent>(PointerUpHandler);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerDownEvent>(PointerDownHandler);
            target.UnregisterCallback<PointerMoveEvent>(PointerMoveHandler);
            target.UnregisterCallback<PointerUpEvent>(PointerUpHandler);
        }

        private void PointerDownHandler(PointerDownEvent evt)
        {
            if (StaticEditor.makingConnection)
            {
                // if we've clicked on a dot while making a connection this means either
                // a) something has gone very wrong
                // b) we are trying to make a two-click connection

                // Will be assuming (b) by default.

                TryEstablishConnection();

                return;
            }

            // We have clicked on a dot and therefore have started making a connection
            StaticEditor.makingConnection = true;

            // If the dot we have clicked on is an input that means we have first selected the incoming block
            StaticEditor.incomingBlock = type == DotType.Input ? _parent : null;

            // If the dot we have clicked on is an output that means we have first selected the outgoing block
            StaticEditor.outgoingBlock = type == DotType.Output ? _parent : null;

            // This is the dot manipulator out of which the connection was started
            StaticEditor.startDot = this;

            // Create a new connection so we can see a visual of what we're trying to do
            StaticEditor.builtConnection = new Connection(StaticEditor.outgoingBlock, StaticEditor.incomingBlock);

            _enabled = true;

        }

        private void PointerMoveHandler(PointerMoveEvent evt)
        {
            if (!_enabled)
            {
                return;
            }

            // TODO: graphically update our connection ...
            //       only the dot we initially clicked on
            //       gets to do this as it is _enabled
        }

        private void PointerUpHandler(PointerUpEvent evt)
        {
            // Swallow if we arent making a connection. 
            // event is irrelevant.
            if (!StaticEditor.makingConnection)
            {
                return;
            }

            TryEstablishConnection();
        }

        private void TryEstablishConnection()
        {
            // Find the block that we are trying to connect with
            Block otherBlock = StaticEditor.incomingBlock == null
                ? StaticEditor.outgoingBlock
                : StaticEditor.incomingBlock;

            // Check to see if this dot and the other dot have the same parent
            if (_parent == otherBlock)
            {
                return; // dont do anything but most importantly dont invalidate the connection
            }

            // Check to see that this dot's type does not match the other dot's type.
            if (type == StaticEditor.startDot.type)
            {
                StaticEditor.ShowWarning($"Cannot create a connection from {type} to {type}");
                StaticEditor.InvalidateConnections();
                return;
            }

            // All checks passed - we are ready to create this connection.
            StaticEditor.endDot = this;

            // Assign our parent block to the right incoming / outgoing block
            if (StaticEditor.outgoingBlock == null)
            {
                StaticEditor.outgoingBlock = _parent;
            }
            else if (StaticEditor.incomingBlock == null)
            {
                StaticEditor.incomingBlock = _parent;
            }

            // Check to see that this dot's type matches the outgoing block's pipe type 
            if (StaticEditor.outgoingBlock.pipeType != PipeType.None 
                && StaticEditor.outgoingBlock.pipeType != StaticEditor.incomingBlock.type.ToPipeType())
            {
                // Show a warning why the connecion was canceled
                StaticEditor.ShowWarning($"{StaticEditor.outgoingBlock.pipeType} pipe blocks can only connect to {StaticEditor.outgoingBlock.pipeType}s");
                StaticEditor.InvalidateConnections();
                return;
            }

            // Make sure this outgoing block has a command pipe that it can only have one outgoing connection
            if (StaticEditor.outgoingBlock.pipeType == PipeType.Command
                && StaticEditor.outgoingBlock.outgoingTo.Count > 0)
            {
                // Show a warning why the connecion was canceled 
                StaticEditor.ShowWarning($"This block is already connected to a command.");
                StaticEditor.InvalidateConnections();
                return;
            }

            StaticEditor.ConnectBlocks();
            StaticEditor.InvalidateConnections();
        }

        public void InvalidateConnection()
        {
            _enabled = false; // Disable the dot
        }
    }
}
