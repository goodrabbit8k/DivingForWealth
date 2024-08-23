using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject bubbleOxygen;
    public GameObject tutorial;

    private AudioSource buttonAudio;

    void Start() 
    {
        buttonAudio = GetComponent<AudioSource>();    
    }

    public void Play() 
    {
        Time.timeScale = 1;

        mainMenu.SetActive(false);
        bubbleOxygen.SetActive(true);
        tutorial.SetActive(true);

        buttonAudio.Play();
    }

    public void Quit() 
    {
        Application.Quit();
        buttonAudio.Play();
    }
}
