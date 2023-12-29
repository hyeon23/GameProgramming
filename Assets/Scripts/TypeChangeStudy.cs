using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeChangeStudy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("이런 것들이 존재했지");
    }

    private void OnDestroy() {
        Debug.Log("cout");
    }

    private void OnEnable() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
