using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest7 : MonoBehaviour
{
    //��������Ʈ ü��(Delegate Chain)
    //�ϳ��� ��������Ʈ�� ���� �Լ��� ���ÿ� ������ �� �ִ�.
    
    public delegate void TestDelegate();
    private TestDelegate _testDelegate;

    void Chain1() { Debug.Log("Chain1"); }
    void Chain2() { Debug.Log("Chain2"); }
    void Chain3() { Debug.Log("Chain3"); }

    private void Start()
    {
        //���1
        TestDelegate test1 = new TestDelegate(Chain1);
        TestDelegate test2 = new TestDelegate(Chain2);
        TestDelegate test3 = new TestDelegate(Chain3);

        _testDelegate = Delegate.Combine(test1, test2) as TestDelegate;
        _testDelegate = Delegate.Combine(_testDelegate, test3) as TestDelegate;
        _testDelegate.Invoke();

        _testDelegate += Chain1;
        _testDelegate += Chain2;
        _testDelegate += Chain3;

        //���2
        _testDelegate = new TestDelegate(Chain1) 
                      + new TestDelegate(Chain2) 
                      + new TestDelegate(Chain3);
        _testDelegate.Invoke();

        //���3
        _testDelegate += new TestDelegate(Chain1);
        _testDelegate += new TestDelegate(Chain2);
        _testDelegate += new TestDelegate(Chain3);
        _testDelegate.Invoke();

        //���4(C# 2.0���� : ������õ)
        _testDelegate += Chain1;
        _testDelegate += Chain2;
        _testDelegate += Chain3;
    }
}
