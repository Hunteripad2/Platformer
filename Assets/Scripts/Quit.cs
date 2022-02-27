using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField] private AudioSource ButtonSoundEffect;

    public void QuitGame()
    {
        ButtonSoundEffect.Play();
        Application.Quit();
    }
}
