using UnityEngine;

public class Diffculty : MonoBehaviour
{
    public float oldMetersWalked;
    public int spawnZombieAmount = 3;
    public int spawnTreeAmount = 6;
    public int maxZombieAmount;
    public int maxTreeAmount;

    void Update()
    {
        if (GameManager.main.Player.metersWalked > oldMetersWalked + 100)
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
