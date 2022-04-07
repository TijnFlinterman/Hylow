using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager main;
    public bool canSpawnZombies;
    public  PlayerMovement Player;
    public Diffculty _diffculty;
    public Chainsaw _chainsaw;

    void Start()
    {
        if (main == null)
        {
            main = this;
        }
        else Destroy(gameObject);
        StartCoroutine(spawnZombies());
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        _chainsaw = GameObject.FindGameObjectWithTag("Chainsaw").GetComponent<Chainsaw>();
        _diffculty = GetComponent<Diffculty>();
    }

    IEnumerator spawnZombies()
    {
        yield return new WaitForSeconds(0.2f);
        canSpawnZombies = true;
    }
}
