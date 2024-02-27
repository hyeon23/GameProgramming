using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandlerTest : MonoBehaviour
{
    public event EventHandler eventHandler;

    private void Start()
    {
        eventHandler += Test;

        eventHandler.Invoke(this, EventArgs.Empty);
    }

    void Test(object o, EventArgs e)
    {
        Debug.Log("Event Handler Test");
    }
}
