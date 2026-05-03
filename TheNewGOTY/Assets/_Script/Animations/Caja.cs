using System.Collections;
using UnityEngine;

public class Caja : MonoBehaviour
{
    private SpriteRenderer sr;
    private Collider2D col;

    private bool activado = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!activado && collision.gameObject.CompareTag("Player"))
        {
            activado = true;
            StartCoroutine(TitilarYReaparecer());
        }
    }

    IEnumerator TitilarYReaparecer()
    {
        float tiempo = 1f;
        float intervalo = 0.1f;

        // Titilar 2 segundos
        while (tiempo > 0)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(intervalo);
            tiempo -= intervalo;
        }

        // Asegurar que esté visible antes de ocultar
        sr.enabled = true;

        // "Desaparece"
        sr.enabled = false;
        col.enabled = false;

        // Esperar 5 segundos
        yield return new WaitForSeconds(5f);

        // Reaparece
        sr.enabled = true;
        col.enabled = true;

        // Permitir que se active otra vez
        activado = false;
    }
}
