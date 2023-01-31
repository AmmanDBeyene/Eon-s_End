using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

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

            // clear the static editor blocks list
            StaticEditor.blocks.Clear();
            StaticEditor.connections.Clear();
            StaticEditor.selectedBlocks.Clear();

            StaticEditor.InvalidateConnections();

            // load the main editor UI
            _mainUI = _window.rootVisualElement.AddCreate("Assets/Event Editor/UI/Main.uxml");
            _mainUI.StretchToParentSize();

            // locate and assign the main and block areas within the main UI
            _mainArea = _mainUI.FindElementByName("MainArea");
            _blockArea = _mainUI.FindElementByName("BlockArea");

            // Publicize our canvas VE
            StaticEditor.canvas = _mainArea;
            StaticEditor.ui = _mainUI;

            // Hook keyboard events 
            KeyboardHook();

            // Hook mouse events
            MouseHook();

            // Fill our blocks bar
            FillBlocksBar();

            // do some testing
            Test();
        }

        #region Mouse Events
        private static void MouseHook()
        {
            MainAreaManipulator mam = new MainAreaManipulator();
        }

        #endregion

        #region Keyboard Events
        private static void KeyboardHook()
        {
            var keyReceiver = _mainArea;
            while (keyReceiver.parent != null)
            {
                keyReceiver = keyReceiver.parent;
            }

            keyReceiver.RegisterCallback<KeyDownEvent>(KeyDown);
            keyReceiver.RegisterCallback<KeyUpEvent>(KeyUp);
        }

        private static void KeyDown(KeyDownEvent evt)
        {
            KeyCode code = evt.keyCode;

            // Update static keyboard state
            Keyboard.ChangeKeyState(code, true);

            // If the delete button is pressed delete all the currently selected items
            if (code == KeyCode.Delete || code == KeyCode.Backspace)
            {
                StaticEditor.DeleteSelection();
            }
        }

        private static void KeyUp(KeyUpEvent evt)
        {
            KeyCode code = evt.keyCode;

            // Update static keyboard state
            Keyboard.ChangeKeyState(code, false);
        }

        #endregion

        private static void Test()
        {
           
        }

        private static void FillBlocksBar()
        {
            VisualElement blockBar = _blockArea.Find("BlockBar");

            // Create command tiles
            blockBar.Add(CreateCommandTile("Show Text", "ShowTextBlock.uxml"));
            blockBar.Add(CreateCommandTile("Set Flag", "SetFlagBlock.uxml"));
            blockBar.Add(CreateCommandTile("Wait", "WaitBlock.uxml"));

            // Create condition tiles
            blockBar.Add(CreateConditionTile("Input Check", "InputCondition.uxml"));
            blockBar.Add(CreateConditionTile("Num Flag Check", "NumFlagCondition.uxml"));
            blockBar.Add(CreateConditionTile("String Flag Check", "StringFlagCondition.uxml"));
            blockBar.Add(CreateConditionTile("Bool Flag Check", "BoolFlagCondition.uxml"));
            blockBar.Add(CreateConditionTile("Proximity Check", "ProximityCondition.uxml"));
            blockBar.Add(CreateConditionTile("Inventory Check", "InventoryCondition.uxml"));
            blockBar.Add(CreateConditionTile("Equipment Check", "EquipmentCondition.uxml"));
            blockBar.Add(CreateConditionTile("Equipment Type Check", "EquipmentTypeCondition.uxml"));
            blockBar.Add(CreateConditionTile("Player Status Check", "PlayerStatusCondition.uxml"));
        }

        private static VisualElement CreateCommandTile(string name, string toLoad)
        {
            VisualTreeAsset blockToCreate = Extensions.Load($"Assets/Event Editor/UI/Blocks/{toLoad}");
            VisualElement tile = Extensions.Create("Assets/Event Editor/UI/Block.uxml");

            TextElement text = (TextElement)tile.Find("BlockText");

            text.text = name;
            tile.style.top = 45 * _tiles.Count;

            TileManipulator tm = new TileManipulator(tile, name, blockToCreate, BlockType.Command);

            _tiles.Add(tile);

            return tile;
        }

        private static VisualElement CreateConditionTile(string name, string toLoad)
        {
            VisualTreeAsset blockToCreate = Extensions.Load($"Assets/Event Editor/UI/Conditions/{toLoad}");
            VisualElement tile = Extensions.Create("Assets/Event Editor/UI/Condition.uxml");

            TextElement text = (TextElement)tile.Find("ConditionText");

            text.text = name;
            tile.style.top = 45 * _tiles.Count;

            TileManipulator tm = new TileManipulator(tile, name, blockToCreate, BlockType.Condition);

            _tiles.Add(tile);

            return tile;
        }
    }
}