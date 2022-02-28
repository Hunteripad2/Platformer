using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [Header("Sound Effects")]
    [SerializeField] private AudioSource ButtonSoundEffect;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

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

    public void QuitGame()
    {
        ButtonSoundEffect.Play();
        Application.Quit();
    }
}
