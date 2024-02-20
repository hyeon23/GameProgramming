using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineTest2 : MonoBehaviour
{
    /*
     * Yield
     * YieldInstruction 클래스 : 코루틴은 일정 시간 대기하고, 실행하는 방식으로 작동하는데
     * 해당 방식을 정의한 클래스가 YieldInstruction 클래스
     */

    float time;

    //다음 Update 호출 시까지 대기 후 실행
    IEnumerator CoroutineTest()
    {

        //다음 Update 호출 시까지 대기 후 실행
        yield return null;

        //다음 FixedUpdate 호출 시까지 대기 후 실행
        yield return new WaitForFixedUpdate();

        //float time만큼 시간이 지난 후 첫 프레임까지 대기 후 실행
        //Time.deltaTime을 내부적으로 더해서 구현하는 것과 동일한 코드
        //이로 인한 오차 발생
        yield return new WaitForSeconds(time);
        while (time < 1.0f)
        { 
            yield return null;
            time += Time.deltaTime;
        }

        //float time만큼 시간이 지난 후 첫 프레임까지 대기 후 실행
        //TimeScale의 영향을 받지 않음
        yield return new WaitForSecondsRealtime(time);

        //모든 렌더링 작업이 완료되는 프레임이 끝날때까지 대기 후 실행
        yield return new WaitForEndOfFrame();

        //해당 조건이 참이될 때까지 대기 후 실행[★]
        yield return new WaitUntil(() => time > 10);

        //해당 조건이 참이라면 대기(거짓일 때까지 대기 후 실행)
        yield return new WaitWhile(() => time > 10);
    }

    int cnt = 0;

    private void Start()
    {
        StartCoroutine(WaitLoop());
        StartCoroutine(CoroutineTest());
    }

    private void Update()
    {
        if (cnt < 1000) ++cnt;
        Debug.Log(cnt);
    }

    IEnumerator WaitLoop()
    {
        //...
        yield return new WaitUntil(() => cnt == 1000);
        Debug.LogError("1000");
    }
}