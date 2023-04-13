using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{

    public static UI instance;

    [SerializeField] TextMeshProUGUI scoreText;

    public int lives = 4;
    public int score = 0;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
        scoreText.text = score.ToString();
    }

    public void UpdateLives(int livesChange)
    {
        lives += livesChange;
    }
}
