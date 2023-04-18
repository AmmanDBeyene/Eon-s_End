using EECore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameStateManager.playerPosition;
        GameStateManager.player = gameObject;
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

    bool TryMove(Vector3 movement)
    {
        // cast ray from center of player to new theorized position

        Vector3 start = transform.position;
        Vector3 end = start + movement;

        RaycastHit hit = Extensions.Cast(start, end);

        if (hit.transform != null)
        {
            return false; // we're going to hit a wall, stop movement
        }

        // good, we can move in this direction. 
        // Now check if there's a floor to stand on within
        // The appropriate range

        Vector3 end2 = end + Vector3.down; // floor checker
        RaycastHit hit2 = Extensions.Cast(end, end2);

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