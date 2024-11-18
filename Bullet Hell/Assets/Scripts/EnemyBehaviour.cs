using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;         // Referencia al jugador (asignar en el Inspector)
    public float moveSpeed = 3f;     // Velocidad de movimiento hacia el jugador

    void Update()
    {
        MoveTowardsPlayer();
        LookAtPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (player == null) return;

        // Moverse hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void LookAtPlayer()
    {
        if (player == null) return;

        // Calcular la dirección hacia el jugador ignorando el eje Y
        Vector3 direction = (player.position - transform.position);
        direction.y = 0; // Ignorar la diferencia en el eje Y

        // Rotar hacia el jugador en los ejes XZ
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // Gira suavemente hacia el jugador
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "playerBullet"
        if (other.CompareTag("playerBullet"))
        {
            Destroy(other.gameObject); // Destruir la bala del jugador
            Destroy(gameObject);       // Destruir al enemigo
        }
    }
}
