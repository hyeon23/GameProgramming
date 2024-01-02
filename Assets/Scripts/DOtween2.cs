using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOtween2 : MonoBehaviour
{
    Vector3 targetPos = new Vector3(5, 5, 5);
    // Start is called before the first frame update
    void Start()
    {
        //transform.DOMove(targetPos, 5.0f);
        //transform.DOMoveX(5, 5.0f);
        //transform.DOMoveY(5, 5.0f);
        //transform.DOMoveZ(5, 5.0f);
        //transform.DOLocalMove(targetPos, 5.0f);
        //transform.DOLocalMoveX(5, 5.0f);
        //transform.DOLocalMoveY(5, 5.0f);
        //transform.DOLocalMoveZ(5, 5.0f);
        transform.DORotate(targetPos, 5.0f);
    }
}
