using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Scripting.APIUpdating;

public class DOtween2 : MonoBehaviour
{
    public Vector3 targetPos = new Vector3(90, 0, 0);
    // Start is called before the first frame update

    public void DoClick()
    {
        //transform.DOMove(targetPos, 5.0f);
        //transform.DOMoveX(5, 5.0f);
        //transform.DOMoveY(5, 5.0f);
        //transform.DOMoveZ(5, 5.0f);
        //transform.DOLocalMove(targetPos, 5.0f);
        //transform.DOLocalMoveX(5, 5.0f);
        //transform.DOLocalMoveY(5, 5.0f);
        //transform.DOLocalMoveZ(5, 5.0f);
        //transform.DORotate(targetPos, 5.0f);
        //transform.DORotate(targetPos, 5.0f, RotateMode.LocalAxisAdd);
        //transform.DORotateQuaternion(Quaternion.identity, 5.0f);
        //transform.DOLookAt(targetPos, 5.0f);
        transform.DOPunchPosition(targetPos, 1000, 10, 1, false);
    }
}
