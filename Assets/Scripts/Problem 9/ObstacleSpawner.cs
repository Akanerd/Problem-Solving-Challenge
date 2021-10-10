using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private LayerMask unspawnable;
    [SerializeField] private GameObject toSpawn;
    [SerializeField] private Vector2 spawnRadius;
    [SerializeField] private int maxSpawn;
    [SerializeField] private float spawnTimer;
    private float currentTime;
    
    Queue<GameObject> obstacleQue = new Queue<GameObject>();

    void Start()
    {
        InvokeRepeating("SpawnObs", spawnTimer, spawnTimer);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= spawnTimer)
        {
            if (obstacleQue.Count > 0) RespawnObs();

            currentTime = 0;
        }
    }

    Vector2 GetSpawnPos()
    {
        Vector2 spawnPoint = new Vector2();
        spawnPoint.x = Random.Range(-spawnRadius.x, spawnRadius.x);
        spawnPoint.y = Random.Range(-spawnRadius.y, spawnRadius.y);

        if (Physics2D.OverlapBox(spawnPoint, Vector2.one*3f, unspawnable))
            return GetSpawnPos();

        return spawnPoint;
    }
    
    void SpawnObs()
    {
        GameObject obs = Instantiate(toSpawn);
        obs.transform.position = GetSpawnPos();
        obs.GetComponent<Obstacle>().spawner = this;
        maxSpawn -= 1;

        spawnTimer = Random.Range(1f, 6f);
        if (maxSpawn <= 0) CancelInvoke();
    }

    public void QueObstacle(GameObject obs)
    {
        obstacleQue.Enqueue(obs);
    }

    void RespawnObs()
    {
        if (obstacleQue.Count <= 0)
            return;

        GameObject toRespawn = obstacleQue.Dequeue();
        toRespawn.transform.position = GetSpawnPos();
        toRespawn.SetActive(true);

        spawnTimer = Random.Range(1f, 6f);
    }
}
