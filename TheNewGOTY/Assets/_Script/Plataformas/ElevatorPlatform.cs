using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private Vector2 pointA;
    [SerializeField] private Vector2 pointB;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 0.5f;

    private Rigidbody2D rb;
    private Vector2 target;
    private float waitCounter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pointA = transform.position;
        target = pointB;
    }

    private void FixedUpdate()
    {
        if (waitCounter > 0)
        {
            waitCounter -= Time.fixedDeltaTime;
            return;
        }

        Vector2 newPosition = Vector2.MoveTowards(
            rb.position,
            target,
            speed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPosition);

        if (Vector2.Distance(rb.position, target) < 0.05f)
        {
            target = target == pointA ? pointB : pointA;
            waitCounter = waitTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pointA, 0.2f);
        Gizmos.DrawSphere(pointB, 0.2f);
        Gizmos.DrawLine(pointA, pointB);
    }
}