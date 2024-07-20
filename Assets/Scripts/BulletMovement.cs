using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 6f;

    //bullets get destroyed when out of screen
    public float xLimit = 8f;
    public float yLimit = 5.2f;



    void Start()
    {
        
    }

    void Update()
    {
        Vector3 movementvector = new Vector3(0f, bulletSpeed);
        transform.position += movementvector * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        float clampedY = Mathf.Clamp(transform.position.y, -yLimit, yLimit);
        transform.position = new Vector3(clampedX, clampedY);
    }
}
