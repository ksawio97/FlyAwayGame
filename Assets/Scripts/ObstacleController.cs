using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private GameObject ObstaclePrefab;

    private List<GameObject> obstacles = new List<GameObject>();

    private Vector3 moveAmount;
    private readonly float maxMoveSpeed = 0.5f;

    private float spawnWaitTime;
    private readonly float minSpawnWaitTime = 0.5f;

    private float spawnTimer;

    private float killx;

    private float timeToNextWave;

    void Start()
    {
        spawnWaitTime = 1.5f;
        spawnTimer = spawnWaitTime;

        moveAmount = new Vector3(-0.2f / 5, 0);

        killx = -2.3f;
    }

    //calls every 0.02
    void FixedUpdate()
    {
        TryChangingSpawnSettings();
        TrySpawnObstacle();
        ObstalesMove();
        ObstaclesDestroy();
    }

    private void TryChangingSpawnSettings()
    {
        timeToNextWave += 0.02f;
        if (2 < timeToNextWave)
        {
            timeToNextWave = 0;
            if (moveAmount.x < maxMoveSpeed)
                moveAmount.x += -0.02f / 5;
            if (spawnTimer < minSpawnWaitTime)
                spawnTimer -= 0.04f;
        }
    }

    void TrySpawnObstacle()
    {
        if (spawnWaitTime <= spawnTimer)
        {
            spawnTimer = 0f;
            Spawn();
        }
        spawnTimer += Time.deltaTime;
    }

    void Spawn()
    {
        obstacles.Add(CreateObstacle());
    }

    GameObject CreateObstacle()
    {
        GameObject tempPipe = Instantiate(ObstaclePrefab) as GameObject;

        return tempPipe;
    }

    void ObstalesMove()
    {
        foreach (GameObject obstacle in obstacles)
            obstacle.transform.position += moveAmount;
    }

    void ObstaclesDestroy()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].transform.position.x <= killx)
            {
                Destroy(obstacles[i]);
                obstacles.RemoveAt(i);
                return;
            }
        }
    }
}
