using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives = 4;
    public int score = 0;
    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddScore(int scoreChange)
    {
        score += scoreChange;
        if (UI.instance != null)
            UI.instance.UpdateScore(score);
    }

    public void AddLives(int livesChange)
    {
        lives += livesChange;
        if (UI.instance != null)
            UI.instance.UpdateLives(lives);
    }
}
