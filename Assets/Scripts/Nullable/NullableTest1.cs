using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullableTest1 : MonoBehaviour
{
    void Start()
    {
        //�� Ÿ�Կ� null �Ҵ� �Ұ�
        //int i = null;
        //float f = null;
        //bool b = null;
        //double d = null;
        //char c = null;
        //Vector3 vec = null;

        //Nullable �� ���ĸ� �����ϴ� ���׸�
        System.Nullable<bool> mybool;//bool? mybool�� ����

        //�� Ÿ�Կ� null�� �ֱ� ���ؼ� ?�ڷ��� ���
        int? i = null;
        float? f = null;
        bool? b = null;
        double? d = null;
        char? c = null;
        Vector3? vec = null;

        //HasValue: ���� Null�� �ƴ��� üũ != null -> ture, = null -> false
        //Value: �ش� �� ����
        //GetValueOrDefault() : null�� ��� �ش� �ڷ����� �⺻ �� ���� int -> 0

        void Start()
        {
            int? num = null;
            if (num.HasValue)
            {
                //int numVal = num; ���� Nullable�� Struct Ÿ���� �ƿ� ������ Ÿ�� = ����ȯ �ʿ�
                //�ݴ�� ����
                int numValue = num.Value; // ���������� (int)num ����
                
                print(numValue);
            }

            int numValue2 = num ?? -1;//�� ����� �����ϹǷ�, null�̸� -1 ���� numValue�� �ִ´�.

            num ??= -1;//���� num�� null�̶�� -1�� num�� �ִ´�.
        }
    }

}
