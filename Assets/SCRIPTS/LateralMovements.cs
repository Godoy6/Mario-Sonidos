using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralMovements : MonoBehaviour
{
    private Rigidbody2D rigBod2D; // Componente Rigidbody2D del jugador para manejar la f�sica
    public float speed = 4.0f; // Velocidad del movimiento lateral del jugador
    private Vector2 direction; // Direcci�n del movimiento del jugador
    public Vector2 posicionInicial; // Posici�n inicial del jugador (para poder reiniciarla)
    public Animator animator; // Componente Animator para controlar las animaciones
    private bool mirarDerecha = true; // Estado que indica si el personaje est� mirando hacia la derecha

    void Start()
    {
        rigBod2D = GetComponent<Rigidbody2D>(); // Obtenemos el componente Rigidbody2D para poder modificar su velocidad
        posicionInicial = transform.position; // Guardamos la posici�n actual como la inicial del jugador
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") , 0); // Detectamos la entrada horizontal del jugador (movimiento hacia izquierda o derecha)
        if (direction.x < 0 && mirarDerecha) // Si el jugador se mueve hacia la izquierda (direcci�n negativa)
        {
            // Cambiar el giro del personaje para mirar a la izquierda
            mirarDerecha = false;
            transform.localScale = new Vector2(-transform.localScale.x , transform.localScale.y); // Invertir el eje X para mirar a la izquierda
        }
        else if (direction.x > 0 && !mirarDerecha) // Si el jugador se mueve hacia la derecha (direcci�n positiva)
        {
            // Cambiar el giro del personaje para mirar a la derecha
            mirarDerecha = true;
            transform.localScale = new Vector2(-transform.localScale.x , transform.localScale.y); // Invertir el eje X para mirar a la derecha
        }
        animator.SetFloat("MOVIMIENTO", Mathf.Abs(rigBod2D.velocity.x) > 0 ? 1 : 0); // Control de animaci�n: si el jugador se est� moviendo, la animaci�n de movimiento se activa
    }

    private void FixedUpdate() // FixedUpdate se llama en intervalos fijos, �til para f�sica y movimientos de Rigidbody
    {
        rigBod2D.velocity = new Vector2(direction.x * speed, rigBod2D.velocity.y); // Actualizamos la velocidad del Rigidbody2D bas�ndonos en la direcci�n y velocidad horizontal
    }

    public void ReiniciarPosicion() // M�todo para reiniciar la posici�n del jugador
    {
        transform.position = posicionInicial;  // Restauramos la posici�n inicial del jugador
    }
}