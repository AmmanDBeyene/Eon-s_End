using Assets.Event_Scripts;
using Assets.Event_Scripts.Conditions;
using Assets.Event_Scripts.Event_Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    // Start is called before the first frame update

    public bool Active = false;

    private EventNode _rootNode = null;
    private EventNode _currentNode = null;

    private List<IEventCondition> _conditions = new List<IEventCondition>();

    void Start()
    {
        _rootNode = new EventNode();
        EventCommand sceneTransition = new SceneSwitchCommand("SnowMap", new Vector3(-0.5f, 1.4f, 1.5f));
        sceneTransition.Conditions.Add(new InputCondition(KeyCode.Return));

        _rootNode.AddEventCommand(sceneTransition);
    }

    internal void SetCurrentNode(EventNode node)
    {
        _currentNode = node;
    }

    private bool ConditionsMet()
    {
        foreach (IEventCondition condition in _conditions)
        {
            if (!condition.IsMet())
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Active)
        {
            return;
        }

        if (_currentNode == null)
        {
            if (!ConditionsMet())
            { 
                return;
            }

            _currentNode = _rootNode;
        }

        _currentNode.Update();

        if (!_currentNode.Complete)
        {
            return;
        }

        if (_currentNode.Next != null)
        {
            _currentNode = _currentNode.Next;
        }
    }
}
