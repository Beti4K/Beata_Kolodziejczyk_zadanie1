using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Vector3 startScale;
    private Vector3 maxScale;

    private float step;

    private bool increasing;

    [SerializeField] GameObject winScreen;
    void Start()
    {
        startScale = transform.localScale;
        maxScale = new Vector3(1.7f, 0.03f, 1.7f);

        step = 0.001f;

        increasing = true;
    }

    void Update()
    {
        if (increasing)
        {
            transform.localScale += new Vector3(step, 0, step);
        }
        else
        {
            transform.localScale -= new Vector3(step, 0, step);
        }

        if (transform.localScale.x >= maxScale.x)
        {
            increasing = false;
        }

        if (transform.localScale.x < startScale.x)
        {
            increasing = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winScreen.SetActive(true);
            other.gameObject.GetComponent<Player_Movement>().isGameActive = false;
        }
    }
}
