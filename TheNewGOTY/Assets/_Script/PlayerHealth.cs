using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealt;
    private int currentHealth;
    private Animator animator;
    private Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealt;
        animator = GetComponent<Animator>();
        UIManager.Instance.UpdateLife(currentHealth);

        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }
    
    IEnumerator GetDamage()
    {
        currentHealth--;
        animator.SetBool("IsDamaged", true);
        Physics2D.IgnoreLayerCollision(3, 6, true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("IsDamaged", false);
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }


    public void ReceibeDamage()
    {
        if (currentHealth > 1)
        {
            StartCoroutine(GetDamage());
            UIManager.Instance.UpdateLife(currentHealth);
        }
        else
        {
            Respawn();
        }
    }


    void Respawn()
    {
        // Resetear vida
        currentHealth = maxHealt;
        UIManager.Instance.UpdateLife(currentHealth);

        // Mover al punto de respawn
        transform.position = respawnPoint.position;

        // Opcional: resetear velocidad
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }


}
