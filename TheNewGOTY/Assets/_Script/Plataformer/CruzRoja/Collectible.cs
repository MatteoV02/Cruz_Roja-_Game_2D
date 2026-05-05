using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public ItemType type;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Algo entro: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado");
            ScoreManager.instance.AddItem(type);
            Destroy(gameObject);
        }
    }
}