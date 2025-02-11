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

    private bool mirarDerecha = true;

    void Start()
    {
        rigBod2D = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;  // Guardamos la posición actual como la inicial
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), 0);

        if (direction.x < 0 && mirarDerecha) // Si el jugador se mueve hacia la izquierda (dirección negativa)
        {
            // Cambiar el giro del personaje para mirar a la izquierda

            mirarDerecha = false;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        else if (direction.x > 0 && !mirarDerecha) // Si el jugador se mueve hacia la derecha (dirección positiva)
        {
            // Cambiar el giro del personaje para mirar a la derecha

            mirarDerecha = true;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

        animator.SetFloat("MOVIMIENTO", Mathf.Abs(rigBod2D.velocity.x) > 0 ? 1 : 0); // Animación de movimiento: si el jugador se está moviendo, establecer valor 1, sino 0
    }

    private void FixedUpdate()
    {
        rigBod2D.velocity = new Vector2(direction.x * speed, rigBod2D.velocity.y); // Actualizar la velocidad del jugador basándonos en la dirección y la velocidad

    }

    public void ReiniciarPosicion() // Método para reiniciar la posición del jugador
    {
        transform.position = posicionInicial;  // Restauramos la posición inicial
    }
}