using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OverGame : MonoBehaviour
{

    public AudioSource click;

    public void RetryGame()
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuGame()
    {
        click.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
