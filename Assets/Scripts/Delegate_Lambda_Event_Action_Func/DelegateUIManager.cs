using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DelegateUIManager : MonoBehaviour
{
    public static DelegateUIManager instance;
    [SerializeField] TextMeshPro text;
    [SerializeField] DelegateEnemy enemy;
    private int num;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        num = 0;
        text.text = num.ToString();

        #region
        AddDelegate();
        #endregion
    }
    #region
    public void AddDelegate()
    {
        enemy.dieDelegate += AddScore;
    }
    #endregion

    public void AddScore(Vector3 pos)
    {
        num++;
        text.text = num.ToString();
    }
}
