using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;  // Referencia al transform del jugador
    private float altura = 0f; // Altura de la cámara, ajusta según sea necesario

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x,altura,transform.position.z); // La cámara solo sigue al jugador en el eje X y mantiene la misma altura en el eje Y
    }
}