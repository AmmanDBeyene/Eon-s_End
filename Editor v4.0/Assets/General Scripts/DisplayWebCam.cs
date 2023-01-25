using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWebCam : MonoBehaviour
{


    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        Renderer rend = this.GetComponentInChildren<Renderer>();

        // assuming the first available WebCam is desired
        WebCamTexture tex = new WebCamTexture(devices[0].name);

        Debug.Log(devices[0].name);

        rend.material.mainTexture = tex;
        tex.Play();
    }
}
