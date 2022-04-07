using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Trees;
    [SerializeField] GameObject zombiePre, fuelPre;
    [SerializeField] int treeAmount;
    [SerializeField] int zombieAmount;
    [SerializeField] int fuelAmount = 2;
    [SerializeField] int unitDisTerrain;
    [SerializeField] Transform pos;
    Vector3 spawnPos;
    Vector3 spawnPosZ;
    public List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        treeAmount = GameManager.main._diffculty.spawnTreeAmount;
        zombieAmount = GameManager.main._diffculty.spawnZombieAmount;
        fuelAmount = Random.Range(0, 3);
        for (int i = 0; i < treeAmount; i++)
        {
            spawnPos = new Vector3(Random.Range(pos.transform.position.x, pos.transform.position.x + unitDisTerrain), 0, Random.Range(pos.transform.position.z, pos.transform.position.z + unitDisTerrain));
            GameObject Go = Instantiate(Trees[Random.Range(0, Trees.Length)], spawnPos, Quaternion.identity);
            spawnedObjects.Add(Go);
            posCheck(Go, false);
        }
        if (GameManager.main.canSpawnZombies)
        {
            for (int i = 0; i < zombieAmount; i++)
            {
                spawnPosZ = new Vector3(Random.Range(pos.transform.position.x, pos.transform.position.x + unitDisTerrain), 0, Random.Range(pos.transform.position.z, pos.transform.position.z + unitDisTerrain));
                GameObject Go = Instantiate(zombiePre, spawnPosZ, Quaternion.identity);
                spawnedObjects.Add(Go);
                posCheck(Go, false);
            }
        }
        float canSpawnFuel = Random.Range(0, 100);
        if (canSpawnFuel > 90 && GameManager.main.canSpawnZombies)
        {
            for (int i = 0; i < fuelAmount; i++)
            {
                spawnPosZ = new Vector3(Random.Range(pos.transform.position.x, pos.transform.position.x + unitDisTerrain), 0, Random.Range(pos.transform.position.z, pos.transform.position.z + unitDisTerrain));
                GameObject Go = Instantiate(fuelPre, spawnPosZ, Quaternion.identity);
                spawnedObjects.Add(Go);
                posCheck(Go, true);
            }
        }
    }

    void posCheck(GameObject currentObject, bool fuel)
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            float distance;
            distance = Vector3.Distance(currentObject.transform.position, spawnedObjects[i].transform.position);
            if (distance < 2 && distance > 0)
            {
                spawnedObjects.Remove(currentObject);
                if (!fuel)
                {
                    Destroy(currentObject);
                }
                else
                {
                    Destroy(spawnedObjects[i]);
                }
            }
        }
    }

    void OnDestroy()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            Destroy(spawnedObjects[i]);
        }
    }
}
