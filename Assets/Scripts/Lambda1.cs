using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lambda1 : MonoBehaviour
{
    delegate void TestDelegate();
    delegate int TestDelegate2(int num1, int num2);
    private void Start()
    {
        TestDelegate2 testDelegate2;
        testDelegate2 = delegate (int num1, int num2)
        {
            return num1 + num2;
        };
        int result = testDelegate2.Invoke(3, 5);
        Debug.Log(result);

        TestDelegate testDelegate;
        testDelegate = delegate ()
        {
            Debug.Log("Test Anonymous Function");
        };
        testDelegate.Invoke();
    }
}


