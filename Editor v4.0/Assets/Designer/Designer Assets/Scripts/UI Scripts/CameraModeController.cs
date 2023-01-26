using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraModeController : MonoBehaviour
{
    public Button cameraToggle;

    public Camera mainCamera;

    public Image cameraImage;
    public GameObject position50; // angle
    public GameObject position90; // top-down

    private int _angle = 90;

    // Start is called before the first frame update
    void Start()
    {
        cameraToggle.onClick.AddListener(ToggleAngle);   
    }

    void ToggleAngle()
    {
        if (_angle == 90)
        {
            _angle = 50;
            mainCamera.transform.position = position50.transform.position;
            mainCamera.transform.eulerAngles = new Vector3(50, 0, 0);
            cameraImage.rectTransform.eulerAngles = new Vector3(90, 0, -50);
        } else
        {
            _angle = 90;
            mainCamera.transform.position = position90.transform.position;
            mainCamera.transform.eulerAngles = new Vector3(90, 0, 0);
            cameraImage.rectTransform.eulerAngles = new Vector3(50, 0, -90);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleAngle();
        }
    }
}
