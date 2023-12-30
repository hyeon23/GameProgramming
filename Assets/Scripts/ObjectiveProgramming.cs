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
        //Ŭ������ û����(���赵)�� �ƴ� �ν��Ͻ�(������� ��ü)�� ������ �����ϱ� ������, ���� �ٸ� ���� ���� �� �ִ�.
    }

    //��ü������ Ư¡: �߻�ȭ, ĸ��ȭ, ���, ������

    //��ü���� : 1. �߻�ȭ
    /*
     * ���� Ŭ�������� �������� ��ҵ��� ������ ���ʿ��� �κе��� �����ϰ� ��ü�� �Ӽ� �� �߿��� �Ϳ��� ������ �ξ� ����ȭ(���� : �밭 �߸��� ��) �ϴ� ��,���� Ŭ������ ����� ���� ��
     * Ŭ���� = û���� = ��ü�� ����� ���� ���赵
     */

    //��ü���� : 2. ĸ��ȭ
    /*
     * ��ü �ۿ��� �� �ʿ䰡 ���� ���� ���(����)�� ����� ��
     * ���� ����: �ܺο��� ��� ������ ���� �������� ���ϰ� ����� ��
     * ���� ������ private public protected internal internal protected
     * 
     */

    //��Ģ: Ư���� ������ ������, �ʵ带 ���� public���� �������� �ʴ´�.
    //������ �ʿ��� ���, ������/������ �޼ҵ带 ����� �ܺο��� �����ϴ� ��θ� �����.


    //Get Set Property
    /*
     * public���� ����� Property�� ���� ������/�������� ������ ���� ���� ����
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

        //Get/Set Property2(�ڵ� ���� Property)
        public int Num2 { get; set; }

        //������ �޼ҵ�(Get)
        public int GetNum()
        {
            return num;
        }
        //������ �޼ҵ�(Set)
        public void SetNum(int value)
        {
        }
    }

    //[]: Arrtibute: ��ǻ�Ͱ� �д� �ּ�
    [HideInInspector]//Inspector â�� ǥ�⸦ �����.
    [SerializeField]//public�� �ƴ� ������ Inspector â�� ǥ��ȴ�.
    [System.Serializable]//�ش� ���� Ÿ�� ��ü�� Inspector â�� ǥ��ȴ�.
    //etc...
    [field: SerializeField]
    public int NumProperty { get; set; }


    //����ȭ(Serialization): �����͸� byte �迭�� ��ȯ�ϴ� ���� -> ���� ���� or ��Ʈ��ũ ���� �� �̿�
    //�� ����ȭ: byte �迭�� �����ͷ� ��ȯ�ϴ� ����

    //������Ƽ, �Լ� ���� ����ȭ �Ұ�
    //�ڵ����� ������Ƽ�� ���� [field:SerializeField]�� ���� ��, ����ȭ ���

}
