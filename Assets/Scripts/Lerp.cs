using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    //Lerp
    //Lerp 함수는 선형 보간법 사용
    //선형 보간: 두 점(시작점/끝점) 사이의 공백(무수히 많은 점)을 추정하기 위해 직선 거리에 따라 비례적으로 계산하는 방법
    //* 정보가 없는 중간값을 예상하는 기술이라 보면 된다.
    //많이 사용되긴 한다.

    //1, Mathf.Lerp(최소값, 최대값, 비율(0 to 1))
    //비율에 따라 최소값 - 최대값 사이의 비율에 해당하는 값이 산출되어 나온다.
    //이동, 화면전환, 색변환 등 여러 변환에 사용

    Vector3 startPos;
    Vector3 targetPos = new Vector3(0, 5, 0);
    float currentTime = 0;
    public float targetTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = Vector3.Lerp(startPos, targetPos, currentTime / targetTime);
    }

    //다양한 Lerp 함수들
    //1. Mathf.Lerp: 두 수 사이 보간
    //2. Color.Lerp: 두 Color 사이 보간
    //3. Color32.Lerp: 두 Color32 사이 보간
    //4. Vector2.Lerp: 두 Vector2 사이 보간
    //5. Vector3.Lerp: 두 Vector3 사이 보간
    //6. Vector4.Lerp: 두 Vector4 사이 보간
    //7. Material.Lerp: 두 Material 사이 보간
}
