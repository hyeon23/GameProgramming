using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMail : EventArgs
{
    public string _name;
    public EventMail(string name)
    {
        _name = name;
    }
}

public class EventHandlerTest1 : MonoBehaviour
{
    public event EventHandler eventHandler;
    private void Start()
    {
        EventMail mail = new EventMail("Event Mail Test1");
        eventHandler += Test;
        eventHandler.Invoke(this, mail);//자동 형변환 수행
    }
    void Test(object o, EventArgs e)
    {
        Debug.Log(((EventMail)e)._name);
    }
}
