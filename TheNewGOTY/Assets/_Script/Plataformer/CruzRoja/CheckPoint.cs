using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject tienda;

    private bool activated = false;

    private void Start()
    {
        if (tienda != null)
            tienda.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            activated = true;

            // Guardar checkpoint (independiente)
            CheckpointManager.instance.SetCheckpoint(transform.position);

            // Resetear items
            ScoreManager.instance.ResetItems();

            // Activar tienda
            if (tienda != null)
                tienda.SetActive(true);

            Debug.Log("Checkpoint activado");
        }
    }
}