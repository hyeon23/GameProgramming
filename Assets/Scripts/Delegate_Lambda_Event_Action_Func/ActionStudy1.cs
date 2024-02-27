using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ActionStudy1 : MonoBehaviour
{
    Action<int> action1;
    Action<int, int> action2;
    Action<string, string, string> action3;
    private void Start()
    {
        action1 += Test1;
        action2 += Test2;
        action3 += Test3;
        action1.Invoke(1);
        action2.Invoke(2, 3);
        action3.Invoke("Bitcoin", "Bull", "Market");
    }
    public void Test1(int num1) { Debug.Log(num1); }
    public void Test2(int num1, int num2) { Debug.Log(num1 + num2); }
    public void Test3(string str1, string str2, string str3) { Debug.Log(str1 + str2 + str3); }
}
