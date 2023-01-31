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

    private IEventPipe _rootPipe = null;
    private IEventPipe _currentPipe = null;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Active)
        {
            return;
        }

        if (_currentPipe == null)
        {
            _currentPipe = _rootPipe;
        }

        _currentPipe = _currentPipe.Flow();
    }
}
