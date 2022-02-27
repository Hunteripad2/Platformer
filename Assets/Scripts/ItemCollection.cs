using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    private int cherries = 0;
    private int gems = 0;

    [SerializeField] private Text cherriesScore;
    [SerializeField] private Text gemsScore;
    [SerializeField] private AudioSource collectCherrySoundEffect;
    [SerializeField] private AudioSource collectGemSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            cherries++;
            cherriesScore.text = cherries.ToString();
            collision.GetComponent<Animator>().SetTrigger("collected");
            collectCherrySoundEffect.Play();
        }
        else if (collision.gameObject.CompareTag("Gem"))
        {
            gems++;
            gemsScore.text = gems.ToString();
            collision.GetComponent<Animator>().SetTrigger("collected");
            collectGemSoundEffect.Play();
        }
    }
}
