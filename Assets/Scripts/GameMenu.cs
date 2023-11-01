using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
    public GameObject aboutMenu;
    public GameObject menuSetting;

    void Start()
    {
        Time.timeScale = 1f;
        aboutMenu.SetActive(false);
    }
    public AudioSource click;
    public void Load(int index)
    {
        click.Play();
        SceneManager.LoadScene(index);
    }
    public void AboutGame()
    {
        click.Play();
        aboutMenu.SetActive(true);
    }
    public void MenuSetting()
    {
        click.Play();
        menuSetting.SetActive(true);
    }
    public void ReturnMenu()
    {
        click.Play();
        aboutMenu.SetActive(false);
        menuSetting.SetActive(false);
    }
    public void exit()
    {
        click.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
