using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//���� �ʼ�
public class DOtween1 : MonoBehaviour
{
    //Dotween
    //tween: ������Ʈ�� �ð��� ��ȭ or �� ������ �̾��ִ� ��
    //Dotween or Dotween Pro ����
    private Vector3 targetPos = new Vector3(0, 5, 0);
    private void Start()
    {
        //���� �ڵ�
        transform.DOMove(targetPos, 1.0f)/*.SetEase(Ease.InBounce)*/;

        //DOTween �⺻ ����(���ص� ����)
        //1. autokillmode(bool): �ѹ� ���� �������� ����(��: �޸� ���� / ��: �ǵ����� ���� ����)
        //2. useSafeMode(true ����): �ణ ��������, ����Ǵ� ����, ���� ����� �ı��Ǵ� ���� ���� ������ �ڵ����� ó������
        //3. logBehaviour: ���� �޼��� ����� ����
        //4. SetCapacity(Tweener ����, Sequence ����): Tweener ������ Sequence ������ �����մϴ�.
        DOTween.Init(false, true, LogBehaviour.Verbose).SetCapacity(200, 50);

        //DO �迭 �Լ��� ���� ���� Tweener�� �������� ������ ������ �����ϴ�.
        //Tweener tr = transform.DOMove(targetPos, 1.0f);//autokillmode = false��� ���� �Ұ� -> �̷��� ������� �� ����

        //DOTween�� ����� ����ϱ� ���� ������� �͵�
        //static
        //ramda
        //delegate ��

        //1. DOTween �Լ� �⺻ ����1(�����)
        //DOTween.To(()=> myValue[get value ramda], x=> myValue = x[set value ramde], 100[end value], 1[duration]);

        //2. DOTween �Լ� �⺻ ����2(����)
        //transform.DO �迭 �Լ� ����
        //ó�� �����ϴ� ��ŭ ª�� �������� �� ���¸� ��õ -> ���� �� ���¸� ����ϴ� ������ ����
        //transform.DOMove(100[endvalue], 1[duration]);

        //��ǥ���� DO �迭 �Լ�
        //1. DOMove �迭(DOMove, DOMoveXYZ, DOLocalMoveXYZ ��)

        transform.DOMove(targetPos, 1.0f);
        transform.DOMoveX(1, 1.0f);
        transform.DOMoveY(1, 1.0f);
        transform.DOMoveZ(1, 1.0f);
        transform.DOLocalMove(targetPos, 1.0f);
        transform.DOLocalMoveX(1, 1.0f);
        transform.DOLocalMoveY(1, 1.0f);
        transform.DOLocalMoveZ(1, 1.0f);

        //2. DORotation �迭(DORotate, ROLocalRotate ��)
        transform.DORotate(targetPos, 1.0f);
        transform.DOLocalRotate(targetPos, 1.0f);
        transform.DORotateQuaternion(Quaternion.identity, 1.0f);

        //3. DOScale �迭(DOScale, DOScaleXYZ)
        transform.DOScale(targetPos, 1.0f);
        transform.DOScaleX(1, 1.0f);
        transform.DOScaleY(1, 1.0f);
        transform.DOScaleZ(1, 1.0f);

        //4. ��鸲 ȿ��(ī�޶� ��鸲)
        transform.DOShakePosition(10f, 1, 10, 90, true);

        //3. Set �迭
        //.Set(1[loop], LoopType.yoyo[looptype])
        //DO�� ����� ��ȭ�� ����
        //SET�� ��ȭ�� ����� ����



        //���� ����ϴ� Set �迭
        //SetEase<>(Ease): ��ȭ�� �ϱ��� ����
        //SetLoops<>: ��ȭ�� ������ ����
        //SetDelay<>: ��ȭ�� �����̸� ����
        //SetAutoKill<>

        transform.DOScale(1.5f, 1.0f).SetLoops(3, LoopType.Restart);

        //4. On
        //���ٸ� �̿��� �ݹ� �Լ��� ������ On �迭 �Լ��� ���� ���� ����
        //���ٸ� Ȱ���� �� �˾ƾ� ��
        //���� ����ϴ� On �迭
        //OnComplete
        transform.DOScale(1.5f, 1.0f).SetLoops(3, LoopType.Restart).OnComplete(()=> transform.DOMove(targetPos, 2.0f));

        //OnPlay: �� �Լ��� ���۵� ��

        //���ٸ� ���� ��, �ѵι��� �׽�Ʈ�� �����ϸ� �ȴ�.

        //Tweener : DOTween�� �⺻ Ÿ�� / ���� �����ϰ� �ִϸ��̼��� �����Ѵ�.
        //Dotween �ൿ�� �����ϰ�, �����ϱ� ���� �ڷ���
        DOTween.Init(true, true, LogBehaviour.Verbose);//ó�� ���ڸ� true�� �����ϴ� ������ �ʿ��ϴ�.
        //false ��, �޸𸮿��� �����ǰ�, ������� �ʾ�, ���� �ڵ�� �ٸ� �ൿ�� �ȴ�.
        //true ��, Tweener ������ �����ϰ�, tr.Play()�� ���� �����ϰ� �ȴ�.
        Tweener tr = transform.DOScale(1.5f, 2.0f).SetEase(Ease.InBounce);
        tr.Play();//Tweener ����

        //DOTweene.Init�� Autokill�� false���� SetAutoKill(false) �Լ��� ���� ���� �����ϴ�.
        Tweener tr1 = transform.DOScale(1.5f, 2.0f).SetEase(Ease.InBounce).SetAutoKill(false);

        //DOTweene�� �Ϻ����� ������ �ѹ� �������� Garbage�� �����(���ɿ� ū ������ �ƴ�) -> �ݺ������� ���� ���̴� ������ �����ϸ� �� �� �޸𸮰��� ���鿡�� ������ �ȴ�.
        //�����ϴ� ��ŭ Garbage�� �� ������̱� ����
        //�޸𸮸� ���������� ��ƸԴ´ٴ� ������ �����Ѵ�.
        //���̻� �Ⱦ� ��, Kill�� ���� �޸𸮿��� ����� ���� ����.
        tr1.Play();//����
        //���̻� ������ ����
        tr1.Kill();//�޸� �Ҵ� ����

        
    }
}
