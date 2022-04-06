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
        highScore = PlayerPrefs.GetFloat("HighScore");
            highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString("0 " + "M");
    }
    public void Update()
    {
        currentEndScore = currentScore;
        currentScoreText.text = currentScore.ToString("0 " + "M");

        if (highScore < currentScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
            highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString("0 " + "M");
        }
    }
}
