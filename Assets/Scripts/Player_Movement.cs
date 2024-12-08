using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float speed = 3.0f;
    public int health;
    private int maxHealth;

    public int points = 0;
    public int collectables = 0;

    public bool isGameActive = true;
    public GameObject gameOverScreen;

    [SerializeField] GameObject[] healthIcons;
    private void Start()
    {
        maxHealth = 3;
        health = maxHealth;
        gameOverScreen.SetActive(false);

        for (int i = 0; i < maxHealth; i++)
        {
            healthIcons[i].SetActive(true);
        }
    }

    void Update()
    {
        if (isGameActive)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        }

        if (health <= 0)
        {
            GameOver();
        }

        for (int i = 0; i < maxHealth; i++)
        {
            healthIcons[i].SetActive(false);
        }

        for (int i = 0; i < health; i++)
        {
            healthIcons[i].SetActive(true);
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
    }
}
