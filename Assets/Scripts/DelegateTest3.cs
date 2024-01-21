using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest3 : MonoBehaviour
{
    public delegate void DelegateTest();

    public DelegateTest _testDelegate;

    private void Start()
    {
        DelegateTest result = Do();
    }

    DelegateTest Do()
    {
        return _testDelegate = TargetF;
    }

    void TargetF()
    {
        Debug.Log("TargetF");
    }
}
