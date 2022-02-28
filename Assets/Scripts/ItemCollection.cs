using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    [HideInInspector] private Text cherryScore;
    [HideInInspector] private Text gemScore;
    [HideInInspector] private int cherries = 0;
    [HideInInspector] private int gems = 0;

    [Header("Sound Effects")]
    [SerializeField] private AudioSource collectCherrySoundEffect;
    [SerializeField] private AudioSource collectGemSoundEffect;

    private void Start()
    {
        cherryScore = GameObject.FindGameObjectWithTag("Cherry Score").GetComponent<Text>();
        gemScore = GameObject.FindGameObjectWithTag("Gem Score").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            cherries++;
            cherryScore.text = cherries.ToString();
            collision.GetComponent<Animator>().SetTrigger("collected");
            collectCherrySoundEffect.Play();
        }
        else if (collision.gameObject.CompareTag("Gem"))
        {
            gems++;
            gemScore.text = gems.ToString();
            collision.GetComponent<Animator>().SetTrigger("collected");
            collectGemSoundEffect.Play();
        }
    }
}
