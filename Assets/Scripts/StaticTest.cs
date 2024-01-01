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
        //Monster.score2�� ���� ���� �ʵ带 ���� ���� Heap ������ ���� �޸� �Ҵ�(C#�� ���)
        //C���� �����ϴ� ���� �޸𸮿� �ö���ִ´�(���� �ٸ�)

        //static Ư¡
        /*
         * 1. Ŭ���� ��ü�� �ҼӵǹǷ� �� �Ѱ��� ����
         * 2. �޸𸮿� �����Ǿ� ����
         * 3. Ŭ���� ���� ���� �����ϰ�, ���������� ��� ����
         * 4. �̱����� static���� ����
         */

        Debug.Log("monster1 score: " + Monster.score2);
        Debug.Log("monster2 score: " + Monster.score2);
        Debug.Log("monster3 score: " + Monster.score2);
    }

    //�̱��� ����
    //�̱��� Ŭ����: Ŭ������ �ν��Ͻ��� �� �ϳ� �����ϴ� ���� �����ϴ� Ŭ����
    public class Manager
    {
        //��ü�� static ������ ����
        public static Manager instance = new Manager();

        private Manager() { }//�����ڸ� private�� ���� -> ��ü ������ ����
    }

    public class Util
    {
        static List<GameObject> obj = new List<GameObject>(); // ���� �ʵ�

        public int num;

        public static void FindObj(string _name)//���� �޼ҵ�
        {
            GameObject go = GameObject.Find(_name);
            obj.Add(go);
        }

        public static GameObject ReturnObj(string _name)//���� �޼ҵ�
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

        //static �޼ҵ� ���ο����� �ش� ���� �޼ҵ尡 ���� Ŭ����(��ü)�� static�� �ƴ� ���(�Լ�, ����)�� ����� �� ����.
        //Ŭ���� �Ҽ��̱� ������ ��ü�� �Ҽ� ����� ������ �� ���ٴ� �ǹ�
        //static�� Ŭ���� ������ �����ϰ�, ���������� ���ٵȴ�.

        public void TTTest()
        {

        }
        public static void RemoveObj(string _name)//���� �޼ҵ�
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
