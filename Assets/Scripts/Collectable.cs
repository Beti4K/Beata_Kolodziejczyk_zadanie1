using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectable : MonoBehaviour
{
    private bool isPlayerNear = false;

    private Vector3 playerPosition;
    private Vector3 collectablePosition;

    private float speed = 1;

    [SerializeField] GameObject finds;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Player_Movement>().collectables += 1;

            Debug.Log("Current collectables: " + collision.gameObject.GetComponent<Player_Movement>().collectables);
            finds.GetComponent<TextMeshProUGUI>().text = "Collectables: " + collision.gameObject.GetComponent<Player_Movement>().collectables;
        }
    }
    void Update()
    {
        transform.Rotate(new Vector3 (0.1f, 0.1f, 0.1f), Space.Self);

        if (isPlayerNear)
        {
            playerPosition = GameObject.Find("Player").transform.position;
            collectablePosition = transform.position;

            transform.position = Vector3.MoveTowards(collectablePosition, playerPosition, speed*Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3 (0, 0, 0), speed*Time.deltaTime);
        }
    }
}
