using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCover : MonoBehaviour
{

    public List<Sprite> cloudList;
    public GameObject cloud;
    public int numOfClouds;
    Vector3 minPos;
    Vector3 maxPos;
    Vector2 scaleRange = new Vector2(1,4);
    Vector2 spawnRange = new Vector2(0.5f, 1f);

    public float cloudSpawn;

    public Vector3 spawnPoint;

    IEnumerator SpawnClouds(){
        while (true)
        {
            yield return new WaitForSeconds(cloudSpawn);
            spawnPoint.x += Random.Range(-spawnRange.x, spawnRange.y);
            spawnPoint.y += Random.Range(-spawnRange.x, spawnRange.y);
            var cloudSpawned = Instantiate(cloud, spawnPoint, Quaternion.identity);
            cloudSpawned.GetComponent<SpriteRenderer>().sprite = cloudList[Random.Range(0, cloudList.Count)];
        }
    }
}
