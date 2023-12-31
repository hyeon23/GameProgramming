using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveProgramming : MonoBehaviour
{
    //객체지향 프로그래밍: 모든것을 객체로 표현하는 프로그래밍 패러다임
    // Start is called before the first frame update
    //public class Orc
    //{
    //    public int ATK;
    //    public string Name;

    //    //종료자
    //    ~Orc()
    //    {
    //        //C#에서 종료자는 가비지컬렉터가 언제 작동할지 모르기 때문에 굳이 사용하지 않는 것을 추천
    //    }

    //    public void Attack()
    //    {
    //        Debug.Log(Name + " 가" + ATK + "의 데미지를 주었습니다.");
    //    }
    //}



    //객체지향의 특징: 추상화, 캡슐화, 상속, 다형성

    //객체지향 : 1. 추상화
    /*
     * 기존 클래스들의 공통적인 요소들을 추출해 불필요한 부분들을 생략하고 객체의 속성 중 중요한 것에만 중점을 두어 개략화(사전 : 대강 추리는 일) 하는 것,상위 클래스를 만들어 내는 것
     * 클래스 = 청사진 = 객체를 만들기 위한 설계도
     */

    //객체지향 : 2. 캡슐화
    /*
     * 객체 밖에서 알 필요가 없는 내부 멤버(변수)를 숨기는 것
     * 정보 은닉: 외부에서 멤버 변수를 직접 접근하지 못하게 만드는 것
     * 접근 제한자 private public protected internal internal protected
     * 
     */

    //원칙: 특별한 이유가 없으면, 필드를 절대 public으로 선언하지 않는다.
    //접근이 필요한 경우, 접근자/설정자 메소드를 만들어 외부에서 접근하는 경로를 만든다.


    //Get Set Property
    /*
     * public으로 선언된 Property를 통해 접근자/설정자의 생성을 쉽게 생성 가능
     */

    public class Capsule
    {
        int num;

        //Get/Set Property1
        public int Num1
        {
            get { return num; }
            set { num = value; }
        }

        //Get/Set Property2(자동 구현 Property)
        public int Num2 { get; set; }

        //접근자 메소드(Get)
        public int GetNum()
        {
            return num;
        }
        //설정자 메소드(Set)
        public void SetNum(int value)
        {
        }
    }

    //[]: Arrtibute: 컴퓨터가 읽는 주석
    [HideInInspector]//Inspector 창에 표기를 숨긴다.
    [SerializeField]//public이 아닌 변수가 Inspector 창에 표기된다.
    //[System.Serializable]//해당 참조 타입 객체가 Inspector 창에 표기된다.
    //etc...
    //[field: SerializeField]
    public int NumProperty { get; set; }


    //직렬화(Serialization): 데이터를 byte 배열로 변환하는 과정 -> 게임 저장 or 네트워크 연결 시 이용
    //역 직렬화: byte 배열을 데이터로 변환하는 과정

    //프로퍼티, 함수 등은 직렬화 불가
    //자동구현 프로퍼티에 한해 [field:SerializeField]를 선언 시, 직렬화 허용


    //private void Start()
    //{
    //    Orc zozo = new Orc();
    //    zozo.ATK = 10;
    //    zozo.Name = "zozo";
    //    zozo.Attack();
    //    //유니티에서 MonoBehaviour를 상속받는 순간, 게임 오브젝트에 스크립트를 부착 시, 객체화
    //    //따라서, MonoBehaviour를 상속받는 클래스내에선 new 키워드를 사용할 수 없다.
    //    //ObjectiveProgramming objp = new ObjectiveProgramming();
    //    //클래스가 청사진(설계도)이 아닌 인스턴스(만들어진 객체)의 역할을 수행하기 때문에, 각자 다른 값을 가질 수 있다.
    //}
    /*
     * 객체지향: 3. 다형성: 객체가 다향한 형태를 가질 수 있음을 의미
     * 1. 상속받아 만들어진 파생 클래스를 통해 다형성을 구현
     * 
     */

    public abstract class Monster
    {
        //virtual 키워드
        //- 부모 클래스에서 virtual 함수를 선언해도 꼭 자식에서 override(재정의)하지 않아도 된다.
        //- 부모 클래스에서 virtual 함수를 선언 시, 자식에서 override 가능
        public abstract void Attack();

        public virtual void OnDamaged() { }
    }
    public class Orc : Monster
    {
        public override void Attack()
        {
            Debug.Log("Orc Attack");
        }

        public override void OnDamaged()
        {
            Debug.Log("OrcOnDamaged");
        }
    }

    public class Ogre : Monster
    {
        public override void Attack()
        {
            Debug.Log("Orc Attack");
        }

        public override void OnDamaged()
        {
            Debug.Log("OgreOnDamaged");
        }
    }


    public class Player
    {
        //다형성을 실현하는 과정: 부모 타입으로 자식 타입을 받아, 다형성을 구현
        public void Attack(Monster monster)
        {
            monster.OnDamaged();
        }
    }

    private void Start()
    {
        //Orc orc = new Orc();
        //orc.Attack();

        Monster orc = new Orc();//객체 종류에 맞는 함수가 호출
        Monster ogre = new Ogre();//객체 종류에 맞는 함수가 호출

        List<Monster> monsters = new List<Monster>();

        monsters.Add(orc);
        monsters.Add(ogre);

        Player player = new Player();

        foreach (var mob in monsters)
        {
            player.Attack(mob);
            mob.Attack();
            mob.OnDamaged();
        }
    }

    //객체지향 프로그래밍 4. 상속 = virtual + abstarct + interface
    /*
     * 계속 나오는 방식대로 사용하면 된다.
     * 다중 상속 불가능(C#): C#에선 다중 상속 방식을 막아두었음
     */

    //public class OrcOgre : Orc, Ogre
    //{
    //    /*
    //     * 죽음의 다이아몬드: 같은 멤버 변수 or 멤버 함수가 존재하기 때문에 에러 발생
    //    */
    //}

    //virtual vs abstract
    /*
     * virtual(가상): 자식에서 구현하지 않아도 됨
     * abstract(추상): 자식 클래스의 메소드에서 반드시 구현해야 함 + 반드시 추상 클래스여야 함 -> abstract 클래스 선언 + 추상 클래스는 객체(인스턴스)를 생성 불가
     */

    //추상 클래스
    public abstract class AbstarctClass{
        public abstract void Abstract();
    }

    //인터페이스: 프로그래밍상 계약 or 약속
    //이벤트, 인덱서, 프로퍼티, 메소드
    //추상클래스처럼 함수의 선언부만 작성
    //추상클래스처럼 객체(인스턴스) 생성이 불가능
    //선언부에 작성된 함수는 상속받은 클래스에서 반드시 구현해야 한다.
    //인터페이스는 다중 상속이 가능하다.
    //I를 앞에 붙이는 것이 관례
    public interface IAttack
    {
        public void Attack();
    }

    public interface IMove
    {
        public void Move();
    }

    public class A : IAttack, IMove
    {
        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
