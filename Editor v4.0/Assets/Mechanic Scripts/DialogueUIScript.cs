using EECore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUIScript : MonoBehaviour
{
    public GameObject dialogueUI;
    // Start is called before the first frame update
    void Start()
    {
        // Hide the text
        dialogueUI.SetActive(false);
        GameStateManager.dialogueBox = dialogueUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
