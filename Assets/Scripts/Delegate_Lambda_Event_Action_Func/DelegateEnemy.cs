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
    //4. ���� ȿ���� �߰�
    //5. �� ���� ����
    //...

    IEnumerator CoDie()
    {
        isDead = true;
        anim.SetInteger("Stat", 2); // ���

        //���� �׾��� ��,
        DelegateUIManager.instance.AddScore(transform.position);//���ھ� ����
        DelegateItemManager.instance.DropItem(transform.position);//������ ���
        DelegateParticle.instance.PlayDieParticle(transform.position);//��ƼŬ ���
        //���� ȿ���� �߰�
        //�� ���� ����
        //...
        //�׾��� �� ȿ���� �þ��, CoDie �ڵ尡 ��� �������.
        //���: �̱��� Ŭ������ �������� Ŀ��(�ϳ��� �ٲ�� ���� ������ �ް� ��)

        //Delegate ��ȯ
        dieDelegate(transform.position);

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
