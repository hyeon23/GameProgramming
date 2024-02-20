using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test : MonoBehaviour
{
    IEnumerable<Item> _items;

    Item[] items = new Item[]
    {
        new Item(2, "carrot"),
        new Item(1, "apple"),
        new Item(3, "banana"),
        new Item(4, "orange"),
    };

    Item[] items2 = new Item[]
    {
        new Item(4, "orange"),
        new Item(1, "apple"),
        new Item(3, "banana"),
        new Item(5, "grape"),
    };

    Item[] items3 = new Item[]
    {
        new Item(2, "carrot"),
        new Item(1, "apple"),
        new Item(3, "banana"),
        new Item(4, "orange"),
    };

    Item[] items4 = new Item[]
    {
        new Item(2, "carrot"),
        new Item(2, "carrot"),
        new Item(1, "apple"),
        new Item(3, "banana"),
        new Item(3, "banana"),
        new Item(4, "orange"),
    };

    Item[] items5 = new Item[]
    {
        new Item(2, "potato"),
        new Item(2, "carrot"),
        new Item(1, "apple"),
        new Item(3, "melon"),
        new Item(3, "banana"),
        new Item(4, "orange"),
    };

    class School
    {
        public string name;
        public int[] scores;
    }

    School[] schools =
    {
        new School(){ name = "A��", scores = new int[] { 70, 60, 30, 80} },
        new School(){ name = "A��", scores = new int[] { 20, 65, 35, 85} }
    };

    class User
    {
        public int userCode;
        public string userName;
    }

    User[] users =
    {
        new User() { userCode = 2, userName = "A"},
        new User() { userCode = 1, userName = "B"},
        new User() { userCode = 3, userName = "C"},
        new User() { userCode = 5, userName = "D"}
    };

    User[] users2 =
    {
        new User() { userCode = 2, userName = "A"},
        new User() { userCode = 2, userName = "A+"},
        new User() { userCode = 1, userName = "B"},
        new User() { userCode = 3, userName = "C"},
        new User() { userCode = 3, userName = "C+"},
        new User() { userCode = 5, userName = "D"}
    };


    void Start()
    {
        // LINQ ��(10���� ����)�� LINQ �Լ�(50���� ����)�� �⺻��
        {
            _items = from item in items
                     where item.code > 1
                     orderby item.code
                     select item;

            _items = items.Where(x => x.code > 1).OrderBy(x => x.code);
        }



        // ## LINQ ��

        // from : ������ ��������
        {
            _items = from item in items
                     select item;

            foreach (var _item in _items)
                _item.Print();
        }

        // select : ������ �����ϱ�
        {
            IEnumerable<int> codes = from item in items
                                     select item.code;

            foreach (var code in codes)
                print(code);
        }

        // where : ������ ã��
        {
            _items = from item in items
                     where item.code > 1
                     select item;
        }

        // orderby : ������ ����, �⺻�� ��������, ascending ��������, descending ��������
        {
            _items = from item in items
                     orderby item.name
                     select item;

            _items = from item in items
                     orderby item.name ascending
                     select item;

            _items = from item in items
                     orderby item.name descending
                     select item;
        }

        // IEnumerable������ �迭�� ����Ʈ�� �ٲ� �� �ִ�
        {
            int[] codes = (from item in items
                           select item.code).ToArray();

            List<int> codes2 = (from item in items
                                select item.code).ToList();
        }

        // from�� �ߺ��� �� �� �ִ�. select new { } �� �͸����� �����
        {
            var _schools = from classes in schools
                           from scores in classes.scores
                           where scores < 50
                           select new { name = classes.name, lowScore = scores };

            foreach (var _school in _schools)
                print(_school);
        }

        // group : ������ �з��ϱ�
        {
            var _itemGroups = from item in items
                              group item by item.code > 2 into g
                              select new { GroupKey = g.Key, GroupItem = g };

            foreach (var _itemGroup in _itemGroups)
            {
                print($"2���� ŭ? : {_itemGroup.GroupKey}");
                foreach (Item item in _itemGroup.GroupItem)
                    item.Print();
            }
        }

        // ����join : from�� �����Ͽ� �����ϴ� �κи� ���ϱ�
        {
            var itemJoins = from item in items
                            join user in users on item.code equals user.userCode
                            select new { Code = item.code, UserName = user.userName, ItemName = item.name };

            foreach (var itemJoin in itemJoins)
                print(itemJoin);
        }

        // �ܺ�join : from�� �����Ͽ� ��� �κ��� ���ϱ�, DefaultIfEmpty�� �� �⺻�� ä���
        {
            var itemJoins = from item in items
                            join user in users on item.code equals user.userCode into excepts
                            from user in excepts.DefaultIfEmpty(new User() { userName = "NONE" })
                            select new { Code = item.code, UserName = user.userName, ItemName = item.name };

            foreach (var itemJoin in itemJoins)
                print(itemJoin);
        }



        // ## LINQ �Լ�



        // # ����

        // OrderBy : �������� ����
        _items = items.OrderBy(x => x.code);

        // OrderByDescending : �������� ����
        _items = items.OrderByDescending(x => x.code);

        // ThenBy : ���ĵ� �� �ڿ� ������������ 2�� ����
        _items = items5.OrderBy(x => x.code).ThenBy(x => x.name);

        // ThenByDescending : ���ĵ� �� �ڿ� ������������ 2�� ����
        _items = items5.OrderBy(x => x.code).ThenByDescending(x => x.name);

        // Reverse : ���� ������
        _items = items.Reverse();



        // # ����

        // Distinct : �ߺ� ����, Item : System.IEquatable<Item> �������̽� ����
        _items = items4.Distinct();

        // Except : ������ items - items2
        _items = items.Except(items2);

        // Intersect : ������ items �� items2
        _items = items.Intersect(items2);

        // Union : ������ items �� items2
        _items = items.Union(items2);



        // # ���͸�

        // Where : ������ true�� ���� ����
        _items = items.Where(x => x.code > 1);



        // # ��������

        // All : ��� ������ �������Ѿ� true
        {
            bool b = items.All(x => x.code > 0);
            print(b);
        }

        // Any : �ϳ��� true��� true
        {
            bool b = items.Any(x => x.code > 3);
            print(b);
        }

        // Contains : ���Կ���, ItemComparer : IEqualityComparer<Item> Ŭ���� ����
        {
            bool b = items.Contains(new Item(3, "banana"), new ItemComparer());
            print(b);
        }



        // # ������ ����

        // Select : ���� ������ IEnumerable���� ����
        {
            IEnumerable<int> codes = items.Select(x => x.code);
            foreach (int code in codes)
                print(code);
            var _customItems = items.Select(x => new { Name = x.name, CodeAdd = x.code + 1 });
            foreach (var _customItem in _customItems)
                print(_customItem);
        }

        // SelectMany : ���� ��� ������ ����
        // {(10,cat), (10,dog), (10,donkey), (20,cat), (20,dog), (20,donkey)}
        {
            int[] number = new int[] { 10, 20 };
            string[] animals = new string[] { "cat", "dog", "donkey" };
            var mix = number.SelectMany(num => animals, (n, a) => new { n, a });
            foreach (var a in mix)
                print(a);
        }



        // # ������ ����

        // Skip : �ǳʶٰ� �ε������� ����
        _items = items.Skip(2);

        // SkipWhile : ������� ���ĵ��� ��, true�� ���� ��ŵ
        // {1, 2, 3, 4}���� 3���� ���� ������ ��ŵ, 3, 4�� ����
        _items = items.OrderBy(x => x.code).SkipWhile(x => x.code < 3);

        // Take : �տ������� ������ŭ ��������
        _items = items.Take(2);

        // TakeWhile : ������� ���ĵ��� ��, true�� ���� ��������
        // {1, 2, 3, 4}���� 3���� ���� ���� ��������, 1, 2�� ����
        _items = items.OrderBy(x => x.code).TakeWhile(x => x.code < 3);



        // # ������ ����

        // ����Join : �����ϴ� �κи� ���ϱ�, �ܺ�join�� LINQ���� ����
        {
            var itemJoins = items.Join(users, item => item.code, user => user.userCode,
                        (item, user) => new { Code = item.code, UserName = user.userName, ItemName = item.name });

            foreach (var itemJoin in itemJoins)
                print(itemJoin);
        }

        // GroupJoin : group + join �׷��� �����鼭 ����
        {
            var itemGroupJoins = items.GroupJoin(users2, item => item.code, user2 => user2.userCode,
                             (item, users2Collection) => new {
                                 Code = item.code,
                                 ItemName = item.name,
                                 UserNames = users2Collection.Select(user2 => user2.userName)
                             });

            foreach (var itemGroupJoin in itemGroupJoins)
            {
                print($"Code : {itemGroupJoin.Code}, ItemName : {itemGroupJoin.ItemName}");
                foreach (var _UserName in itemGroupJoin.UserNames)
                    print(_UserName);
            }
        }



        // # ������ �׷�ȭ

        // GroupBy : �׷����� ����
        {
            var itemGroups = items.GroupBy(item => item.code > 2, item => item,
                (key, item) => new { Key = key, Item = item });

            foreach (var itemGroup in itemGroups)
            {
                print($"2���� ŭ? : {itemGroup.Key}");
                foreach (var item in itemGroup.Item)
                    item.Print();
            }
        }

        // ToLookUp : Ű�� �ڵ����� �������ִ� �׷�
        {
            var itemGroups = items.ToLookup(item => item.code > 2, item => item);

            foreach (var itemGroup in itemGroups)
            {
                print($"2���� ŭ? : {itemGroup.Key}");
                foreach (var item in itemGroup)
                    item.Print();
            }
        }



        // # ����

        // DefaultIfEmpty : �� �÷����� �⺻ �ϳ��� ����
        {
            List<Item> itemEmpty = new List<Item>();
            Item defaultItem = new Item(-1, "NONE");

            foreach (Item item in itemEmpty.DefaultIfEmpty(defaultItem))
                item.Print();
        }

        // Empty : �� IEnumerable�� ����
        {
            IEnumerable<Item> emptyItem = Enumerable.Empty<Item>();
            print(emptyItem.Count());
        }

        // Range : ���� ������ ���ڵ��� ����, ���� ���ں��� ��������
        {
            IEnumerable<int> ranges = Enumerable.Range(3, 10).Select(x => x * x);

            foreach (var range in ranges)
                print(range);
        }

        // Repeat : �ݺ��Ͽ� ����
        {
            IEnumerable<string> strings = Enumerable.Repeat("Hi", 10);

            foreach (var str in strings)
                print(str);
        }



        // # ���� ���� ��

        // SequenceEqual : �� ���� ��ġ�ϴ���
        {
            bool b = items.SequenceEqual(items3);
            print(b);
        }



        // # ��� ����

        // ElementAt : �ش� �ε����� ������
        {
            Item _item = items.ElementAt(3);
            _item.Print();
        }

        // ElementAtOrDefault : �ε����� ������ �� ������ null
        {
            Item _item = items.ElementAtOrDefault(3);
            _item.Print();
        }

        // First : ù��°�� ������, ���ǿ� �´� ù��°�� ������
        {
            Item _item = items.First();
            _item = items.First(x => x.code > 2);
            _item.Print();
        }

        // FirstOrDefault : ù��°�� ������, ���ǿ� �´� ù��°�� ������, �ε����� ������ �� ������ null
        {
            Item _item = items.FirstOrDefault();
            _item = items.FirstOrDefault(x => x.code > 1);
            _item.Print();
        }

        // Last : �������� ������, ���ǿ� �´� �������� ������
        {
            Item _item = items.Last();
            _item = items.Last(x => x.code > 2);
            _item.Print();
        }

        // LastOrDefault : �������� ������, ���ǿ� �´� �������� ������, �ε����� ������ �� ������ null
        {
            Item _item = items.LastOrDefault();
            _item = items.LastOrDefault(x => x.code < 4);
            _item.Print();
        }

        // Single : �� �ϳ��� �� ������ �������Ѿ� InvalidOperationException������ �� ��
        {
            Item _item = items.Single(x => x.code > 3);
            _item.Print();
        }

        // SingleOrDefault : �� �ϳ��� �� ������ �������Ѿ� InvalidOperationException������ �� ��
        // �ε����� ������ �� ������ null
        {
            Item _item = items.SingleOrDefault(x => x.code > 3);
            _item.Print();
        }



        // # ���� ��ȯ

        // AsEnumerable : IEnumerable �������� ��ȯ
        {
            IEnumerable<Item> _items = items.AsEnumerable();
        }

        // AsQueryable : IQueryable �������� ��ȯ, LINQ�� SQL�� �����ϴµ� ����
        // IEnumerable�� �������̽��� IEnumerable��������, IQueryable�� IEnumerable�� ������
        {
            IQueryable<Item> _items = items.AsQueryable();
        }

        // Cast : ArrayList���� �� Ÿ�Ը� ����, ���н� InvalidCastException ������
        {
            //ArrayList itemArray = new ArrayList { 1, "2", 3, 4, 5 };
            ArrayList itemArray = new ArrayList { 1, 2, 3, 4, 5 };
            IEnumerable<int> _items = itemArray.Cast<int>();
            foreach (var _item in _items) print(_item);
        }

        // OfType : ArrayList���� �� Ÿ�Ը� ����, ���д� �ǳʶٰ� 2�� 4�� ����
        {
            ArrayList itemArray = new ArrayList { 1, "2", 3, "4", 5 };
            IEnumerable<string> _items = itemArray.OfType<string>();
            foreach (string _item in _items) print(_item);
        }

        // ToArray : �迭�� ��ȯ
        {
            List<string> strs = new List<string>() { "zz", "ss" };
            string[] _strs = strs.ToArray();
        }

        // ToList : ����Ʈ�� ��ȯ
        {
            List<Item> itemList = items.ToList();
        }

        // ToDictionary : ������ Ű�� ��ųʸ��� ����
        {
            Dictionary<int, Item> itemDic = items.ToDictionary(x => x.code);
            foreach (var keyValue in itemDic)
            {
                print($"Ű : {keyValue.Key}");
                keyValue.Value.Print();
            }
        }

        // ToLookup : Ű ���������� ����
        {
            ILookup<int, string> lookup = items.ToLookup(x => x.code, y => y.name);
            foreach (var group in lookup)
            {
                print($"Ű : {group.Key}");
                foreach (var g in group)
                    print($"�� : {g}");
            }
        }



        // # ����

        // Concat : �� ���� �ϳ��� ����
        {
            IEnumerable<string> strs = items.Select(x => x.name).Concat(items2.Select(x => x.name));

            foreach (var str in strs)
                print(str);
        }



        // # ����

        // Aggregate : ���� ���
        {
            int total = items.Aggregate(0, (total, next) => total += next.code);
            print(total);
        }

        // Average : ���
        {
            double avg = items.Average(x => x.code);
            print(avg);
        }

        // Count : ����
        {
            int count = items.Count();
            print(count);
        }

        // LongCount : long���� ����
        {
            long longCount = items.LongCount();
            print(longCount);
        }

        // Max : �ִ�
        {
            int maxCode = items.Max(x => x.code);
            print(maxCode);
        }

        // Min : �ּڰ�
        {
            int minCode = items.Min(x => x.code);
            print(minCode);
        }

        // Sum : �հ�
        {
            int sum = items.Sum(x => x.code);
            print(sum);
        }
    }
}


public class Item : System.IEquatable<Item>
{
    public int code;
    public string name;

    public Item(int code, string name)
    {
        this.code = code;
        this.name = name;
    }

    public void Print()
    {
        Debug.Log($"code : {code}, name : {name}");
    }

    public bool Equals(Item other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (ReferenceEquals(this, other)) return true;

        return code.Equals(other.code) && name.Equals(other.name);
    }

    public override int GetHashCode()
    {
        int hashItemName = name == null ? 0 : name.GetHashCode();
        int hashItemCode = code.GetHashCode();

        return hashItemName ^ hashItemCode;
    }
}

class ItemComparer : IEqualityComparer<Item>
{
    public bool Equals(Item x, Item y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            return false;

        return x.code == y.code && x.name == y.name;
    }

    public int GetHashCode(Item item)
    {
        if (ReferenceEquals(item, null)) return 0;
        int hashProductName = item.name == null ? 0 : item.name.GetHashCode();
        int hashProductCode = item.code.GetHashCode();

        return hashProductName ^ hashProductCode;
    }
}