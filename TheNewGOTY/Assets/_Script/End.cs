using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Como están en el mismo objeto:
        gameManager = GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            gameManager.EndGame();
        }
    }
}