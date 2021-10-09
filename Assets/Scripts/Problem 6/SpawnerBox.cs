using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBox : MonoBehaviour
{
    [SerializeField]protected GameObject smallBox;
    [SerializeField]protected Vector2 spawnRadius;
    [SerializeField]protected int Maxspawnbox;
    private int Minspawnbox = 1;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Menambahkan Jumlah rentang SpawnBox
        int spawn = Random.Range(Minspawnbox, Maxspawnbox);

        //Perulangan untuk spawnBox
        for (int i = 0; i < spawn; i++)
        {
            GameObject box = Instantiate(smallBox);
            box.transform.position = Getspawner();
        }
    }

    // Update is called once per frame
    protected virtual Vector2 Getspawner()
    {
        //Random Peletakkan Box
        float x = Random.Range(-spawnRadius.x, spawnRadius.x);
        float y = Random.Range(-spawnRadius.y, spawnRadius.y);

        return new Vector2(x,y);
    }
}
