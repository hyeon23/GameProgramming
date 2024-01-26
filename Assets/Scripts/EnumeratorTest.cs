using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumeratorTest : MonoBehaviour
{
    //Enumerator(열거자)
    //데이터 요소를 하나씩 리턴하는 기능
    //C# 에서는 IEnumerator 인터페이스를 통해 구현
    //코루틴을 이해하기 위해선, Enumerator 열거자를 이해해야 쉬움


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
    //    //foreach문 실행 조건 
    //    //문제1: GetEnumerator 함수가 존재하지 않음
    //    //해당 클래스에 GetEnumerator 함수 생성
    //    //문제2: bool MoveNext() 함수와 Current 속성(프로퍼티)를 지닌 Enumerator 클래스를 반환하는 GetEnumerator 함수가 필요하다.
    //    //이를 생성
    //    foreach(var one in myList)
    //    {
    //        Debug.Log(one);
    //    }
    //}
}
