using Assets.Event_Editor.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Event_Editor.Scripts
{
    public class EventEditor : EditorWindow
    {
        private static EditorWindow _window = null;
        private static VisualElement _mainUI = null;
        private static VisualElement _mainArea = null;
        private static VisualElement _blockArea = null;
        private static List<VisualElement> _tiles = new List<VisualElement>();

        //private static VisualElement 

        [MenuItem("Tools/Event Editor")]
        public static void ShowEditor()
        {
            _tiles = new List<VisualElement>();
            _window = GetWindow<EventEditor>();
            _window.titleContent = new GUIContent("Event Editor");

            // remove all old ui if it exists
            _window.rootVisualElement.Clear();

            // load the main editor UI
            _mainUI = _window.rootVisualElement.AddCreate("Assets/Event Editor/UI/Main.uxml");
            _mainUI.StretchToParentSize();

            // locate and assign the main and block areas within the main UI
            _mainArea = _mainUI.FindElementByName("MainArea");
            _blockArea = _mainUI.FindElementByName("BlockArea");

            // Publicize our canvas VE
            StaticEditor.canvas = _mainArea;

            // Fill our blocks bar
            FillBlocksBar();

            // do some testing
            Test();
        }

        private static void Test()
        {
        }

        private static void FillBlocksBar()
        {
            VisualElement blockBar = _blockArea.Find("BlockBar");
            blockBar.Add(CreateTile("Show Text", Extensions.Load("Assets/Event Editor/UI/ShowTextBlock.uxml")));
            blockBar.Add(CreateTile("Set Flag", Extensions.Load("Assets/Event Editor/UI/SetFlagBlock.uxml")));
            blockBar.Add(CreateTile("Wait", Extensions.Load("Assets/Event Editor/UI/WaitBlock.uxml")));
        }

        private static VisualElement CreateTile(string name, VisualTreeAsset represents)
        {
            VisualElement tile = Extensions.Create("Assets/Event Editor/UI/Block.uxml");

            VisualElement icon = tile.Find("BlockIcon");

            TextElement text = (TextElement)tile.Find("BlockText");

            text.text = name;
            tile.style.top = 45 * _tiles.Count;

            TileManipulator tm = new TileManipulator(tile, name, represents);

            _tiles.Add(tile);

            return tile;
        }
    }
}