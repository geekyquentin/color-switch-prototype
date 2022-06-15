using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreIncrementer : MonoBehaviour {

    private int score = 0;

    private bool isDead = false;
    [SerializeField] private float waitForTime = 2f;
    private float timeSpent = 0f;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update() {
        if (!isDead) { return; }

        timeSpent += Time.deltaTime;

        if (timeSpent < waitForTime) { return; }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void IncrementScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void DisplayScoreMenu() {
        isDead = true;
        ScoreManager.AssignScore(score);
    }
}
