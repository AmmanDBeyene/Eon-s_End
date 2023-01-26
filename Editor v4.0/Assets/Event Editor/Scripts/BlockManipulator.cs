using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    public class BlockManipulator : PointerManipulator
    {

        private Vector2 _targetStartPosition { get; set; }
        private Vector3 _pointerStartPosition { get; set; }
        private bool _enabled { get; set; }
        private VisualElement root { get; }
        private float _stickyRadius { get; set; } = 5;
        private bool _stuck = true;
        public BlockManipulator(VisualElement target)
        {
            this.target = target;
            root = target.parent;
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
            target.CapturePointer(evt.pointerId);
            _enabled = true;

            // All blocks start as stuck
            _stuck = true;
        }

        private void PointerMoveHandler(PointerMoveEvent evt)
        {
            if (_enabled && target.HasPointerCapture(evt.pointerId))
            {
                Vector3 pointerDelta = evt.position - _pointerStartPosition;
                
                // Only move this block if the delta exceeds the sticky radius
                // If the delta exceeds the sticky radius the block becomes "un-stuck"
                if (pointerDelta.magnitude > _stickyRadius)
                {
                    target.transform.position = new Vector2(_targetStartPosition.x + pointerDelta.x, _targetStartPosition.y + pointerDelta.y);
                    _stuck = false;
                }
            }
        }

        private void PointerUpHandler(PointerUpEvent evt)
        {
            if (_enabled && target.HasPointerCapture(evt.pointerId))
            {
                target.ReleasePointer(evt.pointerId);

                // If the block was not dragged / moved this probably
                // means the user intended to select this block
                if (_stuck)
                {
                    StaticEditor.Select(target);
                }
            }
        }

        private void PointerCaptureOutHandler(PointerCaptureOutEvent evt)
        {
            const float roundTo = 20;

            // snap the position to the nearest 10 pixels ( so things can be neatly aligned)
            Vector3 pos = target.transform.position;
            int x = (int)(Mathf.Round(pos.x / roundTo) * roundTo);
            int y = (int)(Mathf.Round(pos.y / roundTo) * roundTo);

            x = x - x % (int)roundTo;
            y = y - y % (int)roundTo;

            target.transform.position = new Vector3(x, y, pos.z);
        }
    }
}
