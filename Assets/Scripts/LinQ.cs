using System.Collections;
//���� �ʼ�
using System.Linq;
using UnityEngine;

public class LinQ : MonoBehaviour
{
    /*
     * LinQ = Language INtergrated Query : ������ �б� �� ����(Query) ���
     * 
     * 
     */
    Item[] items = new Item[]
    {
        new Item(3,"carrot"),
        new Item(2,"banana"),
        new Item(1,"apple"),
        new Item(4,"melon"),
    };
    //code�� 1���� ū ���� ã�� �������� ���� �ڵ�
    //IEnumerable<Item> _items =
    //    from item in items
    //    where item.code > 1
    //    orderby item.code
    //    select item;

    //IEnumerable<Item> _items2 = items
    //    .Where(x => x.code > 1);
    //    .OrderBy(x => Matrix4x4.code);
    //j


}