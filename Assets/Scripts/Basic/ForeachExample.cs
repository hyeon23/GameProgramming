using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class ForeachExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Foreach
        int[] arr = { 1, 2, 3, 4, 5 };
        foreach(int item in arr)
        {
            Debug.Log(item);
        }

        //Gotos
        for(int i = 0; i < 5; ++i)
        {
            for(int j = 0; j < 5; ++j)
            {
                for(int k = 0; k < 5; ++k)
                {
                    if (i == 1 && k == 2) goto EXIT_FOR;
                }
            }
        }

    EXIT_FOR://·¹ÀÌºí

        Debug.Log("Exit");
    }
}
