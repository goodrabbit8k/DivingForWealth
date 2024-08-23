using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
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
            playerManager.Death();
        }    
    }
}
