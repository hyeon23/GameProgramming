using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateEnemy : MonoBehaviour
{
    [SerializeField] Animator anim;

    int hp = 2;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetInteger("Stat", 0); // 대기
    }

    public void OnDamaged()
    {
        StartCoroutine(CoOnDamaged());
    }

    IEnumerator CoOnDamaged()
    {
        anim.SetInteger("Stat", 1); // 피격
        hp--;
        yield return new WaitForSeconds(0.5f);

        if(hp <= 0 && !isDead)
        {
            StartCoroutine(CoDie());
        }
        else
        {
            anim.SetInteger("Stat", 0); // 대기
        }
    }

    //적이 죽을 때
    //1. 아이템 드롭
    //2. 파티클 재생
    //3. 스코어 증가
    IEnumerator CoDie()
    {
        isDead = true;
        anim.SetInteger("Stat", 2); // 사망
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
