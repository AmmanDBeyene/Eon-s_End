using Assets.Event_Editor.Scripts;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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
        _mainUI = AdditiveCreate(_window.rootVisualElement, "Assets/Event Editor/UI/Main.uxml");
        _mainUI.StretchToParentSize();

        // locate and assign the main and block areas within the main UI
        _mainArea = _mainUI.FindElementByName("MainArea");
        _blockArea = _mainUI.FindElementByName("BlockArea");

        StaticEditor.canvas = _mainArea;

        FillBlocksBar();

        // do some testing
        Test();
    }

    private static void Test() 
    {
        VisualElement area = _mainArea.Find("AbsoluteArea");
        VisualElement connector = area.Add("Assets/Event Editor/UI/Connector.uxml");
        VisualElement block = connector.Find("Connector").Add("Assets/Event Editor/UI/ShowTextBlock.uxml");
        DragAndDropManipulator ddm = new DragAndDropManipulator(connector);
        connector.style.position = Position.Absolute;

        VisualElement block2 = _mainArea.Find("AbsoluteArea").Add("Assets/Event Editor/UI/ShowTextBlock.uxml");
        DragAndDropManipulator ddm2 = new DragAndDropManipulator(block2);
        block2.style.position = Position.Absolute;
    }

    private static void FillBlocksBar()
    {
        VisualElement blockBar = _blockArea.Find("BlockBar");
        blockBar.Add(CreateTile("Show Text", Load("Assets/Event Editor/UI/ShowTextBlock.uxml")));
        blockBar.Add(CreateTile("Set Flag", Load("Assets/Event Editor/UI/SetFlagBlock.uxml")));
        blockBar.Add(CreateTile("Wait", Load("Assets/Event Editor/UI/WaitBlock.uxml")));
    }

    private static VisualElement CreateTile(string name, VisualTreeAsset represents)
    {
        VisualElement tile = Create("Assets/Event Editor/UI/Block.uxml");

        VisualElement icon = tile.Find("BlockIcon");

        TextElement text = (TextElement) tile.Find("BlockText");

        text.text = name;
        tile.style.top = 45 * _tiles.Count;

        TileManipulator tm = new TileManipulator(tile, name, represents);

        _tiles.Add(tile);

        return tile;
    }

    #region Loading

    private static VisualElement AdditiveCreate(VisualElement elem, string path)
    {
        VisualElement loaded = Create(path);
        elem.Add(loaded);
        return loaded;
    }

    private static VisualElement Create(string path)
    {
        VisualTreeAsset uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);
        VisualElement ui = uiAsset.Instantiate();
        return ui;
    }

    private static VisualTreeAsset Load(string path)
    {
        return AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);
    }

    #endregion
}

public static class Extensions
{
    public static VisualElement Find(this VisualElement ve, string name)
    {
        return FindElementByName(ve, name);
    }

    public static VisualElement FindElementByName(this VisualElement ve, string name)
    {
        // null case
        if (ve == null)
        {
            return null;
        }

        // base case
        if (ve.name == name)
        {
            return ve;
        }

        // start recursively looking through all children
        foreach (VisualElement child in ve.Children())
        {
            VisualElement result = child.FindElementByName(name);

            // if the result is not null we have successfully found our element
            if (result != null)
            {
                return result; 
            }
        }

        // recursive child search unsuccessful. 
        return null; 
    }

    public static VisualElement Clone(this VisualElement ve)
    {
        return ve.visualTreeAssetSource.CloneTree();
    }

    public static VisualElement Add(this VisualElement ve, string path)
    {
        VisualTreeAsset uiAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);
        VisualElement ui = uiAsset.CloneTree();
        ve.Add(ui);
        return ui;
    }
}
