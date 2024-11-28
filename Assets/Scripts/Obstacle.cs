using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitForDestroy());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Movement>().health -= 1;
            Destroy(this.gameObject);
        }
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
