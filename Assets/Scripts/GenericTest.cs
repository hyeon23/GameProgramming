using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

//���׸� Ŭ����
//���׸� ��������
/*
 * where T : struct
 * T�� �� ����
 * 
 * where T : class
 * T�� ���� ����
 * 
 * where T : new()
 * T�� �Ű����� �Ű����� ���� ������ �ʿ�
 * 
 * wnere T : �θ� Ŭ���� �̸�
 * T�� ����� �θ� Ŭ������ �ڽ� Ŭ����
 * 
 * where T : �������̽� �̸�
 * T�� ����� �������̽� ����
 * 
 * wherer T : U
 * T�� �Ƕ�� ���� �Ű����� U�κ��� ���
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
    //���׸� = ���׸� �Լ� + ���׸� Ŭ����
    public void Copy(int[] source, int[] target)
    {
        for (int i = 0; i < source.Length; i++)
        {
            target[i] = source[i];
        }
    }

    //��׸� �Լ�
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

        //ArrayList�� Generic = List<T>
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

        //Hashmap<Object, Object>�� Generic = Dictionary<TKey, TValue>
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic["�ϳ�"] = "one";
        dic["��"] = "one";
        dic["��"] = "one";

        Debug.Log(dic["�ϳ�"]);
        Debug.Log(dic["��"]);
        Debug.Log(dic["��"]);

        //Stack�� Generic = Stack<T>
        Stack<int> stk = new Stack<int>();
        stk.Push(1);
        stk.Push(2);
        stk.Push(3);
        while (stk.Count > 0) stk.Pop();

        //Queue�� Generic = Queue<T>
        Queue<int> que = new Queue<int>();
        que.Enqueue(1);
        que.Enqueue(2);
        que.Enqueue(3);
        while (que.Count > 0) que.Dequeue();
    }
}

