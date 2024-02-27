using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateItemManager : MonoBehaviour
{
    public static DelegateItemManager instance;

    [SerializeField] GameObject item;
    [SerializeField] GameObject enemyObject;
    [SerializeField] DelegateEnemy enemy;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

        #region
        AddDelegate();
        #endregion
    }
    #region
    public void AddDelegate()
    {
        enemy.dieDelegate += DropItem;
    }
    #endregion

    public void DropItem(Vector3 pos)
    {
        GameObject go = Instantiate(item);
        go.transform.position = enemyObject.transform.position;
    }
}
