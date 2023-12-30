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
    }

    
}
