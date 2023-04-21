using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public static UI instance;
    [SerializeField] Image[] lifeImages;
    [SerializeField] TextMeshProUGUI scoreText;


    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
        
        UpdateScore(AsteroidsGameManager.instance.score);
        UpdateLives(AsteroidsGameManager.instance.lives);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void UpdateLives(int lives)
    {
        for (int i = 1; i < lifeImages.Length + 1; i++)
        {
            lifeImages[i - 1].enabled = lives >= i;
        }
    }
}
