using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private PlayerManager playerManager;

    void Start() 
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            if (playerManager.oxygen < 100) 
            {
                playerManager.oxygen = 100;
            }
            
            Destroy(gameObject);
        }    
    }
}
