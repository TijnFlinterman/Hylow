using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static float currentScore;
    public static float currentEndScore;
    public static float highScore;

    public Text currentScoreText;
    public Text highScoreText;

    public void Start()
    {
        currentScore = 0;
    }
    public void Update()
    {
        currentEndScore = currentScore;
        currentScoreText.text = currentScore.ToString("0");

        if (highScore < currentScore)
        {
            highScore = currentScore;
            highScoreText.text = currentScore.ToString("0");
        }

    }
}
