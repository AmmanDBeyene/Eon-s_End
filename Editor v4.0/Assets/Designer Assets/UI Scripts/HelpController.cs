using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;
using static UnityEngine.UI.Image;
public class HelpController : MonoBehaviour
{
    // Start is called before the first frame update

    public Button helpButton;
    public GameObject helpCamera;

    private bool _helpVisible = false;

    void Start()
    {
        helpButton.onClick.AddListener(HelpClicked);
    }

    void HelpClicked()
    {
        _helpVisible = true;
        helpCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (_helpVisible && (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)))
        {
            _helpVisible = false;
            helpCamera.SetActive(false);
        }
    }
}
