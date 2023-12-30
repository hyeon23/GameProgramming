using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

//제네릭 클래스
//제네릭 제약조건
/*
 * where T : struct
 * T는 값 형식
 * 
 * where T : class
 * T는 참조 형식
 * 
 * where T : new()
 * T는 매개변수 매개변수 없는 생성자 필요
 * 
 * wnere T : 부모 클래스 이름
 * T는 명시한 부모 클래스의 자식 클래스
 * 
 * where T : 인터페이스 이름
 * T는 명시한 인터페이스 구현
 * 
 * wherer T : U
 * T는 또라는 형식 매개변수 U로부터 상속
 */
public class return_Generic<T>
{
    private T num;
    public T Return()
    {
        return num;
    }
}

public class GenericTest : MonoBehaviour
{
    //제네릭 = 제네릭 함수 + 제네릭 클래스
    public void Copy(int[] source, int[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    //재네릭 함수
    public void Copy<T>(T[] source, T[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    private void Start()
    {
        int[] SourceArr = { 1, 1, 1 };
        int[] targetArr = { 2, 2, 2 };
        Copy(SourceArr, targetArr);
        Copy<int>(SourceArr, targetArr);

        string[] strArr1 = { "1", "2", "3", "4", "5", "6", };
        string[] strArr2 = { "1", "2", "3", "4", "5", "6", };
        Copy<string>(strArr1, strArr2);

        return_Generic<int> intGeneric = new return_Generic<int>();
        return_Generic<string> stringGeneric = new return_Generic<string>();

        //ArrayList의 Generic = List<T>
        List<int> list = new List<int>();

        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);
        list.Add(50);

        list.RemoveAt(0);
        list.Remove(40);
        list.Insert(1, 25);
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }

        //Hashmap<Object, Object>의 Generic = Dictionary<TKey, TValue>
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic["하나"] = "one";
        dic["둘"] = "one";
        dic["셋"] = "one";

        Debug.Log(dic["하나"]);
        Debug.Log(dic["둘"]);
        Debug.Log(dic["셋"]);

        //Stack의 Generic = Stack<T>
        Stack<int> stk = new Stack<int>();
        stk.Push(1);
        stk.Push(2);
        stk.Push(3);
        while (stk.Count > 0) stk.Pop();

        //Queue의 Generic = Queue<T>
        Queue<int> que = new Queue<int>();
        que.Enqueue(1);
        que.Enqueue(2);
        que.Enqueue(3);
        while (que.Count > 0) que.Dequeue();
    }
}

