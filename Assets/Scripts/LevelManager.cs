using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Player_Movement player;
    [SerializeField] GameObject portal;

    [SerializeField] GameObject[] points;

    [SerializeField] GameObject message;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player_Movement>();
    }

    void Update()
    {
        if (player.points == points.Length)
        {
            message.SetActive(true);
            portal.SetActive(true);
        }
    }
}
