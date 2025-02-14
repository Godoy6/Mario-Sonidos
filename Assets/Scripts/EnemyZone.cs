using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    public AudioClip screamClip; // El clip de audio del grito
    public float screamProbability = 0.5f; // Probabilidad de que suene el grito (50% por defecto)

    // Definimos las esquinas del rect�ngulo vac�o
    public Vector2 zoneMin = new Vector2(-5f, -5f); // Esquina inferior izquierda
    public Vector2 zoneMax = new Vector2(5f, 5f);  // Esquina superior derecha

    private void Update()
    {
        // Verificamos si el jugador est� dentro de la zona rectangular
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
                    Debug.LogError("AudioManager no est� inicializado.");
                }
            }
        }
    }

    // Verifica si el jugador est� dentro del �rea rectangular (sin usar colliders)
    private bool IsPlayerInZone()
    {
        // Aqu� usas la posici�n del jugador (puedes usar cualquier m�todo que defina su posici�n)
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y); // Suponiendo que el jugador tiene este m�todo o usa el transform.position

        // Verificamos si la posici�n del jugador est� dentro del rect�ngulo
        return playerPosition.x >= zoneMin.x && playerPosition.x <= zoneMax.x && playerPosition.y >= zoneMin.y && playerPosition.y <= zoneMax.y;
    }
}