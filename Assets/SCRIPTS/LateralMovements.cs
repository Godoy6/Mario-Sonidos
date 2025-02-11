using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralMovements : MonoBehaviour
{
    private Rigidbody2D rigBod2D;
    public float speed = 4.0f;
    private Vector2 direction;

    public Vector2 posicionInicial;  // Posición inicial del jugador

    public Animator animator;


    void Start()
    {
        rigBod2D = GetComponent<Rigidbody2D>();

        posicionInicial = transform.position;  // Guardamos la posición actual como la inicial
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), 0);
        animator.SetFloat("MOVIMIENTO", rigBod2D.velocity.magnitude); // ERROR
    }

    private void FixedUpdate()
    {
        rigBod2D.velocity = new Vector2(direction.x * speed, rigBod2D.velocity.y);
    }

    public void ReiniciarPosicion() // Método para reiniciar la posición del jugador
    {
        transform.position = posicionInicial;  // Restauramos la posición inicial
    }
}