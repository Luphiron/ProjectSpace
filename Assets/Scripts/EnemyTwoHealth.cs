using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoHealth : MonoBehaviour
{
    public AudioClip HitSound;
    public AudioClip DestroySound;
    public float volume = 1f;
    public GameObject shield;
    public GameObject Explosion;
    public SpriteRenderer ShipSprite;
    public CapsuleCollider2D Collider;

    public int health = 2;

    private void Start()
    {
        shield.SetActive(false);
        Explosion.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerBullet")
        {
            health -= 1;
            AudioSource.PlayClipAtPoint(HitSound, transform.position, volume);
            Invoke("EnableShield", 0f);
            Invoke("DisableShield", 0.1f);

        }

        if (health == 0)
        {
            Collider.enabled = false;
            ShipSprite.enabled = false;
            Destroy(gameObject, 0.4f);
            GetComponent<EnemyOneShooting>().enabled = false;
            AudioSource.PlayClipAtPoint(DestroySound, transform.position, volume);
            NewEnemies.instance.EnemyKilled();
            Invoke("EnableExplosion", 0f);
            Invoke("DisableExplosion", 0.4f);
        }
    }

    private void EnableShield()
    {
        shield.SetActive(true);
    }

    private void DisableShield()
    {
        shield.SetActive(false);
    }

    private void EnableExplosion()
    {
        Explosion.SetActive(true);
    }

    private void DisableExplosion()
    {
        Explosion.SetActive(false);
    }
}
