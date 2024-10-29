using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision_Points : MonoBehaviour
{
    public GameObject player;
    private int score;

    private void OnCollisionEnter(Collision collision)
    {
        player.GetComponent<Player_Movement>().points += 1;

        score = player.GetComponent<Player_Movement>().points;

        Debug.Log("Current points: " + score);

        this.gameObject.GetComponent<Renderer>().material.color = new Color32(Random.Range(0, 256).ConvertTo<byte>(), Random.Range(0, 256).ConvertTo<byte>(), Random.Range(0, 256).ConvertTo<byte>(), 255);
    }
    
}
