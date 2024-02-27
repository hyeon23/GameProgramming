using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOtween3 : MonoBehaviour
{
    // Start is called before the first frame update
    //Sequence: Tweener는 하나의 행동에 대해 제어하는 자료형
    //Sequence는 뜻에서 알 수 있듯 값을 제어하지 않고, 다른 Tweener들을 제어합니다. 그룹으로 애니메이션을 적용합니다.
    //하나가 아닌 여러 Tweener를 그룹으로 제어해준다.
    //하나의 Sequence로 여러개의 Tweener를 한번에 진행시킬 수 있다.
    Sequence sequence;
    Vector3 targetPos;
    void Start()
    {
        //Sequence 생성자는 이런 방식으로 선언
        sequence = DOTween.Sequence();
        targetPos = new Vector3(0, 0, 0);
        /*
         * Append : 시퀀스 맨 뒤에 트윈 추가
         * Insert : 삽입을 원하는 특정 시간에 트윈 추가(현재 시간 기준 -> 이후에 시간이 바뀌어도, insert된 시점 기준으로 시퀀스가 붙는다.)
         * Join : 현재 시퀀스의 마지막 트윈과 인자로 입력된 시퀀스를 묶음(동시 실행)
         * Prepend : 시퀀스 맨 앞에 트윈 추가
         */
        Tween tr1 = transform.DOMove(targetPos, 1.0f).SetEase(Ease.Flash).SetDelay(1.0f).SetLoops(3).OnComplete(()=> Debug.Log("Completed"));
        Tween tr2 = transform.DORotate(targetPos, 1.0f).SetEase(Ease.InBack).SetDelay(1.0f).SetLoops(3).OnComplete(() => Debug.Log("Completed"));
        Tween tr3 = transform.DOScale(targetPos, 1.0f).SetEase(Ease.InBounce).SetDelay(1.0f).SetLoops(3).OnComplete(()=> Debug.Log("Completed"));
        Tween tr4 = transform.DOLocalMove(targetPos, 1.0f).SetEase(Ease.InCirc).SetDelay(1.0f).SetLoops(3).OnComplete(()=> Debug.Log("Completed"));

        sequence.Append(tr1);
        sequence.Join(tr2);
        sequence.Insert(5.0f, tr3);
        sequence.Prepend(tr4);

        //위 방식대로 하면 귀찮기 때문에 사실 아래 방식대로 선언한다.
        sequence.Append(tr1)
                .Join(tr2)
                .Insert(5.0f, tr3)
                .Prepend(tr4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Velog에 DOTween의 모든 것 필기 완료
}
