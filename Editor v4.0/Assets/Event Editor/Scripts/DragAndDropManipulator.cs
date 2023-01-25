using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using UnityEngine;

namespace Assets.Event_Editor.Scripts
{
    public class DragAndDropManipulator : PointerManipulator
    {
        public DragAndDropManipulator(VisualElement target)
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

        private Vector2 targetStartPosition { get; set; }

        private Vector3 pointerStartPosition { get; set; }

        private bool enabled { get; set; }

        private VisualElement root { get; }

        private void PointerDownHandler(PointerDownEvent evt)
        {
            targetStartPosition = target.transform.position;
            pointerStartPosition = evt.position;
            target.CapturePointer(evt.pointerId);
            enabled = true;
        }

        private void PointerMoveHandler(PointerMoveEvent evt)
        {
            if (enabled && target.HasPointerCapture(evt.pointerId))
            {
                Vector3 pointerDelta = evt.position - pointerStartPosition;
                target.transform.position = new Vector2(targetStartPosition.x + pointerDelta.x, targetStartPosition.y + pointerDelta.y);
            }
        }

        private void PointerUpHandler(PointerUpEvent evt)
        {
            if (enabled && target.HasPointerCapture(evt.pointerId))
            {
                target.ReleasePointer(evt.pointerId);
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
