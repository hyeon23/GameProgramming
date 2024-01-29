using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrayListDict5 : MonoBehaviour
{
    //List
    [SerializeField]
    Dictionary<string, Item> items = new Dictionary<string, Item>()
    {
        { "A", new Item(1, "A") },
        { "B", new Item(2, "B") },
        { "C", new Item(3, "C") },
        { "D", new Item(4, "D") },
        { "E", new Item(5, "E") },
    };


    private void Start()
    {
        Item item = items["A"];//Key를 인덱스로 사용
        items.Add("F", new Item(6, "F"));
        items.Remove("F");

        foreach(var key in items)
        {
            //Key & Value 변수
            print(key.Key);
            key.Value.Print();

            //키 존재 여부 확인
            bool b1 = items.ContainsKey("A");

            bool b2 = items.ContainsValue(item);

            //key를 찾으면 true, 못찾으면 false, __item 변수에 저장
            bool b3 = items.TryGetValue("A", out Item __item);
        }
    }
}