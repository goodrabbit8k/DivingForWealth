using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private Animator enemyAnim;

    void Start() 
    {
        enemyAnim = GetComponent<Animator>();    
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Platform") 
        {
            speed = -speed;    
            Flip();
        }
    }

    void Flip() 
    {
        transform.localScale = new Vector2((Mathf.Sign(speed)), transform.localScale.y);
        enemyAnim.SetBool("isTurn", true);

        StartCoroutine(TurnOffFlipAnimations());
    }

    IEnumerator TurnOffFlipAnimations() 
    {
        yield return new WaitForSeconds(0.5f);
        enemyAnim.SetBool("isTurn", false);
    }
}
