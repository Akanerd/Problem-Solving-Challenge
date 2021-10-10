using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private static Manager _instance = null;
    public static Manager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<Manager>();
            return _instance;
        }
    }

    private int score;
    [SerializeField] private Text scoreText;
    [SerializeField] Spawner spawner;

    [SerializeField] private GameObject gameOverPanel;
    private bool isGameOver;

    void Start()
    {
        scoreText.text = "Score : " + score;
    }
   private void Update()
   {
       if (isGameOver && Input.GetKeyDown(KeyCode.R))
       {
           Scene scene = SceneManager.GetActiveScene();
           SceneManager.LoadScene(scene.name);
      }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score : " + score;
    }

    public void AddScore(int addScore, GameObject box)
    {
        score += addScore;
        scoreText.text = "Score : " + score;
        spawner.Respawn(box);
    }

  public void GameOver()
    {
      gameOverPanel.gameObject.SetActive(true);
      isGameOver = true;
     }
}
