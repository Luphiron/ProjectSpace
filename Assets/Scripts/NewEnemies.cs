using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemies : MonoBehaviour
{
    public static NewEnemies instance;

    public int enemiesKilled;


    private void Awake()
    {
        instance = this;
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
    }
        
}
