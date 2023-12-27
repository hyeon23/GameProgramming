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

        
    }
    //이동 기능
    public void Move()
    {

    }
    //공격 기능
    public void Attack()
    {

    }
    //사망 기능
    public void Dead()
    {

    }
}

class Ork : Monster
{

}

class Zombie: Monster
{

}

