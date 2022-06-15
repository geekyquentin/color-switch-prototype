using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreMenu : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start() {
        highScoreText.text = ScoreManager.highScore.ToString();
        scoreText.text = ScoreManager.score.ToString();
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        AudioManager.PlayClickSound();
    }

    public void ReturnHome() {
        SceneManager.LoadScene(0);
        AudioManager.PlayClickSound();
    }
}