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
//        //1. ����
//        System.Array.Sort(items, (x, y) => x.code.CompareTo(y.code));

//        //2. Array Foreach
//        System.Array.ForEach(items, item => item.Print());

//        //3. Exists: �迭 �� �ϳ��� �����ϴ� ���� ������ true, �ƴϸ� False ��ȯ
//        bool b1 = System.Array.Exists(items, x => x.code == 3);

//        //4. TrueForAll: �迭�� ��� ���� �����ϸ� true, �ƴϸ� false
//        bool b2 = System.Array.TrueForAll(items, x => x.code > 0);

//        //5. Find �迭
//        //5-1. Find
//        Item item1 = System.Array.Find(items, x => x.name == "apple");
//        item1?.Print();//null�� ������ nullexception ���� �߻��ϹǷ� ?.�� ��������
//        //5-2. FindIndex
//        int idx1 = System.Array.FindIndex(items, x => x.name == "apple");
//        //5-3. FindLast
//        Item item2 = System.Array.FindLast(items, x => x.name == "apple");
//        //5-4. FindLastIndex
//        int idx2 = System.Array.FindLastIndex(items, x => x.name == "apple");

//        //5-5. FindAll: ��ġ�ϴ� ��� ���� �迭�� ��ȯ
//        Item[] _items = System.Array.FindAll(items, x => x.name == "apple");
//        System.Array.ForEach(_items, item => item.Print());

//        //5-6. ���� ����
//        System.Array.ConvertAll(items, x => new Item(x.code, x.name));

//        //5-7. Reverse
//        System.Array.Reverse(items);//�迭 ������

//        //5-8. Resize: Array�� �������� �迭 => �迭�� ũ�⸦ �ٲٱ� ���� Resize ���
//        System.Array.Resize(ref items, 5);//�տ��ͺ��� �ܷ�
//    }
//}
