using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private AudioSource ButtonSoundEffect;

    public void StartGame()
    {
        ButtonSoundEffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        ButtonSoundEffect.Play();
        SceneManager.LoadScene(1);
    }
}
