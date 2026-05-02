using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayCoin();
            UIManager.Instance.UpdateScore(coinValue);
            Debug.Log(PlayerStats.score);
            Destroy(gameObject);
        }
    }
}
