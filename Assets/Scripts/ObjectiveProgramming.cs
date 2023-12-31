using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveProgramming : MonoBehaviour
{
    //��ü���� ���α׷���: ������ ��ü�� ǥ���ϴ� ���α׷��� �з�����
    // Start is called before the first frame update
    //public class Orc
    //{
    //    public int ATK;
    //    public string Name;

    //    //������
    //    ~Orc()
    //    {
    //        //C#���� �����ڴ� �������÷��Ͱ� ���� �۵����� �𸣱� ������ ���� ������� �ʴ� ���� ��õ
    //    }

    //    public void Attack()
    //    {
    //        Debug.Log(Name + " ��" + ATK + "�� �������� �־����ϴ�.");
    //    }
    //}



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
    //[System.Serializable]//�ش� ���� Ÿ�� ��ü�� Inspector â�� ǥ��ȴ�.
    //etc...
    //[field: SerializeField]
    public int NumProperty { get; set; }


    //����ȭ(Serialization): �����͸� byte �迭�� ��ȯ�ϴ� ���� -> ���� ���� or ��Ʈ��ũ ���� �� �̿�
    //�� ����ȭ: byte �迭�� �����ͷ� ��ȯ�ϴ� ����

    //������Ƽ, �Լ� ���� ����ȭ �Ұ�
    //�ڵ����� ������Ƽ�� ���� [field:SerializeField]�� ���� ��, ����ȭ ���


    //private void Start()
    //{
    //    Orc zozo = new Orc();
    //    zozo.ATK = 10;
    //    zozo.Name = "zozo";
    //    zozo.Attack();
    //    //����Ƽ���� MonoBehaviour�� ��ӹ޴� ����, ���� ������Ʈ�� ��ũ��Ʈ�� ���� ��, ��üȭ
    //    //����, MonoBehaviour�� ��ӹ޴� Ŭ���������� new Ű���带 ����� �� ����.
    //    //ObjectiveProgramming objp = new ObjectiveProgramming();
    //    //Ŭ������ û����(���赵)�� �ƴ� �ν��Ͻ�(������� ��ü)�� ������ �����ϱ� ������, ���� �ٸ� ���� ���� �� �ִ�.
    //}
    /*
     * ��ü����: 3. ������: ��ü�� ������ ���¸� ���� �� ������ �ǹ�
     * 1. ��ӹ޾� ������� �Ļ� Ŭ������ ���� �������� ����
     * 
     */

    public abstract class Monster
    {
        //virtual Ű����
        //- �θ� Ŭ�������� virtual �Լ��� �����ص� �� �ڽĿ��� override(������)���� �ʾƵ� �ȴ�.
        //- �θ� Ŭ�������� virtual �Լ��� ���� ��, �ڽĿ��� override ����
        public abstract void Attack();

        public virtual void OnDamaged() { }
    }
    public class Orc : Monster
    {
        public override void Attack()
        {
            Debug.Log("Orc Attack");
        }

        public override void OnDamaged()
        {
            Debug.Log("OrcOnDamaged");
        }
    }

    public class Ogre : Monster
    {
        public override void Attack()
        {
            Debug.Log("Orc Attack");
        }

        public override void OnDamaged()
        {
            Debug.Log("OgreOnDamaged");
        }
    }


    public class Player
    {
        //�������� �����ϴ� ����: �θ� Ÿ������ �ڽ� Ÿ���� �޾�, �������� ����
        public void Attack(Monster monster)
        {
            monster.OnDamaged();
        }
    }

    private void Start()
    {
        //Orc orc = new Orc();
        //orc.Attack();

        Monster orc = new Orc();//��ü ������ �´� �Լ��� ȣ��
        Monster ogre = new Ogre();//��ü ������ �´� �Լ��� ȣ��

        List<Monster> monsters = new List<Monster>();

        monsters.Add(orc);
        monsters.Add(ogre);

        Player player = new Player();

        foreach (var mob in monsters)
        {
            player.Attack(mob);
            mob.Attack();
            mob.OnDamaged();
        }
    }

    //��ü���� ���α׷��� 4. ��� = virtual + abstarct + interface
    /*
     * ��� ������ ��Ĵ�� ����ϸ� �ȴ�.
     * ���� ��� �Ұ���(C#): C#���� ���� ��� ����� ���Ƶξ���
     */

    //public class OrcOgre : Orc, Ogre
    //{
    //    /*
    //     * ������ ���̾Ƹ��: ���� ��� ���� or ��� �Լ��� �����ϱ� ������ ���� �߻�
    //    */
    //}

    //virtual vs abstract
    /*
     * virtual(����): �ڽĿ��� �������� �ʾƵ� ��
     * abstract(�߻�): �ڽ� Ŭ������ �޼ҵ忡�� �ݵ�� �����ؾ� �� + �ݵ�� �߻� Ŭ�������� �� -> abstract Ŭ���� ���� + �߻� Ŭ������ ��ü(�ν��Ͻ�)�� ���� �Ұ�
     */

    //�߻� Ŭ����
    public abstract class AbstarctClass{
        public abstract void Abstract();
    }

    //�������̽�: ���α׷��ֻ� ��� or ���
    //�̺�Ʈ, �ε���, ������Ƽ, �޼ҵ�
    //�߻�Ŭ����ó�� �Լ��� ����θ� �ۼ�
    //�߻�Ŭ����ó�� ��ü(�ν��Ͻ�) ������ �Ұ���
    //����ο� �ۼ��� �Լ��� ��ӹ��� Ŭ�������� �ݵ�� �����ؾ� �Ѵ�.
    //�������̽��� ���� ����� �����ϴ�.
    //I�� �տ� ���̴� ���� ����
    public interface IAttack
    {
        public void Attack();
    }

    public interface IMove
    {
        public void Move();
    }

    public class A : IAttack, IMove
    {
        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
