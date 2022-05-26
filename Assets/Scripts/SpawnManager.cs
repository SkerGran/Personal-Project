using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnRangeZ = 8;
    private float spawnPosZ = 20;
    public float startDelay = 2;
    public float startInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, startInterval);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            // Launch a projectile from the player
            SpawnRandomAnimal();
        }*/

    }
    void SpawnRandomAnimal()
    {
        int spawnType = Random.Range(0, 4);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        if(spawnType == 1 || spawnType == 0)
        {
            Vector3 spawnPosX = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(animalPrefabs[animalIndex], spawnPosX, animalPrefabs[animalIndex].transform.rotation);
        }
        if (spawnType == 2)
        {
            Vector3 spawnPosZright = new Vector3(30, 0, Random.Range(1, spawnRangeZ - 1));
            Instantiate(animalPrefabs[animalIndex], spawnPosZright, Quaternion.Euler(0, -90, 0));
        }
        if (spawnType == 3)
        {
            Vector3 spawnPosZleft = new Vector3(-30, 0, Random.Range(1, spawnRangeZ - 1));
            Instantiate(animalPrefabs[animalIndex], spawnPosZleft, Quaternion.Euler(0, 90, 0));
        }        
    }
}
