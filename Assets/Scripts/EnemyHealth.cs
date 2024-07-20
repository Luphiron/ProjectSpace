using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject Explosion;
    public SpriteRenderer ShipSprite;
    public CapsuleCollider2D Collider;

    public AudioClip DestroySound;
    public float volume = 1f;

    private void Start()
    {
        Explosion.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerBullet")
        {
            Collider.enabled = false;
            ShipSprite.enabled = false;
            Destroy(gameObject,0.4f);
            GetComponent<EnemyOneShooting>().enabled = false;
            AudioSource.PlayClipAtPoint(DestroySound, transform.position, volume);
            NewEnemies.instance.EnemyKilled();
            Invoke("EnableExplosion", 0f);
            Invoke("DisableExplosion", 0.4f);
        }
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
