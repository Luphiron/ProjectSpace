using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructAfterTime : MonoBehaviour
{

    public float destructionTime = 2f; 


    void Start()
    {
        Destroy(gameObject, destructionTime);
    }

    void Update()
    {
        
    }
}
