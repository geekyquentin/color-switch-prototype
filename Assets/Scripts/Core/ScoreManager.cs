using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager Instance;
    public static int highScore;
    public static int score;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        highScore = PlayerPrefs.GetInt(PlayerPref.HIGHSCORE, 0);
        score = 0;
    }

    public static void AssignScore(int playerScore) {
        score = playerScore;
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt(PlayerPref.HIGHSCORE, highScore);
        }
    }
}
