using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    class TileManipulator : PointerManipulator
    {
        private VisualTreeAsset _blockToCreate { get; set; }
        private VisualElement _parent { get; set; }
        private string _name { get; set; }
        private Vector2 _targetOrigin { get; set; }
        private Vector2 _globalMousePosition { get; set; }
        private Vector2 _relativeMousePosition { get; set; }
        private Vector2 _initialOffset { get; set; }
        private bool _enabled { get; set; }
        public TileManipulator(VisualElement target, string name, VisualTreeAsset blockToCreate)
        {
            // Set manipulator target
            this.target = target;

            _blockToCreate = blockToCreate;
            _name = name;

            VisualElement icon = target.Find("BlockIcon");
            TextElement text = (TextElement)target.Find("BlockText");
            text.text = name;
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
            // Make tile slightly opaque
            target.style.opacity = 0.5f;

            // Move tile in front of evrything
            target.BringToFront();

            // Save our target origin, global mouse position, and relative mouse position.
            _targetOrigin = target.transform.position;
            _relativeMousePosition = target.WorldToLocal(evt.position);
            _globalMousePosition = evt.position;

            // Determine the offset between the target origin and mouse pointer
            _initialOffset = _targetOrigin - _globalMousePosition;

            // Save the parent of this target so we can return ownership to this parent
            _parent = target.parent;

            // Start capturing mouse pointer events
            target.CapturePointer(evt.pointerId);

            // This element is enabled
            _enabled = true;

            // Set some relevant variables in Static Editor
            StaticEditor.tileDragTarget = target;
            StaticEditor.tileName = _name;
            StaticEditor.canvasHasTile = false;
        }

        private void PointerMoveHandler(PointerMoveEvent evt)
        {
            if (_enabled && target.HasPointerCapture(evt.pointerId))
            {
                target.transform.position = (Vector2)evt.position + _initialOffset;

                if (StaticEditor.canvas.ContainsPoint(StaticEditor.canvas.WorldToLocal(evt.position)))
                {
                    if (!StaticEditor.canvasHasTile)
                    {
                        // Transfer ownership
                        StaticEditor.canvas.Add(target);

                        // Calculate cursor offset perspective to new owner
                        Vector2 tileOrigin = target.LocalToWorld(_relativeMousePosition);
                        Vector2 cursor = evt.position;
                        Vector2 toCursor = cursor - tileOrigin; // global x / y to move tile to cursor

                        // Modify offset by the cursor offset
                        _initialOffset += toCursor;

                        // Indicate that the canvas now has ownership of the tile
                        StaticEditor.canvasHasTile = true;
                    } else
                    {
                        // move the tile on the canvas
                    }
                }

            }
        }

        private void PointerUpHandler(PointerUpEvent evt)
        {
            if (_enabled && target.HasPointerCapture(evt.pointerId))
            {
                // Create the Block which this tile represents
                // VisualElement block = _represents.Instantiate();

                // Change opacity back to normal
                target.style.opacity = 1.0f;

                // Release pointer capture
                target.ReleasePointer(evt.pointerId);

                // Transfer ownership back to parent
                _parent.Add(target);

                // Send object back to where it was originally
                target.transform.position = Vector3.zero; 

                // Change static variable controls back to defaults
                StaticEditor.tileDragTarget = null;
                StaticEditor.tileName = null;
            }
        }

        private void PointerCaptureOutHandler(PointerCaptureOutEvent evt)
        {
            const float roundTo = 20;

            // snap the position to the nearest 10 pixels ( so things can be neatly aligned)
            Vector3 pos = target.transform.position;
            int x = (int) (Mathf.Round(pos.x / roundTo) * roundTo);
            int y = (int) (Mathf.Round(pos.y / roundTo) * roundTo);

            x = x - x % (int)roundTo;
            y = y - y % (int)roundTo;

            target.transform.position = new Vector3(x, y, pos.z);
        }
    }
}