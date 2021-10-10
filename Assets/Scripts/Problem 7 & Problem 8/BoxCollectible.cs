using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollectible : MonoBehaviour
{
    public int score = 1;
    [SerializeField] private bool isRespawn;

    // Update is called once per frame
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isRespawn)
                Manager.Instance.AddScore(score);
            else
                Manager.Instance.AddScore(score, this.gameObject);

            gameObject.SetActive(false);
        }
    }
}
