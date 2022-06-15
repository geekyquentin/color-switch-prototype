using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    public static AudioSource Music { get => instance.music; set => instance.music = value; }
    public static AudioSource Sound { get => instance.sound; set => instance.sound = value; }

    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioClip touchSound, colorChangeSound, starCollectSound, clickSound;

    private StartGamePlay startGamePlay;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public static void PlayTouchSound() {
        instance.sound.PlayOneShot(instance.touchSound);
    }

    public static void PlayColorChangeSound() {
        instance.sound.PlayOneShot(instance.colorChangeSound);
    }

    public static void PlayStarCollectSound() {
        instance.sound.PlayOneShot(instance.starCollectSound);
    }

    public static void PlayClickSound() {
        instance.sound.PlayOneShot(instance.clickSound);
    }

    public static void MuteMusic() {
        instance.startGamePlay = FindObjectOfType<StartGamePlay>();
        instance.music.mute = !instance.music.mute;
        PlayerPrefs.SetInt(PlayerPref.MUSIC, instance.music.mute ? 0 : 1);
        instance.startGamePlay.musicOff.SetActive(instance.music.mute);
    }

    public static void MuteSound() {
        instance.startGamePlay = FindObjectOfType<StartGamePlay>();
        instance.sound.mute = !instance.sound.mute;
        PlayerPrefs.SetInt(PlayerPref.SOUND, instance.sound.mute ? 0 : 1);
        instance.startGamePlay.soundOff.SetActive(instance.sound.mute);
    }
}
