using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveProgramming : MonoBehaviour
{
    //모든것을 객체로 표현하는 프로그래밍 패러다임
    // Start is called before the first frame update
    public class Orc
    {
        public int ATK;
        public string Name;

        ~Orc()
        {

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
    }
}
