using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;  // Referencia al transform del jugador
    private float altura = 0f; // Altura de la c�mara, ajusta seg�n sea necesario

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x,altura,transform.position.z); // La c�mara solo sigue al jugador en el eje X y mantiene la misma altura en el eje Y
    }
}