using System;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

using Assets.Event_Editor.Event_Scripts.Commands;
using Assets.Event_Scripts.Conditions;
using UnityEditor.UIElements;
using System.IO;
using System.Linq;
using Assets.Event_Editor.Event_Scripts.Conditions;

namespace Assets.Event_Editor.Scripts
{
    public class EventEditor : EditorWindow
    {
        private static EditorWindow _window = null;
        private static VisualElement _mainUI = null;
        private static VisualElement _mainArea = null;
        private static VisualElement _blockArea = null;
        public static MainAreaManipulator areaManipulator = null;
        public static string currentOpenFile = null;

        private static List<VisualElement> _tiles = new List<VisualElement>();

        public void Update()
        {
            StaticEditor.Update();
        }

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
            StaticEditor.area = _mainArea.Find("AbsoluteArea");
            StaticEditor.ui = _mainUI;

            // Prepare the toolbar menu
            PrepareToolbarMenu();

            // Hook keyboard events 
            KeyboardHook();

            // Hook mouse events
            MouseHook();

            // Fill our blocks bar
            FillBlocksBar();

            // do some testing
        }

        #region Mouse Events
        private static void MouseHook()
        {
            areaManipulator = new MainAreaManipulator();
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

            if ((evt.ctrlKey || evt.commandKey) && !evt.shiftKey)
            {
                if (code == KeyCode.A)
                {
                    // select all
                    StaticEditor.blocks.ForEach(i => StaticEditor.AddSelect(i.visualElement));
                }

                else if (code == KeyCode.S)
                {
                    // Save
                    Save();
                }

                else if (code == KeyCode.O)
                {
                    Open();
                }

                else if (code == KeyCode.N)
                {
                    New();
                }

                else if (code == KeyCode.W)
                {
                    Compile();
                }

                return;
            }

            else if (evt.shiftKey && evt.shiftKey)
            {
                if (code == KeyCode.S)
                {
                    SaveAs();
                }
            }


            if (code == KeyCode.R && StaticEditor.selectedBlocks.Count == 1)
            {
                // this block is now the root block
                StaticEditor.rootBlock = StaticEditor.blocks.Find(i => i.visualElement == StaticEditor.selectedBlocks[0]);
                StaticEditor.blocks.ForEach(b => b.UpdateConnectorColor());
            } 
        }

        private static void KeyUp(KeyUpEvent evt)
        {
            KeyCode code = evt.keyCode;

            // Update static keyboard state
            Keyboard.ChangeKeyState(code, false);
        }

        #endregion

        private static void PrepareToolbarMenu()
        {
            // Find tooolbar menu
            ToolbarMenu toolbarMenu = (ToolbarMenu) _mainUI.Find("FileBarMenu");

            // Clear toolbar menu items
            toolbarMenu.menu.MenuItems().Clear();

            // Add menu items 
            toolbarMenu.menu.AppendAction("New Graph", (e) =>
            {
                New();
            }, (e) => { return DropdownMenuAction.Status.Normal; });

            toolbarMenu.menu.AppendAction("Open Graph", (e) =>
            {
                Open();
            }, (e) => { return DropdownMenuAction.Status.Normal; });

            toolbarMenu.menu.AppendSeparator();

            toolbarMenu.menu.AppendAction("Save", (e) =>
            {
                Save();
            }, (e) => { return DropdownMenuAction.Status.Normal; });

            toolbarMenu.menu.AppendAction("Save As...", (e) =>
            {
                SaveAs();
            }, (e) => { return DropdownMenuAction.Status.Normal; });

            toolbarMenu.menu.AppendAction("Save and Compile", (e) =>
            {
                Compile();
            }, (e) => { return DropdownMenuAction.Status.Normal; });

            toolbarMenu.menu.AppendAction("Save and Compile As...", (e) =>
            {
                if (SaveAs())
                {
                    Compile();
                }
            }, (e) => { return DropdownMenuAction.Status.Normal; });

            toolbarMenu.menu.AppendSeparator();

            toolbarMenu.menu.AppendAction("Create Compound Block (Cock)", (e) =>
            {
                CreateCompoundBlock();

            }, (e) => { return DropdownMenuAction.Status.Normal; });
        }

        private static void New()
        {

        }

        private static void Open()
        {
            string path = EditorUtility.OpenFilePanel("Open Event Graph", "", "evtgraph");

            if (path.Length == 0)
            {
                return;
            }

            currentOpenFile = path;

            StaticEditor.Load(path);
        }

        private static bool Save()
        {
            if (currentOpenFile == null)
            {
                return SaveAs();
            }

            StaticEditor.Save(currentOpenFile);
            return true;
        }

        private static bool SaveAs()
        {
            string name = _mainUI.GetTextFieldValue("FileName");

            var path = EditorUtility.SaveFilePanel("Save Event Graph", "", name + ".evtgraph", "evtgraph");

            if (path.Length == 0)
            {
                return false;
            }

            currentOpenFile = path;

            StaticEditor.Save(path);

            return true;
        }

        private static void Compile()
        {
            if (currentOpenFile == null && Save())
            {
                return;
            }

            StaticEditor.Compile(currentOpenFile);
        }

        private static void CreateCompoundBlock()
        {
            if (StaticEditor.selectedBlocks.Count <= 1)
            {
                StaticEditor.ShowWarning("Please select several blocks (> 1) before creating a compound block.");
                return;
            }


            var path = EditorUtility.SaveFilePanel("Save Event Graph", "Assets/Event Editor/Compound Blocks", "Block.cock", "cock");

            if (path.Length == 0)
            {
                return;
            }

            CompoundBlock cock = new CompoundBlock(StaticEditor.selectedBlocks.ToBlockList());

            cock.name = Path.GetFileNameWithoutExtension(path);
            cock.Save(path);
        }

        private static void FillBlocksBar()
        {

            // Create command tiles
            CreateCommandTiles();

            // Create condition tiles
            CreateConditionTiles();

            // Create compound blocks
            CreateCompoundBlocks();
        }

        private static void CreateCommandTiles()
        {
            VisualElement blockBar = _blockArea.Find("BlockBar");

            blockBar.Add(CreateCommandTile("Show Text", "ShowTextBlock.uxml", typeof(ShowTextCommand)));
            blockBar.Add(CreateCommandTile("Hide Text", "HideTextBlock.uxml", typeof(HideTextCommand)));
            blockBar.Add(CreateCommandTile("Transfer Actor", "TransferActorBlock.uxml", typeof(SceneSwitchCommand)));
            blockBar.Add(CreateCommandTile("Start Combat"           , "StartCombatBlock.uxml"       , typeof(StartCombatCommand)));
            blockBar.Add(CreateCommandTile("Set Flag", "SetNumFlagBlock.uxml", typeof(SetFlagCommand)));
            //blockBar.Add(CreateCommandTile("Wait", "WaitBlock.uxml", null));
            blockBar.Add(CreateCommandTile("Show Option", "ShowOptionBlock.uxml", typeof(ShowOptionCommand)));
            blockBar.Add(CreateCommandTile("Select Option", "SelectOptionBlock.uxml", typeof(SelectOptionCommand)));
            blockBar.Add(CreateCommandTile("Move Object", "ControlPrefabBlock.uxml", typeof(ControlPrefabCommand)));

        }

        private static void CreateConditionTiles()
        {
            VisualElement blockBar = _blockArea.Find("BlockBar");

            blockBar.Add(CreateConditionTile("Input Check", "InputCondition.uxml", typeof(InputCondition)));
            blockBar.Add(CreateConditionTile("Num Flag Check", "NumFlagCondition.uxml", typeof(NumFlagCondition)));
            //blockBar.Add(CreateConditionTile("String Flag Check", "StringFlagCondition.uxml", null));
            //blockBar.Add(CreateConditionTile("Bool Flag Check", "BoolFlagCondition.uxml", null));
            blockBar.Add(CreateConditionTile("Proximity Check", "ProximityCondition.uxml", typeof(ProximityCondition)));
            //blockBar.Add(CreateConditionTile("Inventory Check", "InventoryCondition.uxml", null));
            //blockBar.Add(CreateConditionTile("Equipment Check", "EquipmentCondition.uxml", null));
            //blockBar.Add(CreateConditionTile("Equipment Type Check", "EquipmentTypeCondition.uxml", null));
            //blockBar.Add(CreateConditionTile("Player Status Check", "PlayerStatusCondition.uxml", null));
        }

        private static void CreateCompoundBlocks()
        {
            VisualElement blockBar = _blockArea.Find("BlockBar");

            DirectoryInfo di = new DirectoryInfo("Assets/Event Editor/Compound Blocks");
            di.GetFiles().ToList().ForEach(file =>
            {
                if (file.Extension != ".cock")
                {
                    return; // we only want .cock files to be loaded
                }

                Debug.Log(file);

                blockBar.Add(CreateCompoundBlockTile(Path.GetFileNameWithoutExtension(file.Name)));
            });

        }

        private static VisualElement CreateCommandTile(string name, string toLoad, Type type)
        {
            VisualElement tile = Extensions.Create("Assets/Event Editor/UI/Block.uxml");

            TextElement text = (TextElement)tile.Find("BlockText");

            text.text = name;
            tile.style.top = 45 * _tiles.Count;

            TileManipulator tm = new TileManipulator(tile, name, $"Assets/Event Editor/UI/Blocks/{toLoad}", BlockType.Command, type);

            _tiles.Add(tile);

            return tile;
        }

        private static VisualElement CreateConditionTile(string name, string toLoad, Type type)
        {
            VisualElement tile = Extensions.Create("Assets/Event Editor/UI/Condition.uxml");

            TextElement text = (TextElement)tile.Find("ConditionText");

            text.text = name;
            tile.style.top = 45 * _tiles.Count;

            TileManipulator tm = new TileManipulator(tile, name, $"Assets/Event Editor/UI/Conditions/{toLoad}", BlockType.Condition, type);

            _tiles.Add(tile);

            return tile;
        }

        private static VisualElement CreateCompoundBlockTile(string name)
        {
            VisualElement tile = Extensions.Create("Assets/Event Editor/UI/Compound.uxml");

            TextElement text = (TextElement)tile.Find("ConditionText");

            text.text = name;
            tile.style.top = 45 * _tiles.Count;
            
            TileManipulator tm = new TileManipulator(tile, name, $"Assets/Event Editor/Compound Blocks/{name}.cock", BlockType.Compound, null);

            _tiles.Add(tile);

            return tile;
        }
    }
}