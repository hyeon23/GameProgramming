using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Array : MonoBehaviour
{
    int[] arr1D = new int[5] { 1, 2, 3, 4, 5 };
    int[,] arr2D = new int[4, 5]
    {
        {1,2,3,4,5 },
        {1,2,3,4,5 },
        {1,2,3,4,5 },
        {1,2,3,4,5 }
    };

    int[,,] arr3D = new int[2, 2, 3]
    {
        {
            {1, 2, 3},
            {1, 2, 3}
        },
        {
            {1, 2, 3},
            {1, 2, 3}
        },

    };
}
