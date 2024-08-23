using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemyMovement enemyMovement;

    private PlayerManager playerManager;

    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();

        playerManager = FindObjectOfType<PlayerManager>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            enemyMovement.speed = 0f;
            playerManager.Death();
        }    
    }
}
