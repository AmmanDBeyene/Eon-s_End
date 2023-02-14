using Assets.Event_Scripts;
using Assets.Event_Scripts.Conditions;
using Assets.Event_Scripts.Event_Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Active = false;

    public IEventPipe rootPipe { get; protected set; }
    private IEventPipe _currentPipe = null;
    
    // Update is called once per frame
    void Update()
    {
        if (!Active)
        {
            return;
        }

        if (_currentPipe == null)
        {
            _currentPipe = rootPipe;
        }

        if (_currentPipe == null)
        {
            return; // The current pipe should never be null here
                    // only if the root pipe is null. Which means
                    // this event should not be running in the first
                    // place
        }

        _currentPipe = _currentPipe.Flow();
    }
}
