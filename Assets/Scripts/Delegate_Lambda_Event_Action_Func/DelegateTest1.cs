using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest1 : MonoBehaviour
{
    public delegate void MyDelegate();//��������Ʈ ���� ���
    public MyDelegate _myDelegate;//������ ��������Ʈ�� ��ü ����(����)

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

        //C# 1.0 ���� : �����ڸ� Ȱ���� �� ��ü ������
        _myDelegate = new MyDelegate(TestFunction);

        //C# 2.0 ���� : Pred(�Լ� ��ü)�� Ȱ���� �� ��ü ������
        _myDelegate = TestFunction;

        _myDelegate();
    }
}
