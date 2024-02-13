using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] egg;
    public Transform SpawnPoint;
    public float IntervalBetweenSpawn;

    private float spawnBetweenTime;

        private void FixedUpdate()
    {
        if(spawnBetweenTime <=0)
        {
            int rand = Random.Range(0, egg.Length);
            Instantiate(egg[rand], SpawnPoint.position, Quaternion.identity);
            spawnBetweenTime = IntervalBetweenSpawn;
        }
        else
        {
            spawnBetweenTime -= Time.deltaTime;
        }
    }
}
