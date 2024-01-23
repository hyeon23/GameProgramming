using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionStudy : MonoBehaviour
{
    //미리 선언된 델리게이트
    //1. EventHandler
    //public delegate void EventHandler(object sender, EventArgs e);
    //2. Action
    //public delegate void Action();
    //매개변수, 리턴값 없는 델리게이트
    //3. Func(Function)

    Action action;

    private void Start()
    {
        action += () => { Debug.Log("Action1"); };
        action += () => { Debug.Log("Action2"); };
        action += () => { Debug.Log("Action3"); };

        action.Invoke();
    }
}
