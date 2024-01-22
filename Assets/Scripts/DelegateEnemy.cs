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
        anim.SetInteger("Stat", 0); // ���
    }

    public void OnDamaged()
    {
        StartCoroutine(CoOnDamaged());
    }

    IEnumerator CoOnDamaged()
    {
        anim.SetInteger("Stat", 1); // �ǰ�
        hp--;
        yield return new WaitForSeconds(0.5f);

        if(hp <= 0 && !isDead)
        {
            StartCoroutine(CoDie());
        }
        else
        {
            anim.SetInteger("Stat", 0); // ���
        }
    }

    //���� ���� ��
    //1. ������ ���
    //2. ��ƼŬ ���
    //3. ���ھ� ����
    IEnumerator CoDie()
    {
        isDead = true;
        anim.SetInteger("Stat", 2); // ���
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
