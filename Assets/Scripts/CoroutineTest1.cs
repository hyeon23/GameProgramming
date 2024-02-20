using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTest1 : MonoBehaviour
{
    /*
     * 코루틴: 업데이트 메서드와 달리 
     * 메서드의 제어권을 유니티에 반환하고, 
     * 특정 조건이 되면 다시 진행하는 기능
     */

    //Fade In & Out Coroutine
    public Image image;
    private float alpha;
    private float fadeTime = 3.0f;
    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime / fadeTime;
            image.color = new Color(1,1,1,alpha);
            yield return null;

            if (alpha > 0.5f) yield break;
        }
    }

    /*
     * 코루틴 사용 조건
     * 1. MonoBehaviour 상속 필수
     * 2. IEnumerator를 반환하는 함수
     * 3. StartCoroutine(IEnumerator)로 사용
     * 4. yield return(조건)을 사용한다.
     * yield return을 만나는 순간, 다음 줄부터 실행되는 프레임이 다름
     * 5. 코루틴을 실행하는 게임오브젝트가 비활성화되거나 파괴되면 코루틴 종료
     */

    /*
     * yield break: 코루틴 종료
     */

    IEnumerator Count()
    {
        //프레임1
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        //제어권을 넘김 = 대기

        //일정 조건 달성 시 재개
        //프레임2
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        //제어권을 넘김 = 대기

        gameObject.SetActive(false);
        //Destroy(gameObject);

        //일정 조건 달성 시 재개
        //프레임3
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        //제어권을 넘김 = 대기

        //일정 조건 달성 시 재개
        //프레임4
    }

}