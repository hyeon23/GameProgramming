using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullableTest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string s = null;
        //print(s.IndexOf('��'));//null���� �����ϹǷ� ���� �߻�

        //null�̸� �������� �ʰ�, null�� �ƴϸ� �������ִ� ?. ���
        print(s?.IndexOf('��') ?? -1);//null���� �����ϹǷ� ���� �߻�

        //??=
        //: null�̶�� �Ҵ�
    }
}
