using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOtween3 : MonoBehaviour
{
    // Start is called before the first frame update
    //Sequence: Tweener�� �ϳ��� �ൿ�� ���� �����ϴ� �ڷ���
    //Sequence�� �濡�� �� �� �ֵ� ���� �������� �ʰ�, �ٸ� Tweener���� �����մϴ�. �׷����� �ִϸ��̼��� �����մϴ�.
    //�ϳ��� �ƴ� ���� Tweener�� �׷����� �������ش�.
    //�ϳ��� Sequence�� �������� Tweener�� �ѹ��� �����ų �� �ִ�.
    Sequence sequence;
    Vector3 targetPos;
    void Start()
    {
        //Sequence �����ڴ� �̷� ������� ����
        sequence = DOTween.Sequence();
        targetPos = new Vector3(0, 0, 0);
        /*
         * Append : ������ �� �ڿ� Ʈ�� �߰�
         * Insert : ������ ���ϴ� Ư�� �ð��� Ʈ�� �߰�(���� �ð� ���� -> ���Ŀ� �ð��� �ٲ�, insert�� ���� �������� �������� �ٴ´�.)
         * Join : ���� �������� ������ Ʈ���� ���ڷ� �Էµ� �������� ����(���� ����)
         * Prepend : ������ �� �տ� Ʈ�� �߰�
         */
        Tween tr1 = transform.DOMove(targetPos, 1.0f).SetEase(Ease.Flash).SetDelay(1.0f).SetLoops(3).OnComplete(()=> Debug.Log("Completed"));
        Tween tr2 = transform.DORotate(targetPos, 1.0f).SetEase(Ease.InBack).SetDelay(1.0f).SetLoops(3).OnComplete(() => Debug.Log("Completed"));
        Tween tr3 = transform.DOScale(targetPos, 1.0f).SetEase(Ease.InBounce).SetDelay(1.0f).SetLoops(3).OnComplete(()=> Debug.Log("Completed"));
        Tween tr4 = transform.DOLocalMove(targetPos, 1.0f).SetEase(Ease.InCirc).SetDelay(1.0f).SetLoops(3).OnComplete(()=> Debug.Log("Completed"));

        sequence.Append(tr1);
        sequence.Join(tr2);
        sequence.Insert(5.0f, tr3);
        sequence.Prepend(tr4);

        //�� ��Ĵ�� �ϸ� ������ ������ ��� �Ʒ� ��Ĵ�� �����Ѵ�.
        sequence.Append(tr1)
                .Join(tr2)
                .Insert(5.0f, tr3)
                .Prepend(tr4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Velog�� DOTween�� ��� �� �ʱ� �Ϸ�
}
