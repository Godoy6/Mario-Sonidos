using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    public AudioClip screamClip; // El clip de audio del grito
    public float screamProbability = 0.5f; // Probabilidad de que suene el grito (50% por defecto)

    // Definimos las esquinas del rectángulo vacío
    public Vector2 zoneMin = new Vector2(-5f, -5f); // Esquina inferior izquierda
    public Vector2 zoneMax = new Vector2(5f, 5f);  // Esquina superior derecha

    private void Update()
    {
        // Verificamos si el jugador está dentro de la zona rectangular
        if (IsPlayerInZone())
        {
            // Generamos un valor aleatorio entre 0 y 1
            float randomValue = Random.value;

            // Si el valor aleatorio es menor que la probabilidad, reproducimos el grito
            if (randomValue < screamProbability)
            {
                // Reproducir el grito utilizando el AudioManager
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.PlayAudio(screamClip, "Enemy Scream");
                }
                else
                {
                    Debug.LogError("AudioManager no está inicializado.");
                }
            }
        }
    }

    // Verifica si el jugador está dentro del área rectangular (sin usar colliders)
    private bool IsPlayerInZone()
    {
        // Aquí usas la posición del jugador (puedes usar cualquier método que defina su posición)
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y); // Suponiendo que el jugador tiene este método o usa el transform.position

        // Verificamos si la posición del jugador está dentro del rectángulo
        return playerPosition.x >= zoneMin.x && playerPosition.x <= zoneMax.x && playerPosition.y >= zoneMin.y && playerPosition.y <= zoneMax.y;
    }
}