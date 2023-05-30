using EECore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUIScript : MonoBehaviour
{
    public GameObject dialogueUI;
    public Texture2D demonPort;
    public Texture2D youPort;
    public Texture2D bearPort;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the text
        dialogueUI.SetActive(false);
        GameStateManager.dialogueBox = dialogueUI;
        GameStateManager.demonPort = demonPort;
        GameStateManager.youPort = youPort;
        GameStateManager.bearPort = bearPort;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
