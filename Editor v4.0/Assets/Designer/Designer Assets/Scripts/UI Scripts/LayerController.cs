using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LayerController : MonoBehaviour
{
    public Button downButton;
    public Button upButton;

    public TextMeshPro currentLayerText;

    public GameObject buildingPlane;

    public float currentLayer = 0.0f;
    public float maxLayers = 5;

    // Start is called before the first frame update
    void Start()
    {
        downButton.onClick.AddListener(DownLayer);
        upButton.onClick.AddListener(UpLayer);
        UpdateState();
    }

    void UpLayer()
    {
        if (currentLayer >= maxLayers)
        {
            return;
        }
        currentLayer++;
        buildingPlane.transform.position += Vector3.up;
        UpdateState();
    }

    void DownLayer()
    {
        if (currentLayer <= 0)
        {
            return;
        }
        currentLayer--;
        buildingPlane.transform.position += Vector3.down;
        UpdateState();
    }

    void UpdateState()
    {
        if (currentLayer >= maxLayers)
        {
            upButton.transform.gameObject.SetActive(false);
        } 
        else
        {
            upButton.transform.gameObject.SetActive(true);
        }

        if (currentLayer == 0)
        {
            downButton.transform.gameObject.SetActive(false);
        } 
        else
        {
            downButton.transform.gameObject.SetActive(true);
        }

        currentLayerText.text = ""+currentLayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UpLayer();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            DownLayer();
        }
    }
}
