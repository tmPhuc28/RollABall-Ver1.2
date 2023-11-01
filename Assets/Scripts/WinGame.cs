using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public AudioSource click;
    public void PreviousLevel()
    {
        click.Play();

        SceneManager.LoadScene("Level01");
    }
    public void NextLevel()
    {
        click.Play();

        SceneManager.LoadScene("Level02");
    }
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
