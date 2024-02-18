using System;
using System.Collections;
using UnityEngine;


public class Test : MonoBehaviour, IEnumerable, IEnumerator
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

    public enum Buff { None, Buff1, Buff2 }
    public Buff _buf;

    public int Func2(int num)
    {
        return num;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public object Current => throw new NotImplementedException();

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    
}