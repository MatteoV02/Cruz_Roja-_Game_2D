using System;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

     private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(Instance);
        }
    }
    
    public void UpdateScore(int score)
    {
        PlayerStats.score += score;
        scoreText.text = "Score: " + PlayerStats.score.ToString();
    }
    public void UpdateLife(int vidaActual)
    {
        healthText.text = "Health: " + vidaActual.ToString();
    }

}
