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
    private Animator animator;

    private bool enSuelo;
    private float fuerzaActual;
    private bool cargandoSalto;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (puntoSuelo == null) return;

        // 🔍 Detectar suelo
        enSuelo = Physics2D.OverlapCircle(
            puntoSuelo.position,
            radioSuelo,
            capaSuelo
        );

        // 🎮 Movimiento horizontal
        float mover = 0f;
        if (!cargandoSalto)
        {
            mover = Input.GetAxis("Horizontal");
        }

        rb.velocity = new Vector2(mover * velocidad, rb.velocity.y);

        // 🎬 Animación de movimiento
        bool isMoving = Mathf.Abs(rb.velocity.x) > 0.1f;
        animator.SetBool("IsMoving", isMoving);

        // 🔼🔽 Velocidad vertical
        float velY = rb.velocity.y;
        animator.SetFloat("VelY", velY);

        // 🧪 DEBUG
        Debug.Log("VelocityY: " + velY);

        // 🔄 Voltear personaje
        if (Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            transform.localScale = new Vector3(-Mathf.Sign(rb.velocity.x), 1, 1);
        }

        // ⚡ INICIAR CARGA
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            cargandoSalto = true;
            fuerzaActual = fuerzaMin;

            animator.SetBool("IsCharging", true);

            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // ⚡ CARGANDO
        if (Input.GetKey(KeyCode.Space) && cargandoSalto)
        {
            fuerzaActual += velocidadCarga * Time.deltaTime;
            fuerzaActual = Mathf.Clamp(fuerzaActual, fuerzaMin, fuerzaMax);
        }

        // 🟢 SALTAR
        if (Input.GetKeyUp(KeyCode.Space) && cargandoSalto)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaActual);

            cargandoSalto = false;

            // 🔥 ORDEN CORRECTO
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsCharging", false);
        }

        // 🟫 ATERRIZAJE (CORREGIDO)
        if (enSuelo && rb.velocity.y <= 0)
        {
            animator.SetBool("IsJumping", false);
        }

        // ⬇️ Mejor caída
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