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
        new School(){ name = "A반", scores = new int[] { 70, 60, 30, 80} },
        new School(){ name = "A반", scores = new int[] { 20, 65, 35, 85} }
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
        // LINQ 식(10가지 정도)과 LINQ 함수(50가지 정도)의 기본형
        {
            _items = from item in items
                     where item.code > 1
                     orderby item.code
                     select item;

            _items = items.Where(x => x.code > 1).OrderBy(x => x.code);
        }



        // ## LINQ 식

        // from : 데이터 가져오기
        {
            _items = from item in items
                     select item;

            foreach (var _item in _items)
                _item.Print();
        }

        // select : 데이터 선택하기
        {
            IEnumerable<int> codes = from item in items
                                     select item.code;

            foreach (var code in codes)
                print(code);
        }

        // where : 데이터 찾기
        {
            _items = from item in items
                     where item.code > 1
                     select item;
        }

        // orderby : 데이터 정렬, 기본값 오름차순, ascending 오름차순, descending 내림차순
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

        // IEnumerable형식을 배열과 리스트로 바꿀 수 있다
        {
            int[] codes = (from item in items
                           select item.code).ToArray();

            List<int> codes2 = (from item in items
                                select item.code).ToList();
        }

        // from을 중복해 쓸 수 있다. select new { } 로 익명형식 만들기
        {
            var _schools = from classes in schools
                           from scores in classes.scores
                           where scores < 50
                           select new { name = classes.name, lowScore = scores };

            foreach (var _school in _schools)
                print(_school);
        }

        // group : 데이터 분류하기
        {
            var _itemGroups = from item in items
                              group item by item.code > 2 into g
                              select new { GroupKey = g.Key, GroupItem = g };

            foreach (var _itemGroup in _itemGroups)
            {
                print($"2보다 큼? : {_itemGroup.GroupKey}");
                foreach (Item item in _itemGroup.GroupItem)
                    item.Print();
            }
        }

        // 내부join : from을 기준하여 존재하는 부분만 합하기
        {
            var itemJoins = from item in items
                            join user in users on item.code equals user.userCode
                            select new { Code = item.code, UserName = user.userName, ItemName = item.name };

            foreach (var itemJoin in itemJoins)
                print(itemJoin);
        }

        // 외부join : from을 기준하여 모든 부분을 합하기, DefaultIfEmpty로 빈 기본값 채운다
        {
            var itemJoins = from item in items
                            join user in users on item.code equals user.userCode into excepts
                            from user in excepts.DefaultIfEmpty(new User() { userName = "NONE" })
                            select new { Code = item.code, UserName = user.userName, ItemName = item.name };

            foreach (var itemJoin in itemJoins)
                print(itemJoin);
        }



        // ## LINQ 함수



        // # 정렬

        // OrderBy : 오름차순 정렬
        _items = items.OrderBy(x => x.code);

        // OrderByDescending : 내림차순 정렬
        _items = items.OrderByDescending(x => x.code);

        // ThenBy : 정렬된 것 뒤에 오름차순으로 2차 정렬
        _items = items5.OrderBy(x => x.code).ThenBy(x => x.name);

        // ThenByDescending : 정렬된 것 뒤에 내림차순으로 2차 정렬
        _items = items5.OrderBy(x => x.code).ThenByDescending(x => x.name);

        // Reverse : 순서 뒤집기
        _items = items.Reverse();



        // # 집합

        // Distinct : 중복 제거, Item : System.IEquatable<Item> 인터페이스 구현
        _items = items4.Distinct();

        // Except : 차집합 items - items2
        _items = items.Except(items2);

        // Intersect : 교집합 items ∩ items2
        _items = items.Intersect(items2);

        // Union : 합집합 items ∪ items2
        _items = items.Union(items2);



        // # 필터링

        // Where : 조건이 true인 값을 선택
        _items = items.Where(x => x.code > 1);



        // # 수량연산

        // All : 모두 조건을 만족시켜야 true
        {
            bool b = items.All(x => x.code > 0);
            print(b);
        }

        // Any : 하나라도 true라면 true
        {
            bool b = items.Any(x => x.code > 3);
            print(b);
        }

        // Contains : 포함여부, ItemComparer : IEqualityComparer<Item> 클래스 구현
        {
            bool b = items.Contains(new Item(3, "banana"), new ItemComparer());
            print(b);
        }



        // # 데이터 추출

        // Select : 값을 추출해 IEnumerable형식 만듦
        {
            IEnumerable<int> codes = items.Select(x => x.code);
            foreach (int code in codes)
                print(code);
            var _customItems = items.Select(x => new { Name = x.name, CodeAdd = x.code + 1 });
            foreach (var _customItem in _customItems)
                print(_customItem);
        }

        // SelectMany : 둘의 모든 조합을 만듦
        // {(10,cat), (10,dog), (10,donkey), (20,cat), (20,dog), (20,donkey)}
        {
            int[] number = new int[] { 10, 20 };
            string[] animals = new string[] { "cat", "dog", "donkey" };
            var mix = number.SelectMany(num => animals, (n, a) => new { n, a });
            foreach (var a in mix)
                print(a);
        }



        // # 데이터 분할

        // Skip : 건너뛰고 인덱스부터 시작
        _items = items.Skip(2);

        // SkipWhile : 순서대로 정렬됐을 때, true일 동안 스킵
        // {1, 2, 3, 4}에서 3보다 작을 동안을 스킵, 3, 4만 나옴
        _items = items.OrderBy(x => x.code).SkipWhile(x => x.code < 3);

        // Take : 앞에서부터 개수만큼 가져오기
        _items = items.Take(2);

        // TakeWhile : 순서대로 정렬됐을 때, true일 동안 가져오기
        // {1, 2, 3, 4}에서 3보다 작을 동안 가져오기, 1, 2만 나옴
        _items = items.OrderBy(x => x.code).TakeWhile(x => x.code < 3);



        // # 데이터 결합

        // 내부Join : 존재하는 부분만 합하기, 외부join은 LINQ식을 참고
        {
            var itemJoins = items.Join(users, item => item.code, user => user.userCode,
                        (item, user) => new { Code = item.code, UserName = user.userName, ItemName = item.name });

            foreach (var itemJoin in itemJoins)
                print(itemJoin);
        }

        // GroupJoin : group + join 그룹을 지으면서 합함
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



        // # 데이터 그룹화

        // GroupBy : 그룹으로 묶기
        {
            var itemGroups = items.GroupBy(item => item.code > 2, item => item,
                (key, item) => new { Key = key, Item = item });

            foreach (var itemGroup in itemGroups)
            {
                print($"2보다 큼? : {itemGroup.Key}");
                foreach (var item in itemGroup.Item)
                    item.Print();
            }
        }

        // ToLookUp : 키를 자동으로 생성해주는 그룹
        {
            var itemGroups = items.ToLookup(item => item.code > 2, item => item);

            foreach (var itemGroup in itemGroups)
            {
                print($"2보다 큼? : {itemGroup.Key}");
                foreach (var item in itemGroup)
                    item.Print();
            }
        }



        // # 생성

        // DefaultIfEmpty : 빈 컬렉션은 기본 하나를 생성
        {
            List<Item> itemEmpty = new List<Item>();
            Item defaultItem = new Item(-1, "NONE");

            foreach (Item item in itemEmpty.DefaultIfEmpty(defaultItem))
                item.Print();
        }

        // Empty : 빈 IEnumerable를 생성
        {
            IEnumerable<Item> emptyItem = Enumerable.Empty<Item>();
            print(emptyItem.Count());
        }

        // Range : 정수 범위의 숫자들을 생성, 시작 숫자부터 개수까지
        {
            IEnumerable<int> ranges = Enumerable.Range(3, 10).Select(x => x * x);

            foreach (var range in ranges)
                print(range);
        }

        // Repeat : 반복하여 생성
        {
            IEnumerable<string> strings = Enumerable.Repeat("Hi", 10);

            foreach (var str in strings)
                print(str);
        }



        // # 동등 여부 평가

        // SequenceEqual : 두 개가 일치하는지
        {
            bool b = items.SequenceEqual(items3);
            print(b);
        }



        // # 요소 접근

        // ElementAt : 해당 인덱스를 가져옴
        {
            Item _item = items.ElementAt(3);
            _item.Print();
        }

        // ElementAtOrDefault : 인덱스를 가져올 수 없으면 null
        {
            Item _item = items.ElementAtOrDefault(3);
            _item.Print();
        }

        // First : 첫번째를 가져옴, 조건에 맞는 첫번째를 가져옴
        {
            Item _item = items.First();
            _item = items.First(x => x.code > 2);
            _item.Print();
        }

        // FirstOrDefault : 첫번째를 가져옴, 조건에 맞는 첫번째를 가져옴, 인덱스를 가져올 수 없으면 null
        {
            Item _item = items.FirstOrDefault();
            _item = items.FirstOrDefault(x => x.code > 1);
            _item.Print();
        }

        // Last : 마지막을 가져옴, 조건에 맞는 마지막을 가져옴
        {
            Item _item = items.Last();
            _item = items.Last(x => x.code > 2);
            _item.Print();
        }

        // LastOrDefault : 마지막을 가져옴, 조건에 맞는 마지막을 가져옴, 인덱스를 가져올 수 없으면 null
        {
            Item _item = items.LastOrDefault();
            _item = items.LastOrDefault(x => x.code < 4);
            _item.Print();
        }

        // Single : 단 하나만 이 조건을 만족시켜야 InvalidOperationException에러가 안 뜸
        {
            Item _item = items.Single(x => x.code > 3);
            _item.Print();
        }

        // SingleOrDefault : 단 하나만 이 조건을 만족시켜야 InvalidOperationException에러가 안 뜸
        // 인덱스를 가져올 수 없으면 null
        {
            Item _item = items.SingleOrDefault(x => x.code > 3);
            _item.Print();
        }



        // # 형식 변환

        // AsEnumerable : IEnumerable 형식으로 변환
        {
            IEnumerable<Item> _items = items.AsEnumerable();
        }

        // AsQueryable : IQueryable 형식으로 변환, LINQ를 SQL과 연동하는데 쓰임
        // IEnumerable은 인터페이스가 IEnumerable뿐이지만, IQueryable이 IEnumerable을 포함함
        {
            IQueryable<Item> _items = items.AsQueryable();
        }

        // Cast : ArrayList에서 그 타입만 추출, 실패시 InvalidCastException 에러뜸
        {
            //ArrayList itemArray = new ArrayList { 1, "2", 3, 4, 5 };
            ArrayList itemArray = new ArrayList { 1, 2, 3, 4, 5 };
            IEnumerable<int> _items = itemArray.Cast<int>();
            foreach (var _item in _items) print(_item);
        }

        // OfType : ArrayList에서 그 타입만 추출, 실패는 건너뛰고 2와 4가 나옴
        {
            ArrayList itemArray = new ArrayList { 1, "2", 3, "4", 5 };
            IEnumerable<string> _items = itemArray.OfType<string>();
            foreach (string _item in _items) print(_item);
        }

        // ToArray : 배열로 반환
        {
            List<string> strs = new List<string>() { "zz", "ss" };
            string[] _strs = strs.ToArray();
        }

        // ToList : 리스트로 반환
        {
            List<Item> itemList = items.ToList();
        }

        // ToDictionary : 지정된 키로 딕셔너리를 만듦
        {
            Dictionary<int, Item> itemDic = items.ToDictionary(x => x.code);
            foreach (var keyValue in itemDic)
            {
                print($"키 : {keyValue.Key}");
                keyValue.Value.Print();
            }
        }

        // ToLookup : 키 값형식으로 만듦
        {
            ILookup<int, string> lookup = items.ToLookup(x => x.code, y => y.name);
            foreach (var group in lookup)
            {
                print($"키 : {group.Key}");
                foreach (var g in group)
                    print($"값 : {g}");
            }
        }



        // # 연결

        // Concat : 두 개를 하나로 연결
        {
            IEnumerable<string> strs = items.Select(x => x.name).Concat(items2.Select(x => x.name));

            foreach (var str in strs)
                print(str);
        }



        // # 집계

        // Aggregate : 누적 계산
        {
            int total = items.Aggregate(0, (total, next) => total += next.code);
            print(total);
        }

        // Average : 평균
        {
            double avg = items.Average(x => x.code);
            print(avg);
        }

        // Count : 개수
        {
            int count = items.Count();
            print(count);
        }

        // LongCount : long형식 개수
        {
            long longCount = items.LongCount();
            print(longCount);
        }

        // Max : 최댓값
        {
            int maxCode = items.Max(x => x.code);
            print(maxCode);
        }

        // Min : 최솟값
        {
            int minCode = items.Min(x => x.code);
            print(minCode);
        }

        // Sum : 합계
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