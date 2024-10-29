using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_Timer : MonoBehaviour
{
    public GameObject Player;
    public GameObject Timer;
    private float levelTime = 60.0f;

    void Start()
    {
        StartCoroutine(TimePass());
    }
    public IEnumerator TimePass()
    {
        yield return new WaitForSeconds(1);
        if (levelTime <= 0)
        {
            Player.GetComponent<Player_Movement>().isGameActive = false;
        }
        else
        {
            levelTime -= 1.0f;
            Timer.GetComponent<TextMeshProUGUI>().text = "Time: " + levelTime + "s";
            StartCoroutine(TimePass());
        }
    }
}
