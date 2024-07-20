using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletDetection : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "EnemyShipDamage")
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore50();
        }

        if (collision.collider.tag == "EnemyShipTwo")
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore100();
        }

        if (collision.collider.tag == "EnemyShipElite")
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore100();
        }
    }
}
