using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    public Transform player; // Asigna al jugador en el Inspector

    void Update()
    {
        // Asegúrate de que el jugador esté asignado
        if (player != null)
        {
            // Haz que el enemigo mire hacia el jugador
            transform.LookAt(player);
        }
    }
}
