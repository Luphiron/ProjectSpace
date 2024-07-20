using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Vector3 spawnOffset = new Vector3(0f, 0.5f);
    
    //player only can shoot every 0.5 sec
    public float shootInterval = 0.5f;
    private float timeOfLastShotFired;

    public float volume;
    public AudioClip bulletSound;


    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && CanShoot())
        {
            timeOfLastShotFired = Time.time;
            Instantiate(bulletPrefab, transform.position + spawnOffset, Quaternion.identity);
            AudioSource.PlayClipAtPoint(bulletSound, transform.position, volume);
        }

    }

    bool CanShoot()
    {
        return Time.time - shootInterval > timeOfLastShotFired;
    }

    
}
