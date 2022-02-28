using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] private SpriteRenderer sprite;
    [HideInInspector] private Rigidbody2D rb;
    [HideInInspector] private BoxCollider2D coll;
    [HideInInspector] private Animator anim;
    [HideInInspector] private enum MovementState { idle, running, jumping, falling, climbingIdle, climbing }
    [HideInInspector] private float dirX = 0f;
    [HideInInspector] private float dirY = 0f;
    [HideInInspector] private bool isClimbing = false;

    [Header("Movement")]
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    [Header("Sound Effects")]
    //[SerializeField] private AudioSource moveSoundEffect;
    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        dirY = rb.velocity.y;

        if (isClimbing)
        {
            dirY = Input.GetAxisRaw("Vertical") * movementSpeed;
        }

        rb.velocity = new Vector2(dirX, dirY);

        if (Input.GetButtonDown("Jump") && IsOnGround())
        {
            Jump();
            jumpSoundEffect.Play();
        }

        UpdateAnimationState();
    }

    //private void FixedUpdate()
    //{
    //    if (dirX > 0f && IsOnGround() && moveSoundEffect.isPlaying == false)
    //    {
    //        moveSoundEffect.Play();
    //    }
    //    else
    //    {
    //        moveSoundEffect.Stop();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = 3;
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (isClimbing)
        {
            state = MovementState.climbingIdle;
        }
        else
        {
            state = MovementState.idle;
        }

        if (dirX != 0f)
        {
            if (isClimbing)
            {
                state = MovementState.climbing;
            }
            else
            {
                state = MovementState.running;
            }

            if (dirX < 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        if (dirY != 0f && isClimbing)
        {
            state = MovementState.climbing;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsOnGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
