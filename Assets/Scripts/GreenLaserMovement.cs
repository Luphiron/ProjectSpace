using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLaserMovement : MonoBehaviour
{
    public float movementSpeed = 0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 movementvector = new Vector3(0f, movementSpeed);
        transform.position += movementvector * Time.deltaTime;
    }
}
