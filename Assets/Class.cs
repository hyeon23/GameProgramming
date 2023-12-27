using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

class Monster
{
    //��� ���
    public void Idle()
    {
        //�÷��̾ ã��, �÷��̾ ������, ���Ͱ� second �� ��ŭ ���
        int second = 3;
        Debug.Log("Idle");
    }
    //�̵� ���
    public void Move()
    {
        Debug.Log("Move");
    }
    //���� ���
    public void Attack()
    {
        Debug.Log("Attack");
    }
    //��� ���
    public void Dead()
    {
        Debug.Log("Dead");
    }
}
class Orc : Monster
{
    /*���� ���*/
    public void Idle()
    {
        //base�� ���� �θ� Ŭ���� ���� ����
        //Monster(�θ�)�� Idle�� �״�� ����ϰڴ� �ǹ�
        base.Idle();
    }
    public void Move()
    {
        base.Move();
    }
    public void Attack()
    {
        base.Attack();
    }

    public void Dead()
    {
        base.Dead();
    }
    //��ũ ��ų ���

    //��ũ ���� ��ų
}
class Zombie: Monster
{
    /*���� ���*/
    //���� ��ų ���
    //���� ���� ��ų
}

class NPC
{
    //��� ���
    public void Idle()
    {
        Debug.Log("Idle");
    }
    //����Ʈ ���
    public void Quest()
    {
        Debug.Log("Quest");
    }
    //�ŷ� ���
    public void Deal()
    {
        Debug.Log("Deal");
    }
    //��ȭ ���
    public void Dialogue()
    {
        Debug.Log("Dialogue");
    }
}
class OrcNPC : NPC
{
    /*NPC ���*/
}