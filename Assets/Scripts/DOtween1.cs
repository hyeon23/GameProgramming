using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;//선언 필수
public class DOtween1 : MonoBehaviour
{
    //Dotween
    //tween: 오브젝트의 시간당 변화 or 두 지점을 이어주는 것
    //Dotween or Dotween Pro 존재
    private Vector3 targetPos = new Vector3(0, 5, 0);
    private void Start()
    {
        //최초 코드
        transform.DOMove(targetPos, 1.0f)/*.SetEase(Ease.InBounce)*/;

        //DOTween 기본 설정(안해도 적용)
        //1. autokillmode(bool): 한번 쓴걸 재사용할지 말지(장: 메모리 감소 / 단: 의도하지 않은 동작)
        //2. useSafeMode(true 고정): 약간 느리지만, 실행되는 동안, 실행 대상이 파괴되는 등의 예외 사항을 자동으로 처리해줌
        //3. logBehaviour: 오류 메세지 기록을 설정
        //4. SetCapacity(Tweener 개수, Sequence 개수): Tweener 개수와 Sequence 개수를 설정합니다.
        DOTween.Init(false, true, LogBehaviour.Verbose).SetCapacity(200, 50);

        //DO 계열 함수의 리턴 값은 Tweener로 움직임을 저장해 재사용이 가능하다.
        //Tweener tr = transform.DOMove(targetPos, 1.0f);//autokillmode = false라면 재사용 불가 -> 이렇게 들고있을 수 없음

        //DOTween을 제대로 사용하기 위해 배워야할 것들
        //static
        //ramda
        //delegate 등

        //1. DOTween 함수 기본 형태1(어려움)
        //DOTween.To(()=> myValue[get value ramda], x=> myValue = x[set value ramde], 100[end value], 1[duration]);

        //2. DOTween 함수 기본 형태2(쉬움)
        //transform.DO 계열 함수 적용
        //처음 시작하는 만큼 짧고 직관적인 본 형태를 추천 -> 점차 위 형태를 사용하는 식으로 수행
        //transform.DOMove(100[endvalue], 1[duration]);

        //대표적인 DO 계열 함수
        //1. DOMove 계열(DOMove, DOMoveXYZ, DOLocalMoveXYZ 등)

        transform.DOMove(targetPos, 1.0f);
        transform.DOMoveX(1, 1.0f);
        transform.DOMoveY(1, 1.0f);
        transform.DOMoveZ(1, 1.0f);
        transform.DOLocalMove(targetPos, 1.0f);
        transform.DOLocalMoveX(1, 1.0f);
        transform.DOLocalMoveY(1, 1.0f);
        transform.DOLocalMoveZ(1, 1.0f);

        //2. DORotation 계열(DORotate, ROLocalRotate 등)
        transform.DORotate(targetPos, 1.0f);
        transform.DOLocalRotate(targetPos, 1.0f);
        transform.DORotateQuaternion(Quaternion.identity, 1.0f);

        //3. DOScale 계열(DOScale, DOScaleXYZ)
        transform.DOScale(targetPos, 1.0f);
        transform.DOScaleX(1, 1.0f);
        transform.DOScaleY(1, 1.0f);
        transform.DOScaleZ(1, 1.0f);

        //4. 흔들림 효과(카메라 흔들림)
        transform.DOShakePosition(10f, 1, 10, 90, true);

        //3. Set 계열
        //.Set(1[loop], LoopType.yoyo[looptype])
        //DO는 대상의 변화를 지시
        //SET은 변화의 방식을 조절



        //많이 사용하는 Set 계열
        //SetEase<>(Ease): 변화의 완급을 조절
        //SetLoops<>: 변화에 루프를 적용
        //SetDelay<>: 변화에 딜레이를 적용
        //SetAutoKill<>

        transform.DOScale(1.5f, 1.0f).SetLoops(3, LoopType.Restart);

        //4. On
        //람다를 이용한 콜백 함수의 실행을 On 계열 함수를 통해 수행 가능
        //람다를 활용할 줄 알아야 함
        //자주 사용하는 On 계열
        //OnComplete
        transform.DOScale(1.5f, 1.0f).SetLoops(3, LoopType.Restart).OnComplete(()=> transform.DOMove(targetPos, 2.0f));

        //OnPlay: 두 함수가 시작될 때

        //람다를 익힌 후, 한두번만 테스트를 수행하면 된다.

        //Tweener : DOTween의 기본 타입 / 값을 제어하고 애니메이션을 적용한다.
        //Dotween 행동을 저장하고, 재사용하기 위한 자료형
        DOTween.Init(true, true, LogBehaviour.Verbose);//처음 인자를 true로 변경하는 과정이 필요하다.
        //false 시, 메모리에서 해제되고, 재사용되지 않아, 같은 코드라도 다른 행동이 된다.
        //true 시, Tweener 변수에 저장하고, tr.Play()를 통해 재사용하게 된다.
        Tweener tr = transform.DOScale(1.5f, 2.0f).SetEase(Ease.InBounce);
        tr.Play();//Tweener 재사용

        //DOTweene.Init의 Autokill이 false여도 SetAutoKill(false) 함수를 통해 설정 가능하다.
        Tweener tr1 = transform.DOScale(1.5f, 2.0f).SetEase(Ease.InBounce).SetAutoKill(false);

        //DOTweene이 완벽하지 않은게 한번 쓸때마다 Garbage가 생긴다(성능에 큰 지장은 아님) -> 반복적으로 자주 쓰이는 행위는 재사용하면 좀 더 메모리관리 측면에서 도움이 된다.
        //재사용하는 만큼 Garbage가 덜 생길것이기 때문
        //메모리를 영구적으로 잡아먹는다는 단점이 존재한다.
        //더이상 안쓸 때, Kill을 통해 메모리에서 지우는 것이 좋다.
        tr1.Play();//실행
        //더이상 쓰이지 않음
        tr1.Kill();//메모리 할당 해제

        
    }
}
