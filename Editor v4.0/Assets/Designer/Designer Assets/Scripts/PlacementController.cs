using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacementController : MonoBehaviour
{
    public Canvas canvas;
    public Camera mainCamera;
    public GameObject cameraGroup;
    public GameObject plane;

    public GameObject selector;

    public GameObject mapMaster;

    public GameObject placement;

    public GameObject revealer;

    public TextMeshPro revealerText;

    public Vector3 first = Vector3.zero;
    public Vector3 last = Vector3.zero;

    public float scrollSpeed;

    public GameObject origin2D;
    public GameObject origin3D;

    public float cameraSpeed = 10;

    private Dictionary<GameObject, GameObject> _revealers = new Dictionary<GameObject, GameObject>();
    private Dictionary<GameObject, GameObject> _rerevealers = new Dictionary<GameObject, GameObject>();
    private List<TextMeshPro> _textMeshes = new List<TextMeshPro>();

    private bool _hideRevealers = false;
    private bool _hideStateChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        Controller.mapMaster = mapMaster;
        Controller.selected = placement;
    }

    // Update is called once per frame
    void Update()
    {
        _hideStateChanged = false;

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            _hideRevealers = !_hideRevealers;
            _hideStateChanged = true;
        }

        UpdateRevealers();

        // camera movement
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Minus))
        {
            mainCamera.orthographicSize += 1;
        }

        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Equals)) && mainCamera.orthographicSize > 1)
        { 
            mainCamera.orthographicSize -= 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            cameraGroup.transform.position += Vector3.left * cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            cameraGroup.transform.position += Vector3.right * cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            cameraGroup.transform.position += Vector3.back * cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            cameraGroup.transform.position += Vector3.forward * cameraSpeed * Time.deltaTime;
        }


        // placement raycast stuff
        GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();

        PointerEventData ped = new PointerEventData(null);

        ped.position = Input.mousePosition;


        List<RaycastResult> results = new List<RaycastResult>();

        gr.Raycast(ped, results);

        if (results.Count > 0)
        {
            // check for scrolling up / down on mouse

            if (Input.mouseScrollDelta != Vector2.zero)
            {
                GameObject selectedList = Controller.mode == "2D" ? origin2D : origin3D;

                float newZ = selectedList.transform.localPosition.z + Input.mouseScrollDelta.y * scrollSpeed;

                if (newZ < 0)
                {
                    newZ = 0;
                }

                float endZ = - (Controller.mode == "2D" ? Controller.yEnd2D : Controller.yEnd3D) - 5.5f;
                if (newZ > endZ)
                {
                    newZ = endZ;
                }

                Debug.Log(endZ);
                Debug.Log(newZ);

                selectedList.transform.localPosition = new Vector3(0, 0, newZ);
            }

            return; // hit UI, ignore
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Controller.penType == PenType.Single)
            {
                if (Controller.selected == null)
                {
                    return;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform == plane.transform)
                    {
                        var placed = Instantiate(Controller.selected, Controller.mapMaster.transform);
                        placed.transform.position = CorrectPoint(hit.point + new Vector3(0, 0.4f, 0));
                        placed.transform.Rotate(Vector3.up * Controller.rotation);
                        placed.gameObject.tag = "Placed Object";
                    }


                    else if (hit.transform.gameObject.tag == "Placed Object")
                    {
                        var position = hit.transform.position;
                        Destroy(hit.transform.gameObject);
                        var placed = Instantiate(Controller.selected, Controller.mapMaster.transform);
                        placed.transform.position = CorrectPoint(position);
                        placed.transform.Rotate(Vector3.up * Controller.rotation);
                        placed.gameObject.tag = "Placed Object";
                    }
                }

            }

            if (Controller.penType == PenType.Square)
            {
                if (Controller.selected == null)
                {
                    return;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    first = CorrectPoint(hit.point);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    last = CorrectPoint(hit.point);

                    var leastZ = first.z < last.z ? first.z : last.z; 
                    var leastX = first.x < last.x ? first.x : last.x;

                    var greatestZ = first.z > last.z ? first.z : last.z;
                    var greatestX = first.x > last.x ? first.x : last.x;

                    for(float z = leastZ; z < greatestZ; z += 1)
                    {
                        for (float x = leastX; x < greatestX; x += 1)
                        {

                            var placed = Instantiate(Controller.selected, Controller.mapMaster.transform);
                            placed.transform.position = CorrectPoint(new Vector3(x, hit.point.y + 0.4f, z));
                            placed.transform.Rotate(Vector3.up * Controller.rotation);
                            placed.gameObject.tag = "Placed Object";
                        }
                    }
                    //UpdateRevealers();
                }

            }

            if (Controller.penType == PenType.Erase)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform.gameObject.tag == "Revealer" && _revealers.ContainsKey(hit.transform.gameObject))
                    {
                        Destroy(_revealers[hit.transform.gameObject]);
                    }

                    if (hit.transform.gameObject.tag == "Placed Object")
                    {
                        Destroy(hit.transform.gameObject); // delete the damn thing
                    }

                    Transform p = hit.transform.parent;
                    while (p != null && p.gameObject.tag != "Placed Object")
                    {
                        p = p.parent;
                    }

                    if (p != null)
                    {
                        Destroy(p.gameObject);
                    }
                }
            }
        }


        selector.transform.position = CorrectPoint(hit.point + new Vector3(0, 0.2f, 0));
        // place selector in correct place
    }

    Vector3 CorrectPoint(Vector3 original)
    {
        int x = (int)original.x;
        int z = (int)original.z;

        int sx = (int)(original.x / Mathf.Abs(original.x));
        int sz = (int)(original.z / Mathf.Abs(original.z));

        return new Vector3(x + 0.5f * sx, original.y, z + 0.5f * sz);
    }

    void UpdateRevealers()
    {

        if (_hideStateChanged)
        {
            // if we have changed our hide state update our revalers accordingly
            foreach(GameObject revealer in _revealers.Keys)
            {
                revealer.SetActive(!_hideRevealers);
            }
        }

        foreach (TextMeshPro text in _textMeshes)
        {
            Destroy(text.transform.gameObject);
        }

        _textMeshes = new List<TextMeshPro>();

        GameObject[] placedObjects = GameObject.FindGameObjectsWithTag("Placed Object");

        foreach (GameObject trackedObject in _rerevealers.Keys)
        {
            if (!trackedObject.IsDestroyed())
            {
                continue;
            }

            Destroy(_rerevealers[trackedObject]);
            _revealers.Remove(_rerevealers[trackedObject]);
            _rerevealers.Remove(trackedObject);
        }

        foreach (GameObject placedObject in placedObjects)
        {
            // check if the placed object has a mesh renderer
            MeshRenderer renderer = placedObject.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                continue; // no revealers to place
            }

            // a revealer for this object already exists
            if (_rerevealers.ContainsKey(placedObject))
            {
                continue;
            }

            GameObject rev = Instantiate(revealer);

            rev.tag = "Revealer";
            rev.transform.position = placedObject.transform.position;

            _revealers.Add(rev, placedObject);
            _rerevealers.Add(placedObject, rev);
        }

        // if we are hiding our revealers (and text) we shouldnt need to add the text
        // back to the scene as it shouldnt be visible.
        if (_hideRevealers)
        {
            return;
        }
        
        foreach (GameObject placedObject in placedObjects)
        {
            MeshRenderer renderer = placedObject.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                continue; // no text to place
            }

            GameObject canvas = GameObject.Find("Canvas");
            TextMeshPro text = Instantiate(revealerText, canvas.transform);
            text.transform.position = placedObject.transform.position + Vector3.up * 0.5f;
            text.text = placedObject.name.Replace("(Clone)", "");
            text.tag = "Revealer";

            _textMeshes.Add(text);
        }
    }
}

public static class Controller
{
    public static string mode = "2D";
    public static PenType penType = PenType.Single;
    public static GameObject selected = null;
    public static GameObject mapMaster = null;
    public static float yEnd2D = 0.0f;
    public static float yEnd3D = 0.0f;
    public static float rotation = 0.0f;
} 

public enum PenType
{
    Single, 
    Square,
    Erase, 
}