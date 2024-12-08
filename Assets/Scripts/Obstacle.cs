using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Obstacle_Spawner obSpawner;
    private void Start()
    {
        StartCoroutine(WaitForDestroy());
        obSpawner = GameObject.Find("SpawnManager").GetComponent<Obstacle_Spawner>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Movement>().health -= 1;

            //prevents spot from being locked for spawning new obstacle
            obSpawner.positions.Remove(transform.position);

            Destroy(this.gameObject);
        }
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(10);

        //prevents spot from being locked for spawning new obstacle
        obSpawner.positions.Remove(transform.position);

        Destroy(this.gameObject);
    }
}
