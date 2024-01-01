using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTest : MonoBehaviour
{
    //Static(정적): 필드나 메소드가 인스턴스가 아닌 클래스 자체에 소속되도록 함
    //
    // Start is called before the first frame update
    
    public class Monster
    {
        public int score1 = 0;
        public static int score2 = 0;
        public void Dead()
        {
            score1++;
            score2++;
        }
    }

    private void Start()
    {

        Monster monster1 = new Monster();
        Monster monster2 = new Monster();
        Monster monster3 = new Monster();

        monster1.Dead();
        monster2.Dead();
        monster3.Dead();

        Debug.Log("monster1 score: " + monster1.score1);
        Debug.Log("monster2 score: " + monster2.score1);
        Debug.Log("monster3 score: " + monster3.score1);

        //객체를 통한 접근이 아닌 클래스 명을 통한 접근을 수행
        Debug.Log("monster1 score: " + Monster.score2);
        Debug.Log("monster2 score: " + Monster.score2);
        Debug.Log("monster3 score: " + Monster.score2);
    }
}
