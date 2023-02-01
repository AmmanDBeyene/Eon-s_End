using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    class Connection
    {
        private Block _outgoing;
        public Block outgoing
        {
            get
            {
                return _outgoing;
            }
            set
            {
                _outgoing = value;
                _outgoingNode = value?.visualElement.Find("DotBot");
            }
        }

        private Block _incoming;
        public Block incoming
        {
            get
            {
                return _incoming;
            }
            set
            {
                _incoming = value;
                _incomingNode = value?.visualElement.Find("DotTop");
            }

        }

        private VisualElement _outgoingNode;
        private VisualElement _incomingNode;

        private Vector3 _worldOrigin;

        public VisualElement lineBlock { get; private set; }

        private bool _lastOutRightOfIn = false;
        private bool _lastOutEqualIn = false;
        private bool _lastInBelowOut = false;

        public Connection(Block outgoing, Block incoming)
        {
            this.outgoing = outgoing;
            this.incoming = incoming;
        }

        public void ReRender()
        {
            ReRender(_outgoingNode.GlobalCenter(), _incomingNode.GlobalCenter());
        }

        public void ReRender(Vector3 globalPosOut, Vector3 globalPosIn)
        {
            bool first = false;

            if (lineBlock == null)
            {
                lineBlock = Extensions.Create("Assets/Event Editor/UI/LineBox.uxml");
                lineBlock.focusable = false;
                lineBlock.pickingMode = PickingMode.Ignore;
                lineBlock.style.position = Position.Absolute;
                StaticEditor.canvas.Add(lineBlock);
                _worldOrigin = lineBlock.LocalToWorld(Vector3.zero);
                first = true;
            }

            Vector3 globalPosBlock = lineBlock.GlobalPosition();
            Vector3 globalTopLeft = new Vector3(Math.Min(globalPosIn.x, globalPosOut.x), Math.Min(globalPosIn.y, globalPosOut.y), 0.0f);
            Vector3 globalBotRight = new Vector3(Math.Max(globalPosIn.x, globalPosOut.x), Math.Max(globalPosIn.y, globalPosOut.y), 0.0f);
            Vector3 globalDelta = globalTopLeft - globalPosBlock; // how much we need to move the block

            if (globalDelta.magnitude != 0)
            {
                lineBlock.transform.position += globalDelta;
            }
            

            lineBlock.Find("MainBox").style.width = (int) Math.Clamp(globalBotRight.x - globalTopLeft.x, 4, double.MaxValue);
            lineBlock.Find("MainBox").style.height = (int) Math.Clamp(globalBotRight.y - globalTopLeft.y, 4, double.MaxValue);

            bool outRightOfIn = globalPosOut.x > globalPosIn.x;
            bool outEqualIn = Math.Abs(globalPosOut.x - globalPosIn.x) < 3;
            bool inBelowOut = globalPosIn.y > globalPosOut.y;

            // if we dont need to make graphical changes to the way the line block looks
            if (!first && outRightOfIn == _lastOutRightOfIn && outEqualIn == _lastOutEqualIn && inBelowOut == _lastInBelowOut)
            {   
                _lastOutRightOfIn = outRightOfIn;
                _lastOutEqualIn = outEqualIn;
                _lastInBelowOut = inBelowOut;

                // we are done re-rendering   
                return; 
            }

            _lastOutRightOfIn = outRightOfIn;
            _lastOutEqualIn = outEqualIn;
            _lastInBelowOut = inBelowOut;


            VisualElement top = lineBlock.Find("Top");
            VisualElement bot = lineBlock.Find("Bot");

            top.style.BorderColor(StaticEditor.CONNECTION_LINE_COLOR);
            bot.style.BorderColor(StaticEditor.CONNECTION_LINE_COLOR);

            if (outEqualIn)
            {
                top.style.borderLeftWidth = 2;
                top.style.borderRightWidth = 0;
                bot.style.borderLeftWidth = 2;
                bot.style.borderRightWidth = 0;
                top.style.borderBottomWidth = 0;
                return;
            }

            if (!inBelowOut)
            {
                top.style.borderLeftWidth = outRightOfIn ? 2 : 0;
                top.style.borderRightWidth = outRightOfIn ? 0 : 2;
            } else
            {
                top.style.borderLeftWidth = outRightOfIn ? 0 : 2;
                top.style.borderRightWidth = outRightOfIn ? 2 : 0;
            }

            bot.style.borderLeftWidth = top.style.borderRightWidth;
            bot.style.borderRightWidth = top.style.borderLeftWidth;

            top.style.borderBottomWidth = 2;
        }

        public bool Contains(Vector3 globalPoint)
        {
            // Check if the point is within the line block
            if (!lineBlock.Contains(globalPoint))
            {
                return false;
            }

            // Find the elements we are going to be working on 
            VisualElement top = lineBlock.Find("Top");
            VisualElement bot = lineBlock.Find("Bot");
            
            // Do some maths so the rect construction doesn't look godawful
            float halfWidth = StaticEditor.CONNECTION_SELECTION_WIDTH / 2.0f;

            float leftX = lineBlock.GlobalPosition().x - halfWidth;

            float rightX = lineBlock.GlobalPosition().x + lineBlock.Width() - halfWidth;

            float topX = top.style.borderLeftWidth == 2 ? leftX : rightX;
            float botX = bot.style.borderLeftWidth == 2 ? leftX : rightX;

            // Construct our top rectangle (double lines)
            // ║
            // ╙─────┐
            //       │
            Rect topCol = new Rect(
                topX, 
                top.GlobalPosition().y,
                StaticEditor.CONNECTION_SELECTION_WIDTH,
                top.Height());

            // Construct our middle rectangle (double lines)
            // │
            // ╘═════╕
            //       │
            Rect midCol = new Rect(
                top.GlobalPosition().x - halfWidth,
                bot.GlobalPosition().y - halfWidth,
                top.Width(), 
                StaticEditor.CONNECTION_SELECTION_WIDTH);

            // Construct our middle rectangle (double lines)
            // │
            // └─────╖
            //       ║
            Rect botCol = new Rect(botX, bot.GlobalPosition().y,
                StaticEditor.CONNECTION_SELECTION_WIDTH,
                bot.Height());

            // See if our point is contained within any of our rects
            return topCol.Contains(globalPoint) || midCol.Contains(globalPoint) || botCol.Contains(globalPoint);
        }

        public void Delete()
        {
            // Delete linked visual element
            lineBlock.parent.Remove(lineBlock);

            // Remove self from connections list
            StaticEditor.connections.Remove(this);

            // Update block outgoing connection lists
            outgoing.outgoingTo.Remove(incoming);

            // Update the outgoing block's pipe state
            outgoing.UpdateState();
        }
    }
}
