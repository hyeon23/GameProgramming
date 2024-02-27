using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateParticle : MonoBehaviour
{
    public static DelegateParticle instance;

    [SerializeField] ParticleSystem particle;
    [SerializeField] DelegateEnemy enemy;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else Destroy(instance);

        #region
        AddDelegate();
        #endregion
    }
    #region
    public void AddDelegate()
    {
        enemy.dieDelegate += PlayDieParticle;
    }
    #endregion

    public void PlayDieParticle(Vector3 pos)
    {
        particle.transform.position = pos;
        particle.Play();
    }
}