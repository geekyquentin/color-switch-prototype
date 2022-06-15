using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGamePlay : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI highScoreText;
    public GameObject musicOff, soundOff;

    private void Start() {
        highScoreText.text = ScoreManager.highScore.ToString();

        AudioManager.Music.mute = PlayerPrefs.GetInt(PlayerPref.MUSIC, 1).Equals(0);
        musicOff.SetActive(AudioManager.Music.mute);

        AudioManager.Sound.mute = PlayerPrefs.GetInt(PlayerPref.SOUND, 1).Equals(0);
        soundOff.SetActive(AudioManager.Sound.mute);
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.PlayClickSound();
    }

    public void RedirectToGitHub() {
        Application.OpenURL(Link.GITHUB);
    }
}
