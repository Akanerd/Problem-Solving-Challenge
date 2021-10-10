using UnityEngine;

public class Obstacle : Movement
{
    private float lifeTime;
    public ObstacleSpawner spawner;
    private int respawnCount;

    //overrided, do nothing
    private void FixedUpdate() { }
    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            spawner.QueObstacle(this.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        base.Movementball();
        RigidBody2D.AddForce(movement * Random.Range(50f, 250f) * (1f + respawnCount*0.1f));
        lifeTime = Random.Range(3f, 20f * (1f + respawnCount * 0.1f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RigidBody2D.AddForce(collision.GetContact(0).normal);

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Manager.Instance.GameOver();
        }
    }
}
