using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    
    // Start is called before the first frame update
    void Start()
    {
     SpawnEnemywave(waveNumber);
    
    }    

            // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemywave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemywave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }  
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);


        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    
}
