using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Vector3 spawnOffset = new Vector3(1f, -0.5f);
    public Vector3 spawnOffset1 = new Vector3(-1f, -0.5f);

    public float shootInterval = 1f;
    private float timeOfLastShotFired;

    public float volume;
    public AudioClip bulletSound;


    void Update()
    {
        if (CanShoot() && transform.position.y <= 4.2)
        {
            timeOfLastShotFired = Time.time;
            Instantiate(bulletPrefab, transform.position + spawnOffset, Quaternion.identity);
            timeOfLastShotFired = Time.time;
            Instantiate(bulletPrefab, transform.position + spawnOffset1, Quaternion.identity);

            AudioSource.PlayClipAtPoint(bulletSound, transform.position, volume);
        }
    }

    bool CanShoot()
    {
        return Time.time - shootInterval > timeOfLastShotFired;
    }
}
