using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public AudioClip Audio; // El clip de audio que se reproduce cuando el jugador entra en la zona de muerte

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) // M�todo que se ejecuta cuando otro objeto entra en el �rea del trigger de esta zona
    {
        LateralMovements lateralMovements = other.GetComponent<LateralMovements>(); // Intentamos obtener el componente "LateralMovements" del objeto que colisiona
        if (lateralMovements != null) // Si el objeto que colisiona es el jugador
        {
            lateralMovements.ReiniciarPosicion(); // Llamamos al m�todo para reiniciar la posici�n del jugador
            AudioManager.instance.PlayAudio(Audio , "Death Zone"); // Reproducimos el sonido de muerte
        }
    }
}