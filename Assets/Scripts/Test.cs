using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    public delegate void MyDel();
    public MyDel _myDel;

    public delegate int MyDel2(int num);
    public MyDel2 _myDel2;

    private void Start()
    {
        _myDel += Func1;

        _myDel2 += Func2;

        _myDel2(5);
    }

    public void Func1()
    {
        
    }
    
    public int Func2(int num)
    {
        return num;
    }

    public enum Buff {  None, Buff1, Buff2}
    public Buff _buf;
    public void BuffCheck(Buff buff)
    {
        Action action;
        Func<int> fnc
    }
}