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
            //이동 성공 시, true, 이동 불가 시 false;
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

    //Enumerator 내부 실행 로직
    //foreach의 위 코드가 내부적으로 어떻게 실행되는지 확인 
    private void Start()
    {
        MyList myList = new MyList();
        MyList.Enumerator e = myList.GetEnumerator();

        while (e.MoveNext())
        {
            Debug.Log(e.Current);
        }
    }

    //Enumerator 호출 방식
    //지연 호출: 다음 호출이 있을 때까지 대기를 수행
}
