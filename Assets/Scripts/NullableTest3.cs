using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class NullableTest3 : MonoBehaviour
{
    int[] nums;
    [SerializeField] Rigidbody rb;
    private void Start()
    {
        //fake null 에러
        //아래 두개는 에러가 발생하는 구문
        //UnityEngine.Object에는 Nullable 사용 불가
        //if(rb != null) 으로 사용하자

        //... Unity Object Should not use null simulation : fake null
        //UnityEngine의 Object에서는 사용 불가(Rigidbody, Transform etc...)
        //rb?.MovePosition(Vector3.one); // 에러
        //Rigidbody rb2 = rb ?? GetComponent<Rigidbody>(); // 에러

        if (rb != null) rb.MovePosition(Vector3.one);

        Rigidbody rb2 = rb == null ? null : GetComponent<Rigidbody>();

        int? num = nums?[0];//null이라면 뒤 실행 x해서 null 출력
        print(num);
    }

    //nullable: 값 형식에 null을 넣는 방법
    int? num = null;

    //?.: 참조 형식과 nullable에 써서 앞이 null이면 뒤에 함수나 프로퍼티를 실행하지 않음

    //?[]: 참조 형식과 nullable 인덱서에 써서 앞이 null이면 뒤에 함수나 프로퍼티를 실행하지 않음

    //??: null일 경우 뒤를 실행
    //int? num = null;
    //print(num ?? -1);

    //??= : null일 경우 뒤를 실행해 대입
    //int? num = null;
    //num ??= -1;

    //[중요]
    //?., ?[], ??=, ?? 모두 UnityEngine.Object에 사용 불가 : Fake null
}
