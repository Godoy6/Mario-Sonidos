using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;  // Referencia al objeto del jugador
    private float altura = 0f;  // Variable para mantener la altura de la c�mara constante

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x , altura , transform.position.z); // Actualiza la posici�n de la c�mara para que siga al jugador solo en el eje X
    }
}