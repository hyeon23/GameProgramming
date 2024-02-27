using System.Collections;
//선언 필수
using System.Linq;
using UnityEngine;

public class LinQ : MonoBehaviour
{
    /*
     * LinQ = Language INtergrated Query : 데이터 읽기 및 질이(Query) 기능
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
    //code가 1보다 큰 것을 찾아 오름차순 정렬 코드
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