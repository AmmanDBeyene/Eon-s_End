using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    internal static class StaticEditor
    {
        public static VisualElement canvas = null;
        public static VisualElement tileDragTarget = null;
        public static string tileName = null;
        public static bool canvasHasTile = false;
    }
}
