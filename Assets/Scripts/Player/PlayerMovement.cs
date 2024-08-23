using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float toIdleTimer;

    private bool moveIdle;
    private bool idle;

    public AudioClip swimSound;

    private float horizontalInput;

    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private BoxCollider2D idleCollider;
    private CapsuleCollider2D swimCollider;

    private PlayerManager playerManager;
    private GameManager gameManager;

    void Start() 
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        idleCollider = GetComponent<BoxCollider2D>();
        swimCollider = GetComponent<CapsuleCollider2D>();

        playerManager = GetComponent<PlayerManager>();
        gameManager = FindObjectOfType<GameManager>();    

        toIdleTimer = 3f;

        moveIdle = false;
        idle = true;
    }

    void Update()
    {
        if (!playerManager.death && gameManager.canPlay)
        {
            Swimming();
            Jump();
            Flip();
        }

        ChangeCollider();
    }

    void Swimming() 
    {
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);
    }

    void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);

            if (moveIdle) 
            {
                playerAnim.SetBool("isMoveJump", true);
                StartCoroutine(TurnOffMoveJumpAnimations());
            }
            else if (idle) 
            {
                playerAnim.SetBool("isJump", true);
                StartCoroutine(TurnOffJumpAnimations());
            }

            playerAudio.PlayOneShot(swimSound, 0.5f);
        }
    }

    void Flip() 
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(horizontalInput) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(horizontalInput), transform.localScale.y);
        }
    }

    void ChangeCollider() 
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(horizontalInput) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed) 
        {
            toIdleTimer = 3f;

            swimCollider.enabled = true;
            idleCollider.enabled = false;
    
            playerAnim.SetBool("isMove", true);
            playerAnim.SetBool("isIdle", false);
        }
        else 
        {
            toIdleTimer -= 1 * Time.deltaTime;

            moveIdle = true;
            idle = false;

            playerAnim.SetBool("isIdle", true);

            if (toIdleTimer <= 0) 
            {
                toIdleTimer = 0;

                moveIdle = false;
                idle = true;

                idleCollider.enabled = true;
                swimCollider.enabled = false;
                
                playerAnim.SetBool("isMove", false);
                playerAnim.SetBool("isIdle", false);
            } 
        }
    }

    IEnumerator TurnOffJumpAnimations() 
    {
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("isJump", false);
    }

    IEnumerator TurnOffMoveJumpAnimations() 
    {
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("isMoveJump", false);
    }
}
