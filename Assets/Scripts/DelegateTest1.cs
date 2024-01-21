using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest1 : MonoBehaviour
{
    public delegate void MyDelegate();//델리게이트 정의 방법
    public MyDelegate _myDelegate;//선언한 델리게이트의 객체 선언(생성)

    public delegate int MyDelegate2(int num);
    public MyDelegate2 _myDelegate2;

    public void TestFunction()
    {
        Debug.Log("Test");
    }

    public int TestFunction2(int num)
    {
        return num;
    }
    public void Start()
    {
        _myDelegate += TestFunction;
        _myDelegate2 += TestFunction2;

        //C# 1.0 버전 : 생성자를 활용한 새 객체 생성법
        _myDelegate = new MyDelegate(TestFunction);

        //C# 2.0 버전 : Pred(함수 객체)를 활용한 새 객체 생성법
        _myDelegate = TestFunction;

        _myDelegate();
    }
}
