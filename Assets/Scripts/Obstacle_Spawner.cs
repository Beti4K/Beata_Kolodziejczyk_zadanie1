using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] int rangeZ;
    [SerializeField] int rangeX;
    void Start()
    {
        StartCoroutine(SpawnCooldown());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(5);
        Instantiate(obstacle, new Vector3(Random.Range(-rangeX, rangeX), 0.53f, Random.Range(-rangeZ, rangeZ)), Quaternion.identity);
        StartCoroutine(SpawnCooldown());
    }
}
