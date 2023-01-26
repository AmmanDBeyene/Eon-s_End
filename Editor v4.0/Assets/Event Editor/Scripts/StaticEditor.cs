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
        public static List<Block> blocks = new List<Block>();
        public static List<VisualElement> selection = new List<VisualElement>();
        public static VisualElement canvas = null;
        public static VisualElement ui = null;
        public static VisualElement tileDragTarget = null;
        public static string tileName = null;
        public static bool canvasHasTile = false;

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
            foreach (VisualElement selected in selection)
            {
                blocks.Delete(selected);
            }
        }

        public static void AddSelect(VisualElement element)
        {
            // Add selected element to selection and apply style
            selection.Add(element);
            ApplySelectStyle(element);
        }

        public static void DeselectAll()
        {
            // Revert all the styles on any things we may have selected
            // as we're about to deselect them
            foreach (VisualElement selected in selection)
            {
                RevertSelectStyle(selected);
            }

            // Clear the selection list to finish deselection
            selection.Clear();
        }

        private static void MultiSelect(VisualElement element)
        {
            // If we have already selected this element deselect it
            if (selection.Contains(element))
            {
                selection.Remove(element);
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
            element.style.BorderColor(new Color(47/255.0f, 114/255.0f, 168/255.0f));
            element.style.BorderWidth(2);
            element.style.marginTop = -2;
            element.style.marginLeft = -2;
        }

        private static void RevertSelectStyle(VisualElement element)
        {
            element.style.BorderWidth(1);
            element.style.BorderColor(new Color(42/255.0f, 42/255.0f, 42/255.0f));
            element.style.marginTop = 0;
            element.style.marginLeft = 0;
        }
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
