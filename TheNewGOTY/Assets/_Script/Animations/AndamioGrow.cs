using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndamioGrow : MonoBehaviour
{

    public Transform parteQueCrece;
    public float velocidad = 2f;
    public float maxAltura = 3f;

    private Vector3 escalaInicial;
    private bool creciendo = false;

    // Start is called before the first frame update
    void Start()
    {
        escalaInicial = parteQueCrece.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (creciendo)
        {
            Vector3 escala = parteQueCrece.localScale;
            escala.y += velocidad * Time.deltaTime;
            escala.y = Mathf.Clamp(escala.y, escalaInicial.y, maxAltura);
            parteQueCrece.localScale = escala;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            creciendo = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            creciendo = false;
        }
    }



}
