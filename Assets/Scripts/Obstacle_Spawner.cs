using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] int rangeZ;
    [SerializeField] int rangeX;

    private int xValue;
    private int zValue;

    public List<Vector3> positions;
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

        //preventing obstacle from spawning on portal spot
        while (xValue == 0 && zValue == 0)
        {
            xValue = Random.Range(-rangeX, rangeX);
            zValue = Random.Range(-rangeZ, rangeZ);
        }

        //prevents obstacles from stacking
        while (positions.Contains(new Vector3 (xValue, 0.53f, zValue)))
        {
            xValue = Random.Range(-rangeX, rangeX);
            zValue = Random.Range(-rangeZ, rangeZ);
        }

        positions.Add(new Vector3 (xValue, 0.53f, zValue));

        Instantiate(obstacle, new Vector3(xValue, 0.53f, zValue), Quaternion.identity);
        StartCoroutine(SpawnCooldown());
    }
}
