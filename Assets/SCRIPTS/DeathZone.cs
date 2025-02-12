using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public AudioClip Audio;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        LateralMovements lateralMovements = other.GetComponent<LateralMovements>(); // Verificar si el objeto tiene el componente LateralMovements

        if (lateralMovements != null) // Si el jugador tiene el script LateralMovements
        {
            lateralMovements.ReiniciarPosicion(); // Reiniciar la posición del jugador llamando el método de LateralMovements

            AudioManager.instance.PlayAudio(Audio, "Roblox Death");
        }
    }
}