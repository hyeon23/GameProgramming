using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrayListDict4 : MonoBehaviour
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
        //items�� ������ ���� -> ���� �Ҵ�
        //�� new Item ��ü -> �� �Ҵ�

        //���� ����: �����͸� �ش�.
        List<Item> _items1 = items;//������ �ּҸ� ����Ŵ

        _items1[0].code = 10;//items[0].code = 10;

        //���� ����: ���� ����(���ο� ����(�ּҰ�) �Ҵ� => �ƿ� ���� ����� ���� �ٿ��ֱ�)
        List<Item> _items2 = items.ConvertAll(x => new Item(x.code, x.name));

        _items2[0].code = 10;//items2[0].code = 10; items[0] = 1;
    }
}