using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float countdown;

    public bool canPlay;

    public GameObject oxygen;

    public Sprite oxygen100;
    public Sprite oxygen80;
    public Sprite oxygen50;
    public Sprite oxygen30;
    public Sprite oxygen0;

    private Image oxygenImage;

    private PlayerManager playerManager;

    void Start() 
    {
        oxygenImage = oxygen.GetComponent<Image>();
        playerManager = FindObjectOfType<PlayerManager>();

        if (SceneManager.GetActiveScene().buildIndex == 0) 
        {
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        CanPlayAnimationCountdown();

        RestartLevel();

        ChangeOxygenImage();
    }

    void CanPlayAnimationCountdown() 
    {
        countdown -= 1 * Time.deltaTime;

        if (countdown <= 0) 
        {
            countdown = 0;
            canPlay = true;
        }
    }

    void RestartLevel() 
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void ChangeOxygenImage() 
    {
        if (playerManager.oxygen <= 100) 
        {
            oxygenImage.sprite = oxygen100;
        }
        
        if (playerManager.oxygen <= 80) 
        {
            oxygenImage.sprite = oxygen80;
        }
        
        if (playerManager.oxygen <= 50) 
        {
            oxygenImage.sprite = oxygen50;
        }
        
        if (playerManager.oxygen <= 30) 
        {
            oxygenImage.sprite = oxygen30;
        }
        
        if (playerManager.oxygen <= 0) 
        {
            oxygenImage.sprite = oxygen0;
        }
    }
}
