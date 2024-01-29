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
        //리턴 값 X
        items.Add(item);

        //리턴 값 존재: bool
        bool b1 = items.Remove(item);//Remove 성공 시, true, 실패 시, false

        items.RemoveAt(0);//A 삭제

        //삭제한 아이템 수 리턴
        int count = items.RemoveAll(x => x.code > 5);//코드가 5 이상인 모든 아이템 삭제

        //1 위치에 해당 아이템을 삽입
        items.Insert(1, new Item(6, "F"));

        //List 정렬
        items.Sort((x, y) => x.code.CompareTo(y.code));

        //List 뒤집기
        items.Reverse();

        //Exists: 하나라도 존재하면, True 반환
        bool b2 = items.Exists(x => x.name == "A");

        //TrueForAll: List의 모든 원소가 조건을 만족 시, true
        bool b3 = items.TrueForAll(x => x.code > 1);

        //List Find 계열

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

        //리스트 -> 배열 변환
        Item[] itemArray = items.ToArray();
        //배열 -> 리스트 변환
        List<Item> lst = new List<Item>(itemArray);

    }
}