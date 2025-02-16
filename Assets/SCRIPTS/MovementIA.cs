using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovementIA : MonoBehaviour
{
    private GameObject target; // Objeto que representar� al objetivo que sigue la IA
    public float speed = 1.1f; // Velocidad a la que la IA se mover� hacia el objetivo

    void Start()
    {
        target = FindObjectOfType<LateralMovements>().gameObject; // Encontramos el objeto que tiene el script "LateralMovements" (el jugador) y lo asignamos como objetivo
    }

    void Update()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position , new Vector2(target.transform.position.x , transform.position.y) , speed * Time.deltaTime); // Calculamos la nueva posici�n de la IA movi�ndose hacia el objetivo en el eje X, manteniendo su misma posici�n Y
        transform.position = newPosition; // Actualizamos la posici�n de la IA para moverla hacia la nueva posici�n calculada
    }
}