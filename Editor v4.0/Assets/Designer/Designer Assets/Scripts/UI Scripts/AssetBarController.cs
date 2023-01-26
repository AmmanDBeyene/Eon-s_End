using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AssetBarController : MonoBehaviour
{
    [Header("Sidebar")]
    public Button tabButton;
    public GameObject tabBar;

    public GameObject cLeft;
    public GameObject cRight;

    public float animationDuration = 1f;

    [Header("2D / 3D Mode")]
    public Button modeButton2D;
    public Button modeButton3D;
    public Image mode2DImage;
    public Image mode3DImage;
    public GameObject mode2DPosition;
    public GameObject mode3DPosition;
    public GameObject modeDot;

    [Header("Object List")]
    public GameObject listOrigin;
    public GameObject origin2D;
    public GameObject origin3D;
    public float spacing;
    public float columns;
    public GameObject revealer;
    public TextMeshPro itemText;

    public Transform previewPosition;

    private bool _tabHidden = false;

    private float _tabStartX = 690.48f;
    private float _tabEndX = 1229.0f;

    private List<GameObject> list2D = new List<GameObject>();
    private List<GameObject> list3D = new List<GameObject>(); 

    private Dictionary<GameObject, GameObject> _revealers = new Dictionary<GameObject, GameObject>();

    private GameObject previewObject = null;


    // Start is called before the first frame update
    void Start()
    {
        tabButton.onClick.AddListener(TabButtonClicked);
        modeButton2D.onClick.AddListener(Mode2DClicked);
        modeButton3D.onClick.AddListener(Mode3DClicked);
        Load2D();
        Load3D();
        origin2D.SetActive(true);
    }

    #region Sidebar

    void TabButtonClicked()
    {
        if(_tabHidden)
        {
            // show the tab
            StartCoroutine(ShowTab());
            cLeft.SetActive(false);
            cRight.SetActive(true);
        }
        else
        {
            // hide the tab
            StartCoroutine(HideTab());
            cLeft.SetActive(true);
            cRight.SetActive(false);
        }

        _tabHidden = !_tabHidden;
        Debug.Log("Pressed!");
    }

    IEnumerator ShowTab()
    {
        float timeElapsed = 0;
        while (timeElapsed < animationDuration)
        {
            SetTabXPosition(Mathf.Lerp(_tabEndX, _tabStartX, timeElapsed / animationDuration));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        SetTabXPosition(_tabStartX);
    }

    IEnumerator HideTab()
    {
        float timeElapsed = 0;
        while (timeElapsed < animationDuration)
        {
            SetTabXPosition(Mathf.Lerp(_tabStartX, _tabEndX, timeElapsed / animationDuration));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        SetTabXPosition(_tabEndX);
    }

    void SetTabXPosition(float xPos)
    {
        tabBar.transform.localPosition = new Vector3(xPos, 0, 0); 
    }

    #endregion

    #region Mode

    void Mode2DClicked()
    {
        if (Controller.mode == "2D")
        {
            return; // no need to change modes. 
        }
        Controller.mode = "2D";

        // move the dot
        modeDot.transform.position = mode2DPosition.transform.position;
        mode3DImage.color = new Color(1, 1, 1, 0.15f);
        mode2DImage.color = new Color(1, 1, 1, 1f);

        origin2D.SetActive(true);
        origin3D.SetActive(false);
    }

    void Mode3DClicked()
    {
        if (Controller.mode == "3D")
        {
            return; // no need to change modes.
        }
        Controller.mode = "3D";

        // move the dot
        modeDot.transform.position = mode3DPosition.transform.position;
        mode2DImage.color = new Color(1, 1, 1, 0.15f);
        mode3DImage.color = new Color(1, 1, 1, 1f);

        origin3D.SetActive(true);
        origin2D.SetActive(false);
    }

    #endregion

    void Load2D()
    {
        //string[] assets = AssetDatabase.FindAssets("t:texture2D", new[] { "Assets/Designer Assets/2D Tiles" });
        //foreach (string asset in assets)
        //{
        //    string path = AssetDatabase.GUIDToAssetPath(asset);
        //    Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
        //    Material m = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        //    m.mainTexture = texture;


        //    AssetDatabase.CreateAsset(m, $"Assets/Designer Assets/Materials/{texture.name}.mat");


        //    GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    MeshRenderer renderer = cubeObject.GetComponent<MeshRenderer>();
        //    cubeObject.SetActive(false);
        //    if(renderer != null)
        //    {
        //        renderer.material = m;
        //    }

        //    list2D.Add(cubeObject);
        //}

        string[] assets = AssetDatabase.FindAssets("t:material", new[] { "Assets/Designer/Designer Materials" });
        foreach (string asset in assets)
        {
            string path = AssetDatabase.GUIDToAssetPath(asset);
            Material material = AssetDatabase.LoadAssetAtPath<Material>(path);

            GameObject cubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeObject.name = material.name.Replace("(Clone)", "");

            MeshRenderer renderer = cubeObject.GetComponent<MeshRenderer>();
            cubeObject.SetActive(false);
            if (renderer != null)
            {
                renderer.material = material;
            }

            list2D.Add(cubeObject);
        }

        foreach (Transform child in origin2D.transform)
        {
            Destroy(child);
        }

        int row = 0;
        int col = 0;

        foreach (GameObject go in list2D)
        {
            GameObject gu = Instantiate(go, origin2D.transform);
            gu.SetActive(true);

            gu.transform.localPosition = new Vector3(
                origin2D.transform.localPosition.x + col * spacing,
                origin2D.transform.localPosition.y + 0.5f,
                origin2D.transform.localPosition.z - row * (spacing * 1.4f));

            Controller.yEnd2D = origin2D.transform.localPosition.z - row * (spacing * 1.4f);

            TextMeshPro text = Instantiate(itemText, origin2D.transform);
            text.transform.position = gu.transform.position + Vector3.back * 0.8f;
            text.text = gu.name.Replace("(Clone)", "");

            //MeshRenderer renderer = gu.GetComponent<MeshRenderer>();
            //renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            gu.tag = "Selectable";

            col++;
            if (col >= columns)
            {
                col = 0;
                row++;
            }
        }
        origin2D.SetActive(false);

    }

    void Load3D()
    {
        var assets = AssetDatabase.FindAssets("t:prefab", new[] { "Assets/Designer/Designer Objects" });
        Debug.Log(assets.Length);
        foreach(var asset in assets)
        {
            string path = AssetDatabase.GUIDToAssetPath(asset);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            prefab.name = prefab.name.Replace("(Clone)", "");
            list3D.Add(prefab);
        }

        foreach (Transform child in origin3D.transform)
        {
            Destroy(child);
        }

        int row = 0;
        int col = 0;

        foreach (GameObject go in list3D)
        {
            GameObject gu = Instantiate(go, origin3D.transform);


            gu.transform.localPosition = new Vector3(
                origin3D.transform.localPosition.x + col * spacing,
                origin3D.transform.localPosition.y + 0.5f,
                origin3D.transform.localPosition.z - row * (spacing * 1.4f));


            Controller.yEnd3D = origin3D.transform.localPosition.z - row * (spacing * 1.4f);

            TextMeshPro text = Instantiate(itemText, origin3D.transform);
            text.transform.position = gu.transform.position + Vector3.back * 0.8f;
            text.text = gu.name.Replace("(Clone)", "");

            gu.tag = "Selectable";

            MeshRenderer renderer = gu.GetComponent<MeshRenderer>();

            if (renderer == null)
            {
                // we need a revealer
                GameObject rev = Instantiate(revealer, origin3D.transform);
                rev.tag = "Revealer";
                _revealers.Add(rev, gu);
                rev.transform.position = gu.transform.position;
            }

            col++;
            if (col >= columns)
            {
                col = 0;
                row++;
            }
        }
        origin3D.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Controller.rotation += 90;
            Controller.rotation %= 360; // so we dont overrotate
            UpdatePreview();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Controller.rotation -= 90;
            Controller.rotation %= 360; // so we dont overrotate
            UpdatePreview();
        }

        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Revealer" && _revealers.ContainsKey(hit.transform.gameObject))
                {
                    // we've hit a revealer that should select an object
                    Controller.selected = _revealers[hit.transform.gameObject];
                    UpdatePreview();
                }

                GameObject selectable = FindSelectable(hit.transform.gameObject);
                Debug.Log(selectable);

                // if theres something to select
                if (selectable != null)
                {
                    // select it
                    Controller.selected = selectable;
                    UpdatePreview();
                }

                //if (hit.transform.gameObject.tag == "Selectable")
                //{
                //    // we've hit a selectable object .. select it
                //    if (_mode == "2D")
                //    {
                //        Controller.selected = hit.transform.gameObject;
                //    }
                //    else
                //    {
                //        Controller.selected = hit.transform.gameObject;
                //    }
                //}
            }
        }
    }

    private void UpdatePreview()
    {
        if (previewObject != null)
        {
            Destroy(previewObject);
        }
        previewObject = Instantiate(Controller.selected, previewPosition);
        previewObject.transform.localPosition = Vector3.zero + new Vector3(0, 0.5f, 0);
        previewObject.transform.Rotate(Vector3.up * Controller.rotation);
    }

    private GameObject FindSelectable(GameObject go)
    {
        if (go == null)
        {
            return null;
        }

        if (go.tag == "Selectable")
        {
            return go;
        }

        if (go.transform == null || go.transform.parent == null)
        {
            return null;
        }

        return FindSelectable(go.transform.parent.gameObject);
    }
}
