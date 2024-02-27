using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateEnemy : MonoBehaviour
{
    public delegate void DieDelegate(Vector3 pos);

    public DieDelegate dieDelegate;

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
    //4. 죽음 효과음 추가
    //5. 적 동료 생성
    //...

    IEnumerator CoDie()
    {
        isDead = true;
        anim.SetInteger("Stat", 2); // 사망

        //적이 죽었을 때,
        DelegateUIManager.instance.AddScore(transform.position);//스코어 증가
        DelegateItemManager.instance.DropItem(transform.position);//아이템 드랍
        DelegateParticle.instance.PlayDieParticle(transform.position);//파티클 재생
        //죽음 효과음 추가
        //적 동료 생성
        //...
        //죽었을 때 효과가 늘어나면, CoDie 코드가 계속 길어진다.
        //결론: 싱글톤 클래스의 의존성이 커짐(하나가 바뀌면 전부 영향을 받게 됨)

        //Delegate 변환
        dieDelegate(transform.position);

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
