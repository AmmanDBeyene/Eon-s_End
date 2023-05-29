using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public bool x = false;
    public bool y = false;
    public bool z = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = Vector3.one * rotationSpeed;

        if (!x) { rot.x = 0; }
        if (!y) { rot.y = 0; }
        if (!z) { rot.z = 0; }

        gameObject.transform.Rotate(rot);
    }
}
