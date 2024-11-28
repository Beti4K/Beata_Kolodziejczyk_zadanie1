using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
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
        Instantiate(obstacle, new Vector3(Random.Range(-6, 6), 0.2f, Random.Range(-4, 4)), Quaternion.identity);
        StartCoroutine(SpawnCooldown());
    }
}
