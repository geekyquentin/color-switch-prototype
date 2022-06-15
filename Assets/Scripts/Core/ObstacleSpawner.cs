using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    private List<KeyValuePair<GameObject, GameObject>> obstaclesInScene = new List<KeyValuePair<GameObject, GameObject>>();

    [SerializeField] private int initialObstacleCount = 2;
    [SerializeField] private float obstacleDistance = 5f;
    private int obstaclesSpawned = 0;

    private GameObject[] obstacles;
    [SerializeField] private GameObject colorChanger;

    private GameObject baseObstacle;

    private void Start() {
        obstacles = Resources.LoadAll<GameObject>(Resource.OBSTACLES);
        baseObstacle = Resources.Load<GameObject>(Resource.BASE);

        InstantiateInitialObstacles();
    }

    private void InstantiateInitialObstacles() {
        for (int i = 0; i < initialObstacleCount; i++) {
            InstantiateObstacle(baseObstacle);
        }
    }

    public void InstantiateObstacle() {
        InstantiateObstacle(obstacles[Random.Range(0, obstacles.Length)]);

        if (obstaclesInScene.Count > 3) {
            Destroy(obstaclesInScene[0].Key);
            Destroy(obstaclesInScene[0].Value);
            obstaclesInScene.RemoveAt(0);
        }
    }

    private void InstantiateObstacle(GameObject obstacle) {
        GameObject obstacleInstance = Instantiate(obstacle, new Vector3(0f, obstaclesSpawned * obstacleDistance, 0f), Quaternion.identity);
        GameObject colorChangerInstance = Instantiate(colorChanger, new Vector3(0f, obstaclesSpawned * obstacleDistance + obstacleDistance / 2, 0f), Quaternion.identity);
        obstaclesInScene.Add(new KeyValuePair<GameObject, GameObject>(obstacleInstance, colorChangerInstance));
        obstaclesSpawned++;
    }
}
