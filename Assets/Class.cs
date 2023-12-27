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
    //대기 기능
    public void Idle()
    {
        //플레이어를 찾고, 플레이어가 없으면, 몬스터가 second 초 만큼 대기
        int second = 3;
        Debug.Log("Idle");
    }
    //이동 기능
    public void Move()
    {
        Debug.Log("Move");
    }
    //공격 기능
    public void Attack()
    {
        Debug.Log("Attack");
    }
    //사망 기능
    public void Dead()
    {
        Debug.Log("Dead");
    }
}
class Orc : Monster
{
    /*몬스터 기능*/
    public void Idle()
    {
        //base를 통해 부모 클래스 접근 가능
        //Monster(부모)의 Idle을 그대로 사용하겠단 의미
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
    //오크 스킬 기능

    //오크 고유 스킬
}
class Zombie: Monster
{
    /*몬스터 기능*/
    //좀비 스킬 기능
    //좀비 고유 스킬
}

class NPC
{
    //대기 기능
    public void Idle()
    {
        Debug.Log("Idle");
    }
    //퀘스트 기능
    public void Quest()
    {
        Debug.Log("Quest");
    }
    //거래 기능
    public void Deal()
    {
        Debug.Log("Deal");
    }
    //대화 기능
    public void Dialogue()
    {
        Debug.Log("Dialogue");
    }
}
class OrcNPC : NPC
{
    /*NPC 기능*/
}