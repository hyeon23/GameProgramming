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

        //����ȯ ��� (), is, as
        if(orc is Monster) // orc is Monster : orc ��ü�� Monster �ڷ������� ��ȯ �����ϳ�?
        {
            monster = (Monster)orc;
            monster.Grr();
        }

        monster = orc as Monster;

        // as: ()�� ����� ���� = (Monster)orc
        //as�� ����ȯ�� �� �ִ��� �˻� ��, �� �� ������ ����ȯ ����, �� �� ���ٸ� null�� �������ش�. = as ����ϴ°� ����.
        //�� Ÿ�� = �Ұ�ȣ ����ȯ / ���� Ÿ�� as ���

        //�Ͻ��� ����ȯ�� ����
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
