using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;
using static UnityEngine.UI.Image;

public class FileController : MonoBehaviour
{
    public GameObject mapCore;

    public Button saveButton;
    public Button loadButton;
    public Button newButton;
    public Button saveAsButton;


    public string currentSavePath = "";

    // Start is called before the first frame update
    void Start()
    {
        saveButton.onClick.AddListener(SaveClicked);
        loadButton.onClick.AddListener(LoadClicked);
        newButton.onClick.AddListener(NewClicked);
        saveAsButton.onClick.AddListener(SaveAsClicked);
    }

    void NewClicked()
    {
        if (currentSavePath != "" || mapCore.transform.childCount > 0)
        {
            bool result = EditorUtility.DisplayDialog(
                "Unsaved Changes",
                "You have unsaved changes. What would you like to do?",
                "Save", "Dont Save");

            if (result)
            {
                SaveClicked();
            }
        }

        currentSavePath = "";
        foreach (Transform child in mapCore.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void LoadClicked()
    {
        if (currentSavePath != "" || mapCore.transform.childCount > 0)
        {
            bool result = EditorUtility.DisplayDialog(
                "Unsaved Changes",
                "You have unsaved changes. What would you like to do?",
                "Save", "Dont Save");

            if (result)
            {
                SaveClicked();
            }
        }

        currentSavePath = EditorUtility.OpenFilePanel("Open Map Prefab", "Assets/Designer/Designer Output", "prefab");
        if (currentSavePath == null || currentSavePath == "")
        {
            currentSavePath = "";
            return;
        }

        string path = "Assets/" + currentSavePath.Split("/Assets/")[1];

        GameObject map = AssetDatabase.LoadAssetAtPath<GameObject>(path);

        Destroy(mapCore);
        Controller.mapMaster = null;
        mapCore = Instantiate(map);
        mapCore.name = "Map";
        mapCore.transform.position = new Vector3(0, 2.3f, 0);
        Controller.mapMaster = mapCore;
    }

    void SaveClicked()
    {
        if (currentSavePath != "")
        {
            // save automatically
            DoSave();
            return;
        }

        SaveAsClicked();
    }

    void SaveAsClicked()
    {
        currentSavePath = EditorUtility.SaveFilePanel(
        "Save Map Prefab", "Assets/Designer/Designer Output", "map.prefab",
            "prefab");

        if (currentSavePath == null || currentSavePath == "")
        {
            currentSavePath = "";
            return;
        }

        DoSave();
    }

    void DoSave()
    {
        if (currentSavePath == null || currentSavePath.Length <= 0)
        {
            return;
        }
        bool prefabSuccess;
        GameObject copy = Instantiate(mapCore);
        PrefabUtility.SaveAsPrefabAssetAndConnect(copy, currentSavePath, InteractionMode.UserAction, out prefabSuccess);
        Destroy(copy);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                // save as
                if (Input.GetKeyDown(KeyCode.S))
                {
                    SaveAsClicked();
                }
                else if (Input.GetKeyDown(KeyCode.N))
                {
                    NewClicked();
                }
                else if (Input.GetKeyDown(KeyCode.O))
                {
                    LoadClicked();
                }
            } else
            {
                // save
                if (Input.GetKeyDown(KeyCode.S))
                {
                    SaveClicked();
                }
            }
        }
    }
}
