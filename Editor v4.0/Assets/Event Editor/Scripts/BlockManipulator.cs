using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Event_Editor.Scripts
{
    public class BlockManipulator : PointerManipulator
    {
        private Vector3 _targetStartPosition { get; set; }
        private Vector3 _pointerStartPosition { get; set; }
        private Dictionary<VisualElement, Vector3> _targetStartPositions { get; set; }

        private bool _enabled { get; set; }
        private VisualElement root { get; }
        private float _stickyRadius { get; set; } = 5;
        private bool _stuck = true;
        private Block _parent { get; set; }

        private VisualElement _dotTop;
        private VisualElement _dotBot;

        public BlockManipulator(VisualElement target, Block parent)
        {
            this.target = target;
            root = target.parent;

            _parent = parent;
             
            _dotTop = target.Find("DotTop");
            _dotBot = target.Find("DotBot");

            DotManipulator dtm = new DotManipulator(_dotTop, parent, DotType.Input);
            DotManipulator dbm = new DotManipulator(_dotBot, parent, DotType.Output);
        }
        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerDownEvent>(PointerDownHandler);
            target.RegisterCallback<PointerMoveEvent>(PointerMoveHandler);
            target.RegisterCallback<PointerUpEvent>(PointerUpHandler);
            target.RegisterCallback<PointerCaptureOutEvent>(PointerCaptureOutHandler);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerDownEvent>(PointerDownHandler);
            target.UnregisterCallback<PointerMoveEvent>(PointerMoveHandler);
            target.UnregisterCallback<PointerUpEvent>(PointerUpHandler);
            target.UnregisterCallback<PointerCaptureOutEvent>(PointerCaptureOutHandler);
        }

        private void PointerDownHandler(PointerDownEvent evt)
        {
            _targetStartPosition = target.transform.position;
            _pointerStartPosition = evt.position;

            _targetStartPositions = new Dictionary<VisualElement, Vector3>();
            StaticEditor
                .selectedBlocks.FindAll(i => i != target)
                .ForEach(i => _targetStartPositions.TryAdd(i, i.transform.position));

            // Check if we have clicked on one of our dots we make sure to not capture the pointer
            if (_dotTop.Contains(evt.position))
            {
                return;
            }

            if (_dotBot.Contains(evt.position))
            {
                return;
            }

            target.CapturePointer(evt.pointerId);
            _enabled = true;


            // All blocks start as stuck
            _stuck = true;
        }

        private void PointerMoveHandler(PointerMoveEvent evt)
        {
            if (!_enabled || !target.HasPointerCapture(evt.pointerId))
            {
                return;
            }

            Vector3 pointerDelta = evt.position - _pointerStartPosition;

            // Only move this block if the delta exceeds the sticky radius
            // If the delta exceeds the sticky radius the block becomes "un-stuck"

            if (pointerDelta.magnitude > _stickyRadius)
            {
                target.transform.position = _targetStartPosition + pointerDelta;

                if (StaticEditor.selectedBlocks.Contains(target))
                {
                    // If we have stuff selected, move that suff as well
                    StaticEditor.selectedBlocks
                        // Find all of our selected blocks. Make sure we ourselves are not selected.
                        .FindAll(i => i != target)
                        // Move the selected blocks. 
                        .ForEach(i => i.transform.position = _targetStartPositions[i] + pointerDelta);

                    // Update all selected block connections
                    StaticEditor.selectedBlocks
                        .FindAll(i => i != target)
                        .ForEach(i => StaticEditor.blocks
                            .Find(j => j.visualElement == i).manipulator.UpdateConnectors());
                }
                    
                UpdateConnectors();

                _stuck = false;
            }
        }

        private void PointerUpHandler(PointerUpEvent evt)
        {
            if (!_enabled || !target.HasPointerCapture(evt.pointerId))
            {
                return;
            }

            target.ReleasePointer(evt.pointerId);

            // If the block was not dragged / moved this probably
            // means the user intended to select this block
            if (_stuck)
            {
                StaticEditor.Select(target);
            }
        }

        private void PointerCaptureOutHandler(PointerCaptureOutEvent evt)
        {
            ForceSnap();

            if (StaticEditor.selectedBlocks.Contains(target))
            {
                // Force snap all selected blocks
                StaticEditor.selectedBlocks
                .FindAll(i => i != target)
                .ForEach(i => StaticEditor.blocks
                    .Find(j => j.visualElement == i).manipulator.ForceSnap());
            }
        }

        public void ForceSnap()
        {
            const float roundTo = StaticEditor.SNAP_RADIUS;

            // snap the position to the nearest 10 pixels ( so things can be neatly aligned)
            Vector3 pos = target.transform.position;
            int x = (int)(Mathf.Round(pos.x / roundTo) * roundTo);
            int y = (int)(Mathf.Round(pos.y / roundTo) * roundTo);

            x = x - x % (int)roundTo;
            y = y - y % (int)roundTo;

            target.transform.position = new Vector3(x, y, pos.z);

            // update connectors as our block has probably moved
            UpdateConnectors();
        }

        public void UpdateConnectors()
        {
            // Find all connections where our parent block is referenced
            List<Connection> connections = StaticEditor.connections.FindAll(i => i.incoming == _parent || i.outgoing == _parent);

            // Re-render our connections
            connections.ForEach(i => i.ReRender());
        }
    }
}
