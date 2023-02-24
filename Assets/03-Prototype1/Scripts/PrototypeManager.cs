using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float enemySpawnTimer;

    public List<Transform> enemySpawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy(){
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnTimer);
            Vector3 spawnPos = new Vector3(
            enemySpawnPositions[Random.Range(0, enemySpawnPositions.Count)].position.x,
            5,
            enemySpawnPositions[Random.Range(0, enemySpawnPositions.Count)].position.z 
            );
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            Debug.Log("slime spawned");
        }
        
    }
}
