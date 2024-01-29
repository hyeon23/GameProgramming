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
        Item item = items["A"];//Key�� �ε����� ���
        items.Add("F", new Item(6, "F"));
        items.Remove("F");

        foreach(var key in items)
        {
            //Key & Value ����
            print(key.Key);
            key.Value.Print();

            //Ű ���� ���� Ȯ��
            bool b1 = items.ContainsKey("A");

            bool b2 = items.ContainsValue(item);

            //key�� ã���� true, ��ã���� false, __item ������ ����
            bool b3 = items.TryGetValue("A", out Item __item);
        }
    }
}