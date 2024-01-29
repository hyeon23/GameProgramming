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
        //items는 포인터 변수 -> 스택 할당
        //뒤 new Item 객체 -> 힙 할당

        //얕은 복사: 포인터만 준다.
        List<Item> _items1 = items;//동일한 주소를 가르킴

        _items1[0].code = 10;//items[0].code = 10;

        //깊은 복사: 완전 복사(새로운 공간(주소값) 할당 => 아예 새걸 만들어 복사 붙여넣기)
        List<Item> _items2 = items.ConvertAll(x => new Item(x.code, x.name));

        _items2[0].code = 10;//items2[0].code = 10; items[0] = 1;
    }
}