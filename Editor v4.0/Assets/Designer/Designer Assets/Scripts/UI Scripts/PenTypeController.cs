using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenTypeController : MonoBehaviour
{
    public Button singleModeButton;
    public Button squareModeButton;
    public Button eraserModeButton;

    public Image singleImage;
    public Image squareImage;
    public Image eraserImage;

    // Start is called before the first frame update
    void Start()
    {
        singleModeButton.onClick.AddListener(SingleClicked);
        squareModeButton.onClick.AddListener(SquareClicked);
        eraserModeButton.onClick.AddListener(EraserClicked);
    }

    void SingleClicked()
    {
        Controller.penType = PenType.Single;
        Hide(eraserImage);
        Hide(squareImage);
        Show(singleImage);
    }

    void SquareClicked()
    {
        Controller.penType = PenType.Square;
        Hide(eraserImage);
        Show(squareImage);
        Hide(singleImage);
    }

    void EraserClicked()
    {
        Controller.penType = PenType.Erase;
        Show(eraserImage);
        Hide(squareImage);
        Hide(singleImage);
    }

    void Hide(Image img)
    {
        img.color = new Color(1, 1, 1, 0.15f);
    }

    void Show(Image img)
    {
        img.color = new Color(1, 1, 1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SquareClicked();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SingleClicked();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EraserClicked();
        }
    }
}
