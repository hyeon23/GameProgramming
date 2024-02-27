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
        //fake null ����
        //�Ʒ� �ΰ��� ������ �߻��ϴ� ����
        //UnityEngine.Object���� Nullable ��� �Ұ�
        //if(rb != null) ���� �������

        //... Unity Object Should not use null simulation : fake null
        //UnityEngine�� Object������ ��� �Ұ�(Rigidbody, Transform etc...)
        //rb?.MovePosition(Vector3.one); // ����
        //Rigidbody rb2 = rb ?? GetComponent<Rigidbody>(); // ����

        if (rb != null) rb.MovePosition(Vector3.one);

        Rigidbody rb2 = rb == null ? null : GetComponent<Rigidbody>();

        int? num = nums?[0];//null�̶�� �� ���� x�ؼ� null ���
        print(num);
    }

    //nullable: �� ���Ŀ� null�� �ִ� ���
    int? num = null;

    //?.: ���� ���İ� nullable�� �Ἥ ���� null�̸� �ڿ� �Լ��� ������Ƽ�� �������� ����

    //?[]: ���� ���İ� nullable �ε����� �Ἥ ���� null�̸� �ڿ� �Լ��� ������Ƽ�� �������� ����

    //??: null�� ��� �ڸ� ����
    //int? num = null;
    //print(num ?? -1);

    //??= : null�� ��� �ڸ� ������ ����
    //int? num = null;
    //num ??= -1;

    //[�߿�]
    //?., ?[], ??=, ?? ��� UnityEngine.Object�� ��� �Ұ� : Fake null
}
