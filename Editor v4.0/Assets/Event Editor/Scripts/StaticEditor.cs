using System.Collections.Generic;
using System.IO;

using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;

using Assets.Event_Editor.Event_Scripts;
using Assets.Event_Scripts;
using Assets.Event_Scripts.Event_Commands;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

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
        public static List<WarningManipulator> warnings = new List<WarningManipulator>();

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

        public static Block rootBlock = null;
        public static IEventPipe rootPipe = null;

        public static void Update()
        {
            // Update all warning manipulators
            warnings.ForEach(i => i.Update());
            
            // Find all finished warning manipulators
            var finished = warnings.FindAll(i => i.finished);

            // Remove all finished warning manipulators so they
            // no longer get updated
            finished.ForEach(i => warnings.Remove(i));
        }

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
            builtConnection.incoming = incomingBlock;
            builtConnection.outgoing = outgoingBlock;

            outgoingBlock.outgoingTo.Add(incomingBlock);

            outgoingBlock.UpdateState();

            connections.Add(builtConnection);

            builtConnection.ReRender();

            // No need to try and change the pipe type of this block
            if (outgoingBlock.pipeType != PipeType.None)
            {
                return;
            }

            // Set our pipe type to the incoming block's equivalent pipe type
            outgoingBlock.pipeType = incomingBlock.type.ToPipeType();
        }

        private static void RestoreConnection(Block incoming, Block outgoing)
        {
            builtConnection.incoming = incoming;
            builtConnection.outgoing = outgoing;

            outgoing.outgoingTo.Add(incoming);

            outgoing.UpdateState();

            Connection connection = new Connection(outgoing, incoming);

            connections.Add(connection);

            // No need to try and change the pipe type of this block
            if (outgoing.pipeType != PipeType.None)
            {
                return;
            }

            // Set our pipe type to the incoming block's equivalent pipe type
            outgoing.pipeType = incoming.type.ToPipeType();
        }

        #endregion

        #region Warning / Error
        
        public static void ShowWarning(string text)
        {
            VisualElement warning = Extensions.Create("Assets/Event Editor/UI/Warning.uxml");
            warning.style.position = Position.Absolute;
            warning.style.left = 0;
            warning.style.top = 0;
            warning.StretchToParentSize();
            warning.pickingMode = PickingMode.Ignore;

            ((Label)warning.Find("WarningText")).text = text;

            warning.BringToFront();
            
            canvas.Add(warning);

            WarningManipulator wm = new WarningManipulator(warning);
            warnings.Add(wm);
        }

        public static void ShowError(string text)
        {
            VisualElement warning = Extensions.Create("Assets/Event Editor/UI/Error.uxml");
            warning.style.position = Position.Absolute;
            warning.style.left = 0;
            warning.style.top = 0;
            warning.StretchToParentSize();
            warning.pickingMode = PickingMode.Ignore;

            ((Label)warning.Find("ErrorText")).text = text;

            warning.BringToFront();

            canvas.Add(warning);

            WarningManipulator wm = new WarningManipulator(warning);
            warnings.Add(wm);
        }

        #endregion

        #region Saving / Loading

        public static void Save(string path)
        {
            try
            {
                // Update the save position of every block so we know where to place them
                blocks.ForEach(i => i.savePosition = i.visualElement.GlobalPosition());
                blocks.ForEach(i => i.saveNode = (BlockNode)i.visualElement.InterpretAs(i.nodeType));

                // Create our editor save data and save it to a file
                EditorSaveData data = new EditorSaveData(blocks, connections);
                File.WriteAllText(path, data.Serialize().json);

            } catch (Exception e)
            {
                ShowError("An error has occured while saving. Check console for details.");
                Debug.LogError(e);
            }
        }

        public static void Compile(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            try
            {

                if (rootBlock == null)
                {
                    ShowWarning("Please assign a root before compiling.");
                    return; // we cannot compile
                }

                blocks.ForEach(i => i.saveNode = (BlockNode)i.visualElement.InterpretAs(i.nodeType));

                // Create the root pipe by connecting a unowned pipe to the root block.
                if (rootBlock.type == BlockType.Command)
                {
                    rootPipe = new CommandPipeSystem((CommandNode)rootBlock.saveNode);
                }
                else
                {
                    ConditionPipeSystem nps = new ConditionPipeSystem();
                    nps.conditions.Add((ConditionNode)rootBlock.saveNode);
                    rootPipe = nps;
                }

                // Compile all blocks and their pipes
                blocks.ForEach(i => i.Compile());

                // Save the serialized json of our pipe structure
                string json = rootPipe.Serialize().json;

                JToken parsedJson = JToken.Parse(json);
                json = parsedJson.ToString(Formatting.Indented);

                json = json.Replace("\\", "\\\\");
                json = json.Replace("\"", "\\\"");
                json = json.Replace("\n", "\" +\n\t\t\t\"");
                json = json.Replace("\r", "");

                // Create a wrapper for our json 
                string wrapped =
                    "using Unity.VisualScripting; using Assets.Event_Scripts;\n" +
                   $"public class {name} : EventController {{\n" +
                    "\tvoid Start() { Load(); }\n" +
                    "\tpublic void Load() {\n" +
                   $"\t\tSerializationData data = new SerializationData(\n\t\t\"{json}\");\n" +
                    "\t\trootPipe = (IEventPipe)data.Deserialize();\n" +
                    "\t}\n}\n";

                // Save our compiled event graph file to a c# class file
                File.WriteAllText(path.Replace(".evtgraph", ".cs"), wrapped);
            }
            catch (Exception e)
            {
                ShowError("An error has occured while compiling. Check console for details.");
                Debug.LogError(e);
            }
        }

        public static void Load(string path)
        {
            try
            {
                if (path.Length == 0)
                {
                    return; // Since there's no path we probably dont want to load. 
                }

                // Remove all blocks from the editor
                blocks.ForEach(i => i.visualElement.parent.Remove(i.visualElement));
                blocks.Clear();

                // Remove all connections form the editor
                connections.ForEach(i => i.lineBlock.parent.Remove(i.lineBlock));
                connections.Clear();

                // Clear our selections just in case
                selectedBlocks.Clear();
                selectedConnections.Clear();

                // Load our editor save data from a file
                SerializationData data = new SerializationData(File.ReadAllText(path));
                EditorSaveData saveData = (EditorSaveData)data.Deserialize();

                // Set the blocks array
                blocks = saveData.blocks;

                // Create all the blocks in our block array
                blocks.ForEach(i => i.CreateAt(i.savePosition));

                // Restore our connections from our save data
                foreach (Connection connection in saveData.connections)
                {
                    outgoingBlock = connection.outgoing;
                    incomingBlock = connection.incoming;
                    builtConnection = new Connection(outgoingBlock, incomingBlock);

                    outgoingBlock.outgoingTo.Add(incomingBlock);

                    connections.Add(builtConnection);

                    // No need to try and change the pipe type of this block
                    if (outgoingBlock.pipeType != PipeType.None)
                    {
                        continue;
                    }

                    // Set our pipe type to the incoming block's equivalent pipe type
                    outgoingBlock.pipeType = incomingBlock.type.ToPipeType();
                }

                connections.ForEach(i => i.ReRender());

                blocks.ForEach(i => i.RestoreData());
            }
            catch (Exception e)
            {
                ShowError("An error has occured while loading. Check console for details.");
                Debug.LogError(e);
            }
        }

        #endregion

        #region Root Setting

        public static void SetRootBlock(Block block)
        {

        }

        private static void ApplyRootStyle(Block block)
        {

        }

        private static void RemoveRootStyle(Block block)
        {

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
