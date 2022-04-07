using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public float transitionTime;
    public Text currentScoreText;

    private void Start()
    {
        currentScoreText.text = PlayerPrefs.GetFloat("HighestCurrentScore").ToString("current distance ran was " + "0" + " m");
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadGameplay()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}