//using System;
//using UnityEngine;

//[Serializable]
//public class Item
//{
//    public int code;
//    public string name;

//    public Item(int code, string name)
//    {
//        this.code = code;
//        this.name = name;
//    }

//    public void Print()
//    {
//        Debug.Log($"code : {code}, name : {name}");
//    }
//}

//public class ArrayListDict : MonoBehaviour
//{
//    public Item[] items = new Item[]
//    {
//        new Item(1, "carrot"),
//        new Item(2, "banana"),
//        new Item(3, "apple"),
//        new Item(4, "apple"),
//    };

//    void Start()
//    {

//        items[0].Print();
//        items[0].code = 0;

//        for (int i = 0; i < items.Length; i++)
//        {
//            items[i].Print();

//        }
//        //1. 정렬
//        System.Array.Sort(items, (x, y) => x.code.CompareTo(y.code));

//        //2. Array Foreach
//        System.Array.ForEach(items, item => item.Print());

//        //3. Exists: 배열 중 하나라도 존재하는 값이 있으면 true, 아니면 False 반환
//        bool b1 = System.Array.Exists(items, x => x.code == 3);

//        //4. TrueForAll: 배열의 모든 것이 성립하면 true, 아니면 false
//        bool b2 = System.Array.TrueForAll(items, x => x.code > 0);

//        //5. Find 계열
//        //5-1. Find
//        Item item1 = System.Array.Find(items, x => x.name == "apple");
//        item1?.Print();//null이 나오면 nullexception 에러 발생하므로 ?.를 통한접근
//        //5-2. FindIndex
//        int idx1 = System.Array.FindIndex(items, x => x.name == "apple");
//        //5-3. FindLast
//        Item item2 = System.Array.FindLast(items, x => x.name == "apple");
//        //5-4. FindLastIndex
//        int idx2 = System.Array.FindLastIndex(items, x => x.name == "apple");

//        //5-5. FindAll: 일치하는 모든 것을 배열로 반환
//        Item[] _items = System.Array.FindAll(items, x => x.name == "apple");
//        System.Array.ForEach(_items, item => item.Print());

//        //5-6. 깊은 복사
//        System.Array.ConvertAll(items, x => new Item(x.code, x.name));

//        //5-7. Reverse
//        System.Array.Reverse(items);//배열 뒤집기

//        //5-8. Resize: Array는 고정길이 배열 => 배열의 크기를 바꾸기 위해 Resize 사용
//        System.Array.Resize(ref items, 5);//앞에것부터 잔류
//    }
//}
