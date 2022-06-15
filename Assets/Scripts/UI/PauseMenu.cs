using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public bool IsPaused { get; private set; } = false;

    [SerializeField] private GameObject pauseMenu;

    public void DealPauseMenu() {
        IsPaused = !IsPaused;
        pauseMenu.SetActive(IsPaused);

        Time.timeScale = IsPaused ? 0 : 1;

        AudioManager.PlayClickSound();
    }

    public void ReturnToHome() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        AudioManager.PlayClickSound();
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.PlayClickSound();
    }
}
