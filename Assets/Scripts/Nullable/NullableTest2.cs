using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullableTest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string s = null;
        //print(s.IndexOf('링'));//null에서 참조하므로 에러 발생

        //null이면 참조하지 않고, null이 아니면 참조해주는 ?. 사용
        print(s?.IndexOf('링') ?? -1);//null에서 참조하므로 에러 발생

        //??=
        //: null이라면 할당
    }
}
