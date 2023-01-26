using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryMove(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TryMove(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TryMove(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TryMove(Vector3.right);
        }
    }

    RaycastHit Cast(Vector3 start, Vector3 end)
    {
        RaycastHit hit;
        Vector3 dir = (end - start).normalized;
        float range = (start - end).magnitude;

        Debug.DrawLine(start, end, Color.red, range);
        Physics.Raycast(start, dir, out hit, range);

        return hit;
    }

    bool TryMove(Vector3 movement)
    {
        // cast ray from center of player to new theorized position

        Vector3 start = transform.position;
        Vector3 end = start + movement;

        RaycastHit hit = Cast(start, end);

        if (hit.transform != null)
        {
            return false; // we're going to hit a wall, stop movement
        }

        // good, we can move in this direction. 
        // Now check if there's a floor to stand on within
        // The appropriate range

        Vector3 end2 = end + Vector3.down; // floor checker
        RaycastHit hit2 = Cast(end, end2);

        if (hit2.transform == null)
        {
            return false; // this is bad, we must be standing on floor
        }

        // move player
        transform.position += movement;

        //TODO: adjust player position to floor position (so stairs are possible)



        return true;
    }
}
