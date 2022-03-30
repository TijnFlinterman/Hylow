using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Trees;
    [SerializeField] GameObject zombiePre;
    [SerializeField] int treeAmount;
    [SerializeField] int zombieAmount;
    [SerializeField] int unitDisTerrain;
    [SerializeField] Transform pos;
    Vector3 spawnPos;
    Vector3 spawnPosZ;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < treeAmount; i++)
        {
            spawnPos = new Vector3(Random.Range(pos.transform.position.x, pos.transform.position.x + unitDisTerrain), 0, Random.Range(pos.transform.position.z, pos.transform.position.z + unitDisTerrain));
            //posCheck(spawnPos);
           GameObject Go = Instantiate(Trees[Random.Range(0, Trees.Length)], spawnPos, Quaternion.identity);
            spawnedObjects.Add(Go);
            posCheck(Go);
        }
        for (int i = 0; i < zombieAmount; i++)
        {
            spawnPosZ = new Vector3(Random.Range(pos.transform.position.x, pos.transform.position.x + unitDisTerrain), 0, Random.Range(pos.transform.position.z, pos.transform.position.z + unitDisTerrain));
            //posCheck(spawnPos);
            GameObject Go = Instantiate(zombiePre, spawnPosZ, Quaternion.identity);
            spawnedObjects.Add(Go);
            posCheck(Go);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void posCheck(GameObject currentObject)
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            float dis;
            dis = Vector3.Distance(currentObject.transform.position, spawnedObjects[i].transform.position);
            if (dis < 8 && dis > 0)
            {
                print("poef " + currentObject);
                Destroy(currentObject);
            }
            print(dis);
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
