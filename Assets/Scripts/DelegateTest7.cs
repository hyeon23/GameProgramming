using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest7 : MonoBehaviour
{
    //델리게이트 체인(Delegate Chain)
    //하나의 델리게이트가 여러 함수를 동시에 참조할 수 있다.
    
    public delegate void TestDelegate();
    private TestDelegate _testDelegate;

    void Chain1() { Debug.Log("Chain1"); }
    void Chain2() { Debug.Log("Chain2"); }
    void Chain3() { Debug.Log("Chain3"); }

    private void Start()
    {
        //방법1
        TestDelegate test1 = new TestDelegate(Chain1);
        TestDelegate test2 = new TestDelegate(Chain2);
        TestDelegate test3 = new TestDelegate(Chain3);

        _testDelegate = Delegate.Combine(test1, test2) as TestDelegate;
        _testDelegate = Delegate.Combine(_testDelegate, test3) as TestDelegate;
        _testDelegate.Invoke();

        _testDelegate += Chain1;
        _testDelegate += Chain2;
        _testDelegate += Chain3;

        //방법2
        _testDelegate = new TestDelegate(Chain1) 
                      + new TestDelegate(Chain2) 
                      + new TestDelegate(Chain3);
        _testDelegate.Invoke();

        //방법3
        _testDelegate += new TestDelegate(Chain1);
        _testDelegate += new TestDelegate(Chain2);
        _testDelegate += new TestDelegate(Chain3);
        _testDelegate.Invoke();

        //방법4(C# 2.0버전 : 가장추천)
        _testDelegate += Chain1;
        _testDelegate += Chain2;
        _testDelegate += Chain3;
    }
}
