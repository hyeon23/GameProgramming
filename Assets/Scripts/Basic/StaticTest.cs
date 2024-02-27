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
        //Monster.score2와 같이 정적 필드를 쓰는 순간 Heap 영역에 동적 메모리 할당(C#의 경우)
        //C언어는 시작하는 순간 메모리에 올라와있는다(언어마다 다름)

        //static 특징
        /*
         * 1. 클래스 자체에 소속되므로 단 한개만 존재
         * 2. 메모리에 고정되어 있음
         * 3. 클래스 명을 통해 접근하고, 전역적으로 사용 가능
         * 4. 싱글톤을 static으로 구현
         */

        Debug.Log("monster1 score: " + Monster.score2);
        Debug.Log("monster2 score: " + Monster.score2);
        Debug.Log("monster3 score: " + Monster.score2);
    }

    //싱글톤 구현
    //싱글톤 클래스: 클래스의 인스턴스가 단 하나 존재하는 것을 보장하는 클래스
    public class Manager
    {
        //객체를 static 변수로 선언
        public static Manager instance = new Manager();

        private Manager() { }//생성자를 private로 선언 -> 객체 생성을 제한
    }

    public class Util
    {
        static List<GameObject> obj = new List<GameObject>(); // 정적 필드

        public int num;

        public static void FindObj(string _name)//정적 메소드
        {
            GameObject go = GameObject.Find(_name);
            obj.Add(go);
        }

        public static GameObject ReturnObj(string _name)//정적 메소드
        {
            for(int i = 0; i < obj.Count; ++i)
            {
                if (obj[i].name == _name)
                {
                    return obj[i];
                }
            }
            return null;
        }

        //static 메소드 내부에서는 해당 정적 메소드가 속한 클래스(객체)의 static이 아닌 멤버(함수, 변수)를 사용할 수 없다.
        //클래스 소속이기 때문에 객체의 소속 멤버에 접근할 수 없다는 의미
        //static은 클래스 명으로 접근하고, 전역적으로 접근된다.

        public void TTTest()
        {

        }
        public static void RemoveObj(string _name)//정적 메소드
        {
            for (int i = 0; i < obj.Count; ++i)
            {
                if (obj[i].name == _name)
                {
                    obj.Remove(obj[i]);
                }
            }
        }
    }
}
