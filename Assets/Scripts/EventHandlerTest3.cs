using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : EventArgs
{
    private EventHandler _eventHandler;
    public event EventHandler eventHandler
    {
        add
        {
            Debug.Log("ADD");
            _eventHandler += value;
        }
        remove
        {
            Debug.Log("REMOVE");
            _eventHandler -= value;
        }
    }
    public void StartEvent()
    {
        _eventHandler.Invoke(this, EventArgs.Empty);
    }
}

public class EventHandlerTest3 : MonoBehaviour
{
    private void Start()
    {
        Event myEvent = new Event();
        myEvent.eventHandler += Test;
        myEvent.StartEvent();
    }

    void Test(object sender, EventArgs e)
    {
        Debug.Log("TEST");
    }
}
