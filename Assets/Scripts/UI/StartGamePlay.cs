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

        AudioManager.Music.mute = PlayerPrefs.GetInt(PlayerPref.MUSIC, 0) == 0 ? true : false;
        musicOff.SetActive(PlayerPrefs.GetInt(PlayerPref.MUSIC, 1) == 0);

        AudioManager.Sound.mute = PlayerPrefs.GetInt(PlayerPref.SOUND, 0) == 0 ? true : false;
        soundOff.SetActive(PlayerPrefs.GetInt(PlayerPref.SOUND, 1) == 0);
    }

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.PlayClickSound();
    }

    public void RedirectToGitHub() {
        Application.OpenURL(Link.GITHUB);
    }
}
