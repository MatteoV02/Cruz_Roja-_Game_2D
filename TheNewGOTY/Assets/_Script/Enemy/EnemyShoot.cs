
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //Almacena el objetivo
    public GameObject player;

    // Almacena el prefab de la bala del enemigo
    public GameObject enemyBullet;

    // Almacena la zona desde donde se dispara
    public Transform shootPos;

    // Tiempo entre disparo
    public float timeBetweenShots;
    private float _cooldown;

    // Distancia mínima hacia el player
    public float minDistance;

    // Velocidad de la bala
    public float bulletSpeed;

    private void Start()
    {
        // El cooldown se inicializa en cero
        _cooldown = 0;
    }
    private void Update()
    {
        // Se llama el metodo de ataque
        Attack();
    }

    public void Attack()
    {
        // Si no existe el player no se ejecuta
        if (player == null)
            return;

        // Se guarda la distancia entre el jugador y el enemigo
        float distance = Vector2.Distance(player.transform.position, transform.position);

        // Si ha pasado el cooldown y la distancia entre el player y el
        // enemigo es menor a la variable, se dispara;
        if (distance < minDistance && Time.time > _cooldown)
        {
            Shoot();

            // Se refresca nuevamente ek tiempo de disparo
            _cooldown = Time.time + timeBetweenShots;
        }
    }

    public void Shoot()
    {
        // Se obtiene la direccion hacia el player
        Vector2 direction = (player.gameObject.transform.position - transform.position);

        // Se crea la bala
        GameObject bullet = Instantiate(enemyBullet, shootPos.position, Quaternion.identity, transform);

        // Se le da velocidad a la bala
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;


        SpriteRenderer sr = bullet.GetComponent<SpriteRenderer>();

        if (direction.x < 0)
            sr.flipX = true;
        else
            sr.flipX = false;

            
        if (bullet != null)
        {
            // Si la bala no se ha destruido, la destruye despues de 2 segundos
            Destroy(bullet, 2f);
        }
    }
}
