using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//copy paste:
// > < ||

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 5;
    public int currentHealth = 5;


    public float immunityDuration = 2f;
    private float immunityStopTimeStamp;

    private bool isBlinking = false;


    public SpriteRenderer playerSprite;


    public Collider2D playerCollider;

    public float volume;
    public AudioClip HitSound;
    public AudioClip DestroySound;

    public GameOverScreen gameOverScreen;



    //character blinks when immune
    private void Blinking(bool on)
    {
        playerSprite.enabled = on;
    }


    private void PlayerDeath()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == "EnemyBulletDamage")
        {
            immunityStopTimeStamp = Time.time + immunityDuration;

            Destroy(collision.gameObject);

            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
            ScoreManager.instance.LoseScore25();
            playerCollider.enabled = false;
            isBlinking = true;

            if (currentHealth >= 1)
            {
                AudioSource.PlayClipAtPoint(HitSound, transform.position, volume);
            }

        }
        
        if (collision.collider.tag == "EnemyShipDamage" || collision.collider.tag == "EnemyShipTwo" || collision.collider.tag == "EnemyShipElite")
        {
            immunityStopTimeStamp = Time.time + immunityDuration;

            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
            ScoreManager.instance.LoseScore50();
            playerCollider.enabled = false;
            isBlinking = true;

            if (currentHealth >= 1)
            {
                AudioSource.PlayClipAtPoint(HitSound, transform.position, volume);
            }
        }


    }


    void Update()
    {


        //ensures that currentHealth cant be lower than 0
        currentHealth = Mathf.Max(currentHealth, 0);


        if (currentHealth <= 0)
        {
            gameOverScreen.GameOver();
            AudioSource.PlayClipAtPoint(DestroySound, transform.position, volume);
            PlayerDeath();
        }

        //player is immune and cant take damage + blinks while immune
        if (Time.time >= immunityStopTimeStamp)
        {
            playerCollider.enabled = true;
            isBlinking = false;
            playerSprite.enabled = true;
        }

        if (isBlinking)
        {
            Blinking(Mathf.Sin(10 * Time.time) > 0);
        }

    }

}
