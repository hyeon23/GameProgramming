using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveProgramming : MonoBehaviour
{
    //객체지향 프로그래밍: 모든것을 객체로 표현하는 프로그래밍 패러다임
    // Start is called before the first frame update
    public class Orc
    {
        public int ATK;
        public string Name;

        //종료자
        ~Orc()
        {
            //C#에서 종료자는 가비지컬렉터가 언제 작동할지 모르기 때문에 굳이 사용하지 않는 것을 추천
        }

        public void Attack()
        {
            Debug.Log(Name + " 가" + ATK + "의 데미지를 주었습니다.");
        }
    }

    private void Start()
    {
        Orc zozo = new Orc();
        zozo.ATK = 10;
        zozo.Name = "zozo";
        zozo.Attack();

        //유니티에서 MonoBehaviour를 상속받는 순간, 게임 오브젝트에 스크립트를 부착 시, 객체화
        //따라서, MonoBehaviour를 상속받는 클래스내에선 new 키워드를 사용할 수 없다.
        //ObjectiveProgramming objp = new ObjectiveProgramming();
        //클래스가 청사진(설계도)이 아닌 인스턴스(만들어진 객체)의 역할을 수행하기 때문에, 각자 다른 값을 가질 수 있다.
    }

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
    [System.Serializable]//해당 참조 타입 객체가 Inspector 창에 표기된다.
    //etc...
    [field: SerializeField]
    public int NumProperty { get; set; }


    //직렬화(Serialization): 데이터를 byte 배열로 변환하는 과정 -> 게임 저장 or 네트워크 연결 시 이용
    //역 직렬화: byte 배열을 데이터로 변환하는 과정

    //프로퍼티, 함수 등은 직렬화 불가
    //자동구현 프로퍼티에 한해 [field:SerializeField]를 선언 시, 직렬화 허용

}
