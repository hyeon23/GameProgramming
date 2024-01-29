using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class ArrayListDict3 : MonoBehaviour
{
    //List
    [SerializeField]
    List<Item> items = new List<Item>()
    {
        new Item(1, "A"),
        new Item(2, "B"),
        new Item(3, "C"),
        new Item(4, "D"),
    };

    private void Start()
    {
        items[0].code = 3;
        items[0].Print();

        for(int i = 0; i < items.Count; ++i)
        {
            items[i].Print();
        }

        foreach(var i in items)
        {
            i.Print();
        }

        Item item = new Item(5, "E");
        //���� �� X
        items.Add(item);

        //���� �� ����: bool
        bool b1 = items.Remove(item);//Remove ���� ��, true, ���� ��, false

        items.RemoveAt(0);//A ����

        //������ ������ �� ����
        int count = items.RemoveAll(x => x.code > 5);//�ڵ尡 5 �̻��� ��� ������ ����

        //1 ��ġ�� �ش� �������� ����
        items.Insert(1, new Item(6, "F"));

        //List ����
        items.Sort((x, y) => x.code.CompareTo(y.code));

        //List ������
        items.Reverse();

        //Exists: �ϳ��� �����ϸ�, True ��ȯ
        bool b2 = items.Exists(x => x.name == "A");

        //TrueForAll: List�� ��� ���Ұ� ������ ���� ��, true
        bool b3 = items.TrueForAll(x => x.code > 1);

        //List Find �迭

        Item fi = items.Find(x => x.name == "E");
        fi.Print();
        int idx = items.FindIndex(x => x.name == "A");
        print(idx);
        item = items.FindLast(x => x.name == "B");
        print(idx);
        idx = items.FindLastIndex(x => x.name == "C");
        print(idx);
        List<Item> _items = items.FindAll(x => x.code > 2);
        _items.ForEach(x => x.Print());

        //����Ʈ -> �迭 ��ȯ
        Item[] itemArray = items.ToArray();
        //�迭 -> ����Ʈ ��ȯ
        List<Item> lst = new List<Item>(itemArray);

    }
}