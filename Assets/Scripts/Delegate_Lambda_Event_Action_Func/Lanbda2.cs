using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanbda2 : MonoBehaviour
{
    delegate void TestDelegate();
    delegate int TestDelegate2(int num1, int num2);

    private void Start()
    {
        TestDelegate testDel;
        TestDelegate2 testDel2;
        testDel = () => Debug.Log("TestFunction");
        testDel2 = (num1, num2) =>
        {
            Debug.Log(num1);
            Debug.Log(num2);
            return num1 + num2;
        };
        testDel.Invoke();
    }
}
