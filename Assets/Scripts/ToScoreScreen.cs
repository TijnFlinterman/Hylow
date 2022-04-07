using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScoreScreen : MonoBehaviour
{
    public Animator animator;
    public float biteTime;
    public float transitionTime;

    private void Start()
    {
        LoadNextLevel();
    }
    private void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(biteTime);
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
