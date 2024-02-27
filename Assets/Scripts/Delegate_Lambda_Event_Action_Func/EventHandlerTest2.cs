using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EventTest
{
    public string _name;
    public EventTest(string name)
    {
        _name = name;
    }
}
public class EventHandlerTest2 : MonoBehaviour
{
    public event EventHandler<EventTest> eventHandler;
    private void Start()
    {
        EventTest eventTest = new EventTest("EventTest");

        eventHandler += Test;
        eventHandler.Invoke(this, eventTest);
    }

    void Test(object o, EventTest e)
    {
        Debug.Log(e._name);
    }
}
