using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullableTest1 : MonoBehaviour
{
    void Start()
    {
        //값 타입에 null 할당 불가
        //int i = null;
        //float f = null;
        //bool b = null;
        //double d = null;
        //char c = null;
        //Vector3 vec = null;

        //Nullable 값 형식만 수용하는 제네릭
        System.Nullable<bool> mybool;//bool? mybool과 동일

        //값 타입에 null을 넣기 위해선 ?자료형 사용
        int? i = null;
        float? f = null;
        bool? b = null;
        double? d = null;
        char? c = null;
        Vector3? vec = null;

        //HasValue: 값이 Null이 아닌지 체크 != null -> ture, = null -> false
        //Value: 해당 값 리턴
        //GetValueOrDefault() : null일 경우 해당 자료형의 기본 값 리턴 int -> 0

        void Start()
        {
            int? num = null;
            if (num.HasValue)
            {
                //int numVal = num; 에러 Nullable과 Struct 타입은 아예 별개의 타입 = 형변환 필요
                //반대는 가능
                int numValue = num.Value; // 내부적으로 (int)num 수행
                
                print(numValue);
            }

            int numValue2 = num ?? -1;//위 방식이 불편하므로, null이면 -1 값을 numValue에 넣는다.

            num ??= -1;//현재 num이 null이라면 -1을 num에 넣는다.
        }
    }

}
