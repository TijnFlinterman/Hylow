using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Trees;
    [SerializeField] int treeAmount;
    [SerializeField] int unitDisTerrain;
    [SerializeField] Transform pos;
    Vector3 spawnPos;
    public List<GameObject> spawnedTrees = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < treeAmount; i++)
        {
            spawnPos = new Vector3(Random.Range(pos.transform.position.x, pos.transform.position.x + unitDisTerrain), 0, Random.Range(pos.transform.position.z, pos.transform.position.z + unitDisTerrain));
            //posCheck(spawnPos);
           GameObject Go = Instantiate(Trees[Random.Range(0, Trees.Length)], spawnPos, Quaternion.identity);
            spawnedTrees.Add(Go);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void posCheck()
    {
        
    }
}
