using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    internal static class StaticEditor
    {
        public const int SNAP_RADIUS = 20;
        public const int CONNECTION_SELECTION_WIDTH = 20;
        public static readonly Color CONNECTION_LINE_COLOR = new Color(1, 1, 1);
        public static readonly Color BLOCK_BORDER_COLOR = new Color(42 / 255.0f, 42 / 255.0f, 42 / 255.0f);
        public static readonly Color SELECTION_COLOR = new Color(47 / 255.0f, 114 / 255.0f, 168 / 255.0f);

        public static List<Block> blocks = new List<Block>();
        public static List<Connection> connections = new List<Connection>();
        public static List<VisualElement> selectedBlocks = new List<VisualElement>();
        public static List<Connection> selectedConnections = new List<Connection>();

        public static VisualElement canvas = null;
        public static VisualElement ui = null;
        public static VisualElement tileDragTarget = null;
        public static string tileName = null;
        public static bool canvasHasTile = false;

        public static DotManipulator startDot = null;
        public static DotManipulator endDot = null;

        public static Block outgoingBlock = null;
        public static Block incomingBlock = null;

        public static Connection builtConnection = null;

        public static bool makingConnection = false;

        #region Block Selection

        public static void Select(VisualElement element)
        {
            // check if this is single or multiple selection
            if (Keyboard.KeyDown(KeyCode.LeftControl))
            {
                MultiSelect(element);
                return;
            }

            SingleSelect(element);
        }

        public static void DeleteSelection()
        {
            foreach (VisualElement selected in selectedBlocks)
            {
                blocks.Delete(selected);
            }
            foreach (Connection connection in selectedConnections)
            {
                connection.Delete();
            }
        }

        public static void AddSelect(VisualElement element)
        {
            // Add selected element to selection and apply style
            selectedBlocks.Add(element);
            ApplySelectStyle(element);
        }

        public static void DeselectAll()
        {
            // Revert all the styles on any things we may have selected
            // as we're about to deselect them
            foreach (VisualElement selected in selectedBlocks)
            {
                RevertSelectStyle(selected);
            }

            foreach (Connection connection in selectedConnections)
            {
                RevertSelectStyle(connection);
            }

            // Clear the selection list to finish deselection
            selectedBlocks.Clear();
            selectedConnections.Clear();
        }

        private static void MultiSelect(VisualElement element)
        {
            // If we have already selected this element deselect it
            if (selectedBlocks.Contains(element))
            {
                selectedBlocks.Remove(element);
                RevertSelectStyle(element);
                return;
            }

            // Add selected element to selection and apply style
            AddSelect(element);
        }
        
        private static void SingleSelect(VisualElement element)
        {
            // Deselect any thing that might have been selected
            DeselectAll();

            // Add selected element to selection and apply style
            AddSelect(element);
        }

        private static void ApplySelectStyle(VisualElement element)
        {
            element.BringToFront();
            element.style.BorderRadius(5);
            element.style.BorderColor(SELECTION_COLOR);
            element.style.BorderWidth(2);
            element.style.marginTop = -2;
            element.style.marginLeft = -2;
        }

        private static void RevertSelectStyle(VisualElement element)
        {
            element.style.BorderWidth(1);
            element.style.BorderColor(BLOCK_BORDER_COLOR);
            element.style.marginTop = 0;
            element.style.marginLeft = 0;
        }
        #endregion

        #region Connection Selection

        public static void Select(Connection connection)
        {
            // check if this is single or multiple selection
            if (Keyboard.KeyDown(KeyCode.LeftControl))
            {
                MultiSelect(connection);
                return;
            }

            SingleSelect(connection);
        }

        public static void AddSelect(Connection connection)
        {
            // Add selected element to selection and apply style
            selectedConnections.Add(connection);
            ApplySelectStyle(connection);
        }

        private static void MultiSelect(Connection connection)
        {
            // If we have already selected this element deselect it
            if (selectedConnections.Contains(connection))
            {
                selectedConnections.Remove(connection);
                RevertSelectStyle(connection);
                return;
            }

            // Add selected element to selection and apply style
            AddSelect(connection);
        }

        private static void SingleSelect(Connection connection)
        {
            // Deselect any thing that might have been selected
            DeselectAll();

            // Add selected element to selection and apply style
            AddSelect(connection);
        }

        private static void ApplySelectStyle(Connection connection)
        {
            VisualElement top = connection.lineBlock.Find("Top");
            VisualElement bot = connection.lineBlock.Find("Bot");
            top.style.BorderColor(SELECTION_COLOR);
            bot.style.BorderColor(SELECTION_COLOR);
        }

        private static void RevertSelectStyle(Connection connection)
        {
            VisualElement top = connection.lineBlock.Find("Top");
            VisualElement bot = connection.lineBlock.Find("Bot");
            top.style.BorderColor(CONNECTION_LINE_COLOR);
            bot.style.BorderColor(CONNECTION_LINE_COLOR);
        }

        #endregion

        #region Connection

        public static void InvalidateConnections()
        {
            // invalidate the connection for the start and end dots
            endDot?.InvalidateConnection();
            startDot?.InvalidateConnection();

            // reset static editor properties
            makingConnection = false;

            endDot = null;
            startDot = null;

            outgoingBlock = null;
            incomingBlock = null;
        }
        public static void ConnectBlocks()
        {
            // TODO: finish this function
            Debug.Log("Establishing connection between:");

            builtConnection.incoming = incomingBlock;
            builtConnection.outgoing = outgoingBlock;

            outgoingBlock.outgoingTo.Add(incomingBlock);

            builtConnection.ReRender();

            connections.Add(builtConnection);

        }

        #endregion
    }

    internal static class Keyboard
    {
        internal static Dictionary<KeyCode, bool> keyCache = new Dictionary<KeyCode, bool>();
        internal static void ChangeKeyState(KeyCode code, bool state)
        {
            keyCache[code] = state;
        }

        public static bool KeyDown(KeyCode code)
        {
            return keyCache.ContainsKey(code) && keyCache[code];
        }

        public static bool KeyUp(KeyCode code)
        {
            return !keyCache.ContainsKey(code) || keyCache[code];
        }
    }
}
