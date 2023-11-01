using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public AudioSource click;

    public GameObject pauseMenu;

    public bool isPaused;
    public bool isGameOver; // Thêm biến để kiểm tra xem trò chơi đã kết thúc hay chưa

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        isGameOver = false; // Khởi tạo biến isGameOver là false
    }

    public void PauseGames()
    {
        if (isGameOver) // Kiểm tra nếu trò chơi đã kết thúc, không thực hiện PauseGame
            return;
        click.Play();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        click.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void GoToMainMenu()
    {
        click.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }
    public void QuitGame()
    {
        click.Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
