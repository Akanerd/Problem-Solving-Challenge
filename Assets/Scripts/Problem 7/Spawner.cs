using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : SpawnerBox
{
    [SerializeField] private LayerMask unspawnable;
    Queue<GameObject> boxQue = new Queue<GameObject>();
    Queue<float> respawnQue = new Queue<float>();
    float currentTime;

    protected override void Start()
    {
        int spawn = Random.Range(1, Maxspawnbox + 1);

        for (int i = 0; i < spawn; i++)
        {
            GameObject boxObj = Instantiate(smallBox);
            boxObj.transform.position = Getspawner();
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (respawnQue.Count > 0 && currentTime >= respawnQue.Peek())
        {
            respawnQue.Dequeue();

            GameObject respawnObj = boxQue.Dequeue();
            respawnObj.transform.position = Getspawner();
            respawnObj.gameObject.SetActive(true);
        }
    }

    protected override Vector2 Getspawner()
    {
        Vector2 spawnPoint = new Vector2();
        spawnPoint.x = Random.Range(-spawnRadius.x, spawnRadius.x);
        spawnPoint.y = Random.Range(-spawnRadius.y, spawnRadius.y);

        if (Physics2D.OverlapBox(spawnPoint, Vector2.one, unspawnable))
            return Getspawner();

        return spawnPoint;
    }

    public void Respawn(GameObject box)
    {
        boxQue.Enqueue(box);
        respawnQue.Enqueue(currentTime + 3f);
    }
}
