using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [HideInInspector] private Rigidbody2D rb;
    [HideInInspector] private BoxCollider2D coll;
    [HideInInspector] private Animator anim;
    [HideInInspector] private bool isAlive = true;

    [Header("Sound Effects")]
    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.position.y < -7f && isAlive)
        {
            Die();
        }
        else if (transform.position.y < -8f)
        {
            RestartLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    public void Die()
    {
        isAlive = false;
        anim.SetTrigger("death");
        deathSoundEffect.Play();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        coll.enabled = false;
        GetComponent<PlayerMovement>().Jump();
        GameObject.FindGameObjectsWithTag("BGM")[0].GetComponent<AudioSource>().enabled = false;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
