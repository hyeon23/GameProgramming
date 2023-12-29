using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeChangeStudy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Orc orc = new Orc();
        Monster monster = new Monster();
        monster.Grr();
        orc = (Orc)monster;
        orc.Grr();

        //형변환 방법 (), is, as
        if(orc is Monster) // orc is Monster : orc 객체가 Monster 자료형으로 변환 가능하냐?
        {
            monster = (Monster)orc;
            monster.Grr();
        }

        monster = orc as Monster;

        // as: ()와 기능이 유사 = (Monster)orc
        //as는 형변환할 수 있는지 검사 후, 할 수 있으면 형변환 수행, 항 수 없다면 null을 대입해준다. = as 사용하는게 좋다.
        //값 타입 = 소괄호 형번환 / 참조 타입 as 사용

        //암시적 형변환도 가능
        monster = orc;

        if (monster != null)
        {
            monster.Grr();
        }
    }

    class Monster
    {
        public void Grr()
        {
            Debug.Log("Grr...");
        }
    }
    class Orc : Monster
    {

    }
    class Troll : Monster
    {

    }
}
