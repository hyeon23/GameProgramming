using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnumeratorTest2 : MonoBehaviour
{
    public class MyList
    {
        public Enumerator GetEnumerator()
        {
            Enumerator enumerator = new Enumerator();
            return enumerator;
        }
        public class Enumerator : IEnumerator
        {
            int[] num = new int[5] { 1, 2, 3, 4, 5 };
            int index = -1;
            public object Current { get { return num[index]; } }
            //�̵� ���� ��, true, �̵� �Ұ� �� false;
            public bool MoveNext()
            {
                if (index == num.Length - 1) return false;
                index++;
                return index < num.Length;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }

    private void Start()
    {
        MyList myList = new MyList();
        foreach(var one in myList)
        {
            Debug.Log(one);
        }
    }

    //Enumerator ���� ���� ����
    //foreach�� �� �ڵ尡 ���������� ��� ����Ǵ��� Ȯ�� 
    private void Start()
    {
        MyList myList = new MyList();
        MyList.Enumerator e = myList.GetEnumerator();

        while (e.MoveNext())
        {
            Debug.Log(e.Current);
        }
    }

    //Enumerator ȣ�� ���
    //���� ȣ��: ���� ȣ���� ���� ������ ��⸦ ����
}
