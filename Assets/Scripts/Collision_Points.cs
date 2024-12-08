using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Collision_Points : MonoBehaviour
{
    private GameObject player;

    public GameObject scoreText;
    private int score;

    private bool wasHit;

    private void Start()
    {
        player = GameObject.Find("Player");
        wasHit = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!wasHit)
        {
            wasHit = true;

            player.GetComponent<Player_Movement>().points += 1;

            score = player.GetComponent<Player_Movement>().points;

            Debug.Log("Current points: " + score);
            scoreText.GetComponent<TextMeshProUGUI>().text = "Points: " + score;

            this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            this.gameObject.GetComponent<Light>().enabled = true;
        }
    }
}
