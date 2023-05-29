using Assets.Event_Editor.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectPlacementView))]
public class ObjectPlacementView : SceneView
{
    public GameObject pointSelector = null;
    private Vector3 pos;
    public ObjectPlacementView()
    {
        
    }

    public override void OnEnable()
    {
        duringSceneGui += MouseClick;
        pointSelector = null;
        pointSelector = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pointSelector.GetComponent<BoxCollider>().enabled = false;
        SceneVisibilityManager.instance.DisablePicking(StaticEditor.openScene.Value);
        base.OnEnable();
        
    }

    private void MouseClick(SceneView obj)
    {
        Event evt = Event.current;
        if (!evt.isMouse)
        {

            return;
        }

        if (evt.type == EventType.MouseDown && evt.button == 0)
        {
            evt.Use();
            StaticEditor.awaitedPosition = pointSelector.transform.position;
            pos = pointSelector.transform.position;
            pos = new Vector3(pos.x, pos.y, pos.z);
            DestroyImmediate(pointSelector);
            duringSceneGui -= MouseClick;
            SceneVisibilityManager.instance.EnablePicking(StaticEditor.openScene.Value);
            StaticEditor.ScenePointSelected(pos);
        }
    }

    protected override void OnSceneGUI()
    {
        Vector3 mousePosition = Event.current.mousePosition;
        mousePosition.y = camera.pixelHeight - mousePosition.y;
        Ray ray = camera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (pointSelector != null)
            {
                pointSelector.transform.position = (hit.point + Vector3.up * 0.5f).RoundXZ();
            }
        }

        try
        {
            base.OnSceneGUI();
        } catch { }
    }
}