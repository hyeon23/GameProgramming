using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveProgramming : MonoBehaviour
{
    //��ü���� ���α׷���: ������ ��ü�� ǥ���ϴ� ���α׷��� �з�����
    // Start is called before the first frame update
    public class Orc
    {
        public int ATK;
        public string Name;

        //������
        ~Orc()
        {
            //C#���� �����ڴ� �������÷��Ͱ� ���� �۵����� �𸣱� ������ ���� ������� �ʴ� ���� ��õ
        }

        public void Attack()
        {
            Debug.Log(Name + " ��" + ATK + "�� �������� �־����ϴ�.");
        }
    }

    private void Start()
    {
        Orc zozo = new Orc();
        zozo.ATK = 10;
        zozo.Name = "zozo";
        zozo.Attack();

        //����Ƽ���� MonoBehaviour�� ��ӹ޴� ����, ���� ������Ʈ�� ��ũ��Ʈ�� ���� ��, ��üȭ
        //����, MonoBehaviour�� ��ӹ޴� Ŭ���������� new Ű���带 ����� �� ����.
        //ObjectiveProgramming objp = new ObjectiveProgramming();
    }

    
}
