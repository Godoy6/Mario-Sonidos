using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovementIA : MonoBehaviour
{
    private GameObject target; // Objeto que representará al objetivo que sigue la IA
    public float speed = 1.1f; // Velocidad a la que la IA se moverá hacia el objetivo

    void Start()
    {
        target = FindObjectOfType<LateralMovements>().gameObject; // Encontramos el objeto que tiene el script "LateralMovements" (el jugador) y lo asignamos como objetivo
    }

    void Update()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position , new Vector2(target.transform.position.x , transform.position.y) , speed * Time.deltaTime); // Calculamos la nueva posición de la IA moviéndose hacia el objetivo en el eje X, manteniendo su misma posición Y
        transform.position = newPosition; // Actualizamos la posición de la IA para moverla hacia la nueva posición calculada
    }
}