using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest2 : MonoBehaviour
{
    public delegate void TestDelegate();

    TestDelegate _testDelegate;

    private void Start()
    {
        _testDelegate = TargetF;
    }

    void Do(TestDelegate del)
    {
        del();
        del.Invoke();
    }

    void TargetF()
    {
        Debug.Log("TargetF");
    }
}
