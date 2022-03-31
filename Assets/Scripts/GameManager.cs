using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager main;
    public bool canSpawnZombies;
   public  PlayerMovement Player;
    public Diffculty _diffculty;
    // Start is called before the first frame update
    void Start()
    {
        //singleton pattern
        if (main == null)
        {
            main = this;
            //DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        StartCoroutine(spawnZombies());
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        _diffculty = GetComponent<Diffculty>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator spawnZombies()
    {
        yield return new WaitForSeconds(0.2f);

        canSpawnZombies = true;
    }
}
