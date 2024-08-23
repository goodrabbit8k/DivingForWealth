using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour
{
    private AudioSource treasureAudio;

    void Start() 
    {
        treasureAudio = GetComponent<AudioSource>();    
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            StartCoroutine(LoadNextLevel());
        }    
    }

    IEnumerator LoadNextLevel() 
    {
        treasureAudio.Play();

        yield return new WaitForSecondsRealtime(1f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) 
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
