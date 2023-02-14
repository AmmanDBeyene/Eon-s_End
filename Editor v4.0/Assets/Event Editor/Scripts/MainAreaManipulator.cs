using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;
using UnityEngine;

namespace Assets.Event_Editor.Scripts
{
    public class MainAreaManipulator : PointerManipulator
    {
        private Vector2 _targetStartPosition { get; set; }
        private Vector3 _pointerStartPosition { get; set; }

        private bool _enabled { get; set; } = true;
        private bool _capturing { get; set; }
        private VisualElement _selectionSquare { get; set; }
        private float _stickyRadius { get; set; } = 10;
        private bool _stuck = true;
        public MainAreaManipulator()
        {
            this.target = StaticEditor.canvas;
            _capturing = false;

            CreateSquare();
        }

        private void CreateSquare()
        {
            _selectionSquare = new VisualElement();

            _selectionSquare.style.BorderColor(new Color(47 / 255.0f, 114 / 255.0f, 168 / 255.0f));
            _selectionSquare.style.BorderWidth(2);
            _selectionSquare.style.BorderRadius(5);

            _selectionSquare.style.position = Position.Absolute;
            _selectionSquare.style.top = 0;
            _selectionSquare.style.left = 0;

            _selectionSquare.style.width = 0; 
            _selectionSquare.style.height = 0;

            StaticEditor.canvas.Add(_selectionSquare);
            _selectionSquare.visible = false;
        }

        private void UpdateSquare(Vector3 delta)
        {
            // If our delta happens to be negative we have 
            // to move the origin of the square AND change with width / height
            
            _selectionSquare.transform.position = _targetStartPosition;

            _selectionSquare.style.width = delta.x;
            _selectionSquare.style.height = delta.y;

            _selectionSquare.visible = true;
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
            // Graphically update all connections
            // this is so that we can quickly show all the connectors
            // after a load has happened
            StaticEditor.connections.ForEach(i => i.ReRender());

            // ignore anything that isnt a left click
            if (evt.button != 0)
            {
                return;
            }

            _pointerStartPosition = evt.position;

            _targetStartPosition = _selectionSquare.WorldToLocal(_pointerStartPosition);

            // Check the current mouse down position and see if it intersects with any placed connections
            foreach (Connection connection in StaticEditor.connections)
            {

                // If the mouse is contained within a connection select the connection
                // and return. 
                if (connection.Contains(evt.position))
                {
                    StaticEditor.Select(connection);
                    return;
                }
            }

            // Check the current mouse down position and see if it intersects with any placed blocks
            foreach (Block block in StaticEditor.blocks)
            {
                VisualElement ve = block.visualElement;
                
                // If the mouse is contained within any block return
                // as we want that event to have priority over this one. 
                if (ve.Contains(evt.position))
                {
                    return;
                }
            }

            if (StaticEditor.makingConnection)
            {
                StaticEditor.InvalidateConnections();
                return;
            }

            // No blocks are capturing our cursor, we are free to capture the cursor
            // ourselves and proceed with 
            _capturing = true;
            target.CapturePointer(evt.pointerId);
        }

        private void PointerMoveHandler(PointerMoveEvent evt)
        {
            if (!_enabled || !_capturing)
            {
                return;
            }

            Vector3 pointerDelta = evt.position - _pointerStartPosition;
            UpdateSquare(pointerDelta);
        }

        private void PointerUpHandler(PointerUpEvent evt)
        {
            if (!_enabled || !_capturing || evt.button != 0)
            {
                return;    
            }

            Vector3 pointerDelta = evt.position - _pointerStartPosition;

            UpdateSquare(pointerDelta);

            // Deselect all blocks
            StaticEditor.DeselectAll();

            // Go through all the blocks on screen, if any blocks intersect with our
            // selection square add them to our selection. 
            foreach (Block block in StaticEditor.blocks)
            {
                VisualElement ve = block.visualElement;

                if (!ve.Overlaps(_selectionSquare))
                {
                    continue;
                }

                StaticEditor.AddSelect(ve);
            }

            _selectionSquare.visible = false;
            _selectionSquare.transform.position = Vector3.zero;
            _selectionSquare.style.width = 0;
            _selectionSquare.style.height = 0;
            _capturing = false;

            target.ReleasePointer(evt.pointerId);
        }

        private void PointerCaptureOutHandler(PointerCaptureOutEvent evt)
        {
            // uh lmao dont do anything here yet
        }
    }
}
