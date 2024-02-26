using System.Collections;
using UnityEngine;

public class CoroutineTest3 : MonoBehaviour
{
    //Start 함수를 Coroutine으로 실행하는 것으로 실행 가능
    //프로젝트가 규모가 커지면, 스크립트별 대기로 Start를 지연 실행하는 것이 필요
    //그런 경우 사용

    //캐싱
    WaitForFixedUpdate wf = new WaitForFixedUpdate();

    IEnumerator Start()
    {
        yield return null;

        yield return Util.WaitForSecond(1.0f);
        yield return Util.WaitForSecond(1.1f);
        yield return Util.WaitForSecond(1.2f);
        yield return Util.WaitForSecond(1.3f);
    }

    //Unity 내장함수는 yield return을 통한 지연 호출이 가능
    //물리법칙 - OnCollision 시리즈
    IEnumerator OnCollisionEnter()
    {
        yield return wf;//캐싱
    }
    //입력
    IEnumerator OnMouseEnter()
    {
        yield return wf;//캐싱
    }
    //렌더링
    private IEnumerator OnBecameInvisible()
    {
        yield return wf;//캐싱
    }
    IEnumerator CoTest()
    {
        yield return wf;//캐싱
    }
    //Coroutine 실행 시마다(StartCoroutine()) Garbage가 생기므로, 꼭 필요한 경우에만 사용하는 것이 좋음
    //특정 코루틴을 반복적으로 사용할 필요가 있을 땐
    //Update문으로 대체(Update는 Garbage 생성 X)

    //yield return new 를 수행시마다 Garbage가 생성된다.

    //자주 사용되는 YieldInstructor들은 저장해 수행(캐싱을 통한 재활용)

    //번거로운 캐싱을 해결하는 방법
    //WaitForSeconds wf0.1 = new WaitForSeconds(0.1f);
    //WaitForSeconds wf0.2 = new WaitForSeconds(0.2f);
    //WaitForSeconds wf0.3 = new WaitForSeconds(0.3f);
    //WaitForSeconds wf0.4 = new WaitForSeconds(0.4f);
    //WaitForSeconds wf0.5 = new WaitForSeconds(0.5f);

    //피곤한다.
    //...
    //이렇게 캐싱 해야 하나...
    //아니다 => 정답 Util 클래스에 생성
    //전역적으로 만들고 사용

    //Util.cs 파일엔 매우 효율적이고 전역적으로 사용하는 공용 함수를 작성

    //Utils.cs 파일의 경우 효율적인 작업을 위한 개발자들의 협업 공간으로 사용
}