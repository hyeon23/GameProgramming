using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTest : MonoBehaviour
{
    //Static(����): �ʵ峪 �޼ҵ尡 �ν��Ͻ��� �ƴ� Ŭ���� ��ü�� �Ҽӵǵ��� ��
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

        //��ü�� ���� ������ �ƴ� Ŭ���� ���� ���� ������ ����
        Debug.Log("monster1 score: " + Monster.score2);
        Debug.Log("monster2 score: " + Monster.score2);
        Debug.Log("monster3 score: " + Monster.score2);
    }
}
