using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private BoxCollider2D coll;
    private Animator anim;
    private WaypointMoving moving;

    [SerializeField] private AudioSource enemyDeathSoundEffect;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        moving = GetComponent<WaypointMoving>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerLife>().Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<PlayerMovement>().Jump();
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        enemyDeathSoundEffect.Play();
        coll.enabled = false;
        moving.enabled = false;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
