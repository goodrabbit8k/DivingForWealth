using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float oxygen;
    public int oxygenTime;

    public AudioClip collectOxygenSound;

    public bool death;

    private AudioSource playerAudio;
    private Animator playerAnim;

    private PlayerMovement playerMovement;
    private GameManager gameManager;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();
        gameManager = FindObjectOfType<GameManager>();

        death = false;
    }

    void Update()
    {
        Oxygen();
    }

    void Oxygen() 
    {
        if (gameManager.canPlay) 
        {
            oxygen -= oxygenTime * Time.deltaTime;
        }
        
        if (oxygen <= 0) 
        {
            oxygen = 0f;
            Death();
        }
    }

    public void Death() 
    {
        if (gameManager.canPlay) 
        {
            death = true;
            oxygen = 0f;
            playerMovement.speed = 0f;
            
            playerAnim.SetTrigger("isDeath");

            Invoke("RestartGame", 2f);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Oxygen") 
        {
            playerAudio.PlayOneShot(collectOxygenSound, 0.5f);
        }    
    }

    void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
