using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumeratorTest : MonoBehaviour
{
    //Enumerator(������)
    //������ ��Ҹ� �ϳ��� �����ϴ� ���
    //C# ������ IEnumerator �������̽��� ���� ����
    //�ڷ�ƾ�� �����ϱ� ���ؼ�, Enumerator �����ڸ� �����ؾ� ����


    //private void Start()
    //{
    //    int[] list = new int[5] { 1, 2, 3, 4, 5 };
    //    foreach(var one in list) Debug.Log(one);
    //}

    public class MyList
    {
        public Enumerator GetEnumerator()
        {
            Enumerator enumerator = new Enumerator();
            return enumerator;
        }

        public class Enumerator
        {
            public object Current { get; }
            public bool MoveNext()
            {
                return true;
            }
        }
    }

    //private void Start()
    //{
    //    MyList myList = new MyList();
    //    //foreach�� ���� ���� 
    //    //����1: GetEnumerator �Լ��� �������� ����
    //    //�ش� Ŭ������ GetEnumerator �Լ� ����
    //    //����2: bool MoveNext() �Լ��� Current �Ӽ�(������Ƽ)�� ���� Enumerator Ŭ������ ��ȯ�ϴ� GetEnumerator �Լ��� �ʿ��ϴ�.
    //    //�̸� ����
    //    foreach(var one in myList)
    //    {
    //        Debug.Log(one);
    //    }
    //}
}
