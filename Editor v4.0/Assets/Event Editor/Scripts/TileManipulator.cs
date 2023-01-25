using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    class TileManipulator : PointerManipulator
    {
        private VisualTreeAsset _represents;
        private VisualElement _parent;
        private string _name;
        public TileManipulator(VisualElement target, string name, VisualTreeAsset represents)
        {
            this.target = target;
            root = target.parent;
            _represents = represents;
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

        private Vector2 targetStartPosition { get; set; }
        private Vector2 pointerStartPosition { get; set; }
        private Vector2 pointerWithinTargetPosition { get; set; }
        private Vector2 initialOffset { get; set; }
        private bool enabled { get; set; }
        private VisualElement root { get; }

        private void PointerDownHandler(PointerDownEvent evt)
        {
            target.style.opacity = 0.5f;
            target.BringToFront();

            targetStartPosition = target.transform.position;
            pointerWithinTargetPosition = target.WorldToLocal(evt.position);
            pointerStartPosition = evt.position;

            initialOffset = targetStartPosition - pointerStartPosition; // world offset

            target.CapturePointer(evt.pointerId);
            enabled = true;

            StaticEditor.tileDragTarget = target;
            StaticEditor.tileName = _name;
            StaticEditor.canvasHasTile = false;
        }

        private void PointerMoveHandler(PointerMoveEvent evt)
        {
            if (enabled && target.HasPointerCapture(evt.pointerId))
            {

                target.transform.position = (Vector2)evt.position + initialOffset;

                if (StaticEditor.canvas.ContainsPoint(StaticEditor.canvas.WorldToLocal(evt.position)))
                {
                    if (!StaticEditor.canvasHasTile)
                    {
                        // Transfer ownership
                        StaticEditor.canvas.Add(target);

                        // Calculate cursor offset perspective to new owner
                        Vector2 tileOrigin = target.LocalToWorld(pointerWithinTargetPosition);
                        Vector2 cursor = evt.position;
                        Vector2 toCursor = cursor - tileOrigin; // global x / y to move tile to cursor

                        // Modify offset by the cursor offset
                        initialOffset += toCursor;

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
            if (enabled && target.HasPointerCapture(evt.pointerId))
            {
                // Create the Block which this tile represents
                VisualElement block = _represents.Instantiate();

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