using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest8 : MonoBehaviour
{
    private delegate void TestDelegate();
    private TestDelegate testDelegate;
    void Chain1() { Debug.Log("Chain1"); }
    void Chain2() { Debug.Log("Chain2"); }
    void Chain3() { Debug.Log("Chain3"); }

    private void Start()
    {
        testDelegate = Chain1;
        testDelegate += Chain1;
        testDelegate += Chain2;
        testDelegate += Chain3;
        testDelegate += Chain1;
        testDelegate += Chain2;

        Debug.Log("Border");
        testDelegate.Invoke();
        Debug.Log("Border");

        testDelegate -= Chain1;
        testDelegate -= Chain2;
        testDelegate -= Chain1;

        testDelegate.Invoke();
    }
}
