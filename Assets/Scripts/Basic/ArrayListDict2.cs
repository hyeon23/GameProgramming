using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayListDict2 : MonoBehaviour
{
    private void Start()
    {
        //���� ���� & ���� ����
        Item[] items = new Item[]
        {
            new Item(1, "A"),
            new Item(2, "B"),
            new Item(3, "C"),
            new Item(4, "D"),
        };

        //items�� ������ ���� -> ���� �Ҵ�
        //�� new Item ��ü -> �� �Ҵ�

        //���� ����: �����͸� �ش�.
        Item[] _items1 = items;//������ �ּҸ� ����Ŵ

        _items1[0].code = 10;//items[0].code = 10;

        //���� ����: ���� ����(���ο� ����(�ּҰ�) �Ҵ� => �ƿ� ���� ����� ���� �ٿ��ֱ�)
        Item[] _items2 = System.Array.ConvertAll(items, x => new Item(x.code, x.name));
        
        _items2[0].code = 10;//items2[0].code = 10; items[0] = 1;
    }
}