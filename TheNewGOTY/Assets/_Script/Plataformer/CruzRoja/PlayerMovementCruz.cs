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

    // 🔥 POWER UPS
    private PlayerPowerUps powerUps;
    private int saltosUsados = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        powerUps = GetComponent<PlayerPowerUps>();
    }

    void Update()
    {
        if (puntoSuelo == null) return;

        // Detectar suelo
        enSuelo = Physics2D.OverlapCircle(
            puntoSuelo.position,
            radioSuelo,
            capaSuelo
        );

        // Resetear saltos al tocar suelo
        if (enSuelo)
        {
            saltosUsados = 0;
        }

        // Máximo de saltos
        int maxSaltos = 1;
        if (powerUps != null && powerUps.doubleJumpActive)
        {
            maxSaltos = 2;
        }

        // Movimiento (bloqueado si carga salto)
        float mover = 0f;
        if (!cargandoSalto)
        {
            mover = Input.GetAxis("Horizontal");
        }

        rb.velocity = new Vector2(mover * velocidad, rb.velocity.y);

        // Iniciar carga de salto
        if (Input.GetKeyDown(KeyCode.Space) && saltosUsados < maxSaltos)
        {
            cargandoSalto = true;
            fuerzaActual = fuerzaMin;

            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Cargar salto
        if (Input.GetKey(KeyCode.Space) && cargandoSalto)
        {
            fuerzaActual += velocidadCarga * Time.deltaTime;
            fuerzaActual = Mathf.Clamp(fuerzaActual, fuerzaMin, fuerzaMax);
        }

        // Ejecutar salto
        if (Input.GetKeyUp(KeyCode.Space) && cargandoSalto)
        {
            float fuerzaFinal = fuerzaActual;

            // Aplicar boost
            if (powerUps != null && powerUps.jumpBoostActive)
            {
                fuerzaFinal *= 1.5f;
            }

            rb.velocity = new Vector2(rb.velocity.x, fuerzaFinal);

            cargandoSalto = false;
            saltosUsados++;
        }

        // Mejorar caída
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