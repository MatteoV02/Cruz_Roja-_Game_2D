using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementCruz : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;

    [Header("Salto variable")]
    public float fuerzaMin = 5f;
    public float fuerzaMax = 10f;
    public float velocidadCarga = 10f;

    [Header("Suelo")]
    public Transform puntoSuelo;
    public float radioSuelo = 0.25f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private bool enSuelo;

    private float fuerzaActual;
    private bool cargandoSalto;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (puntoSuelo == null) return;

        // Detección de suelo
        enSuelo = Physics2D.OverlapCircle(
            puntoSuelo.position,
            radioSuelo,
            capaSuelo
        );

        // 🔒 BLOQUEO DE MOVIMIENTO AL CARGAR
        float mover = 0f;
        if (!cargandoSalto)
        {
            mover = Input.GetAxis("Horizontal");
        }

        rb.velocity = new Vector2(mover * velocidad, rb.velocity.y);

        // Iniciar carga
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            cargandoSalto = true;
            fuerzaActual = fuerzaMin;

            // 🔒 Opcional: frenar completamente al empezar a cargar
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Cargar salto
        if (Input.GetKey(KeyCode.Space) && cargandoSalto)
        {
            fuerzaActual += velocidadCarga * Time.deltaTime;
            fuerzaActual = Mathf.Clamp(fuerzaActual, fuerzaMin, fuerzaMax);
        }

        // Saltar
        if (Input.GetKeyUp(KeyCode.Space) && cargandoSalto)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaActual);
            cargandoSalto = false;
        }

        // Mejor caída
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 2.5f * Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    void OnDrawGizmos()
    {
        if (puntoSuelo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(puntoSuelo.position, radioSuelo);
        }
    }
}