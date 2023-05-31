using Assets.Event_Editor.Scripts;
using EECore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArtifactUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject artifactUI;
    public bool ar1S = false;
    public bool ar2S = false;
    public bool ar3S = false;
    public bool ar4S = false;
    void Start()
    {
        if (GameStateManager.flags.ContainsKey("artifact 1"))
        {
            ar1S = GameStateManager.flags["artifact 1"] == 1;
        }
        if (GameStateManager.flags.ContainsKey("artifact 2"))
        {
            ar1S = GameStateManager.flags["artifact 2"] == 1;
        }
        if (GameStateManager.flags.ContainsKey("artifact 3"))
        {
            ar1S = GameStateManager.flags["artifact 3"] == 1;
        }
        if (GameStateManager.flags.ContainsKey("artifact 4"))
        {
            ar1S = GameStateManager.flags["artifact 4"] == 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool ar1N = false;
        bool ar2N = false;
        bool ar3N = false;
        bool ar4N = false;

        if (GameStateManager.flags.ContainsKey("artifact 1"))
        {
            ar1S = GameStateManager.flags["artifact 1"] == 1;
        }
        if (GameStateManager.flags.ContainsKey("artifact 2"))
        {
            ar2S = GameStateManager.flags["artifact 2"] == 1;
        }
        if (GameStateManager.flags.ContainsKey("artifact 3"))
        {
            ar3S = GameStateManager.flags["artifact 3"] == 1;
        }
        if (GameStateManager.flags.ContainsKey("artifact 4"))
        {
            ar4S = GameStateManager.flags["artifact 4"] == 1;
        }

        VisualElement root = artifactUI.GetComponent<UIDocument>().rootVisualElement;

        if (ar1N != ar1S)
        {
            root.Find("1").style.opacity = ar1N ? 100 : 50;
        }

        if (ar2N != ar2S)
        {
            root.Find("2").style.opacity = ar2N ? 100 : 50;
        }

        if (ar3N != ar3S)
        {
            root.Find("3").style.opacity = ar3N ? 100 : 50;
        }

        if (ar4N != ar4S)
        {
            root.Find("4").style.opacity = ar1N ? 100 : 50;
        }
    }
}
