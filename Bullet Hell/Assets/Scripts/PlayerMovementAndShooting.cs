using UnityEngine;

public class PlayerMovementAndShooting : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad constante
    public float slowSpeed = 2f;     // Velocidad cuando se presiona Shift
    public GameObject bulletPrefab;  // Prefab del proyectil
    public Transform bulletSpawnPoint; // Punto desde donde se disparan las balas
    public float bulletSpeed = 10f;  // Velocidad de las balas
    public int life = 3;

    private float currentSpeed;      // Velocidad actual del jugador

    void Update()
    {
        // Movimiento del jugador
        HandleMovement();

        // Disparo con barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void HandleMovement()
    {
        // Detectar si Shift está presionado para ajustar la velocidad
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? slowSpeed : moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        // Movimiento instantáneo en los ejes
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) movement += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) movement += Vector3.back;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right;

        // Normalizar para evitar movimiento más rápido en diagonal
        if (movement != Vector3.zero)
        {
            movement = movement.normalized * currentSpeed * Time.deltaTime;
        }

        // Aplicar movimiento
        transform.Translate(movement, Space.World);
    }

    private void Shoot()
    {
        // Instanciar la bala en el punto de disparo con la rotación actual del jugador
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Aplicar velocidad a la bala si tiene un Rigidbody
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.linearVelocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletTrigger")){
            life -= 1;
        }
    }
}
