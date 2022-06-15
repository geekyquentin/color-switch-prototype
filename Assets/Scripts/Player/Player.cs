using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float upwardForce = 10f;

    private Camera mainCamera;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private int currentColorIndex;
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private PauseMenu pauseMenu;

    [SerializeField] private ScoreIncrementer scoreIncrementer;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private ParticleSystem powerUpParticle;
    private ParticleSystem psInstance;

    private void Awake() {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        RandomizeColor();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (pauseMenu.IsPaused) { return; }

            rb.velocity = Vector2.up * upwardForce;
            AudioManager.PlayTouchSound();
        }

        if (transform.position.y < mainCamera.transform.position.y - mainCamera.orthographicSize) {
            DeathBehaviour(sr.color);
        }
    }

    private void RandomizeColor() {
        currentColorIndex = GetRandomIndex();
        sr.color = ColorManager.Colors[currentColorIndex];
    }

    private int GetRandomIndex() {
        int length = ColorManager.Colors.Length;
        int randomIndex = Random.Range(0, length);

        return currentColorIndex == randomIndex ? (randomIndex + 1) % length : randomIndex;
    }

    private void DeathBehaviour(Color obstacleColor) {
        scoreIncrementer.DisplayScoreMenu();

        psInstance = Instantiate(explosion, transform.position, Quaternion.identity);
        ParticleSystem.MainModule main = psInstance.main;
        main.startColor = obstacleColor;
        psInstance.Play();
        Destroy(psInstance.gameObject, psInstance.main.startLifetime.constant);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case Tag.COLORCHANGER:
                RandomizeColor();
                obstacleSpawner.InstantiateObstacle();
                Destroy(other.gameObject);
                AudioManager.PlayColorChangeSound();
                break;

            case Tag.OBSTACLE:
                Color obstacleColor = other.GetComponent<SpriteRenderer>().color;
                if (obstacleColor != sr.color) {
                    DeathBehaviour(obstacleColor);
                }
                break;

            case Tag.STAR:
                scoreIncrementer.IncrementScore();

                psInstance = Instantiate(powerUpParticle, other.transform.position, Quaternion.identity);
                psInstance.Play();
                Destroy(psInstance.gameObject, psInstance.main.startLifetime.constant);

                Destroy(other.gameObject);
                AudioManager.PlayStarCollectSound();
                break;
        }
    }
}
