using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;        // Velocidad del proyectil
    public float lifetime = 5f;     // Tiempo antes de destruir el proyectil
    public float speedReduction = 0.5f;
    


    private void Start()
    {
        // Destruir el proyectil automáticamente después del tiempo de vida
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (speed > 0.5)
        {
            speed -= speedReduction * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Opcional: Lógica para colisiones
        if (other.CompareTag("Player"))
        {
            // Aquí puedes implementar daño al jugador o efectos adicionales
            Destroy(gameObject);
        }
    }
}
