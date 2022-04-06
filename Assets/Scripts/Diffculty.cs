using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diffculty : MonoBehaviour
{
    public float oldMetersWalked;
    public int spawnZombieAmount = 3;
    public int spawnTreeAmount = 6;
    public int maxZombieAmount;
    public int maxTreeAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.main.Player.metersWalked > oldMetersWalked + 250)
        {
            if (spawnZombieAmount < maxZombieAmount)
            {
                spawnZombieAmount += 3;
            }
            if (spawnTreeAmount < maxTreeAmount)
            {
                spawnTreeAmount += 2;
            }  
            oldMetersWalked = GameManager.main.Player.metersWalked;
        }
    }
}
