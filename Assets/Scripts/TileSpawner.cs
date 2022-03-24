using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject tileMap;
    public float zSpawn = 0;
    public float xSpawn = 25;  
    public float tileLength = 30;
    public float tileWith = 40;
    public float spawnPosX;
    public int numberOfTiles = 5;
    public Transform playerTransform;
    public List<GameObject> TilesList = new List<GameObject>();
    GameObject go;
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                
                SpawnTile(0);
            }
            else
                SpawnTile(Random.Range(1, tilePrefabs.Length));
        }

    }
    void Update()
    {

        if (playerTransform.position.z > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            if (playerTransform.position.x > xSpawn)
            {

                SpawnTileX(Random.Range(1, tilePrefabs.Length), tileWith, tileLength);
                SpawnTileX(Random.Range(1, tilePrefabs.Length), tileWith, tileLength + 30);
            }
            if (playerTransform.position.x < xSpawn)
            {

                SpawnTileX(Random.Range(1, tilePrefabs.Length), tileWith - 80, tileLength);
                SpawnTileX(Random.Range(1, tilePrefabs.Length), tileWith - 80, tileLength + 30);
            }
        }
      
        if (TilesList.Count > 15)
        {

            Destroy(TilesList[0]);
            TilesList.RemoveAt(0);
        }
    }

    public void SpawnTile(int tileIndex)
    {
        go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, tileMap.transform.rotation);
        go.transform.position = new Vector3(spawnPosX, 0, zSpawn);
        go.transform.parent = tileMap.transform;

        zSpawn += tileLength;
        TilesList.Add(go);
    }
    public void SpawnTileX(int tileIndex, float X, float min)
    {
        go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, tileMap.transform.rotation);
        go.transform.position = new Vector3(X, 0, zSpawn - min);
        go.transform.parent = tileMap.transform;

        if (playerTransform.position.x > tileWith)
        {
            print("great");
           spawnPosX = tileWith;
            xSpawn = tileWith + 15;
            tileWith = tileWith + 40;
        }
        if (playerTransform.position.x < tileWith -40)
        {

            print("greatL");
            spawnPosX = tileWith - 80;
            xSpawn = tileWith - 15;
            tileWith = tileWith - 40;

        }
        TilesList.Add(go);
    }
}
