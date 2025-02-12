using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rigBod2D; // Variable para almacenar el componente Rigidbody2D del objeto
    public float JumpForce = 3.0f; // Fuerza con la que Mario saltará
    public float sphereRadius = 0.3f; // Radio de la esfera para detectar el suelo
    private bool isJumping = false; // Estado para saber si Mario está en pleno salto
    public LayerMask groundMask; // Máscara para verificar si estamos sobre el suelo
    private Animator animator;

    public AudioClip Audio;


    void Start()
    {
        rigBod2D = GetComponent<Rigidbody2D>(); // Obtenemos el Rigidbody2D para aplicar fuerzas
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Jumping(); // Llamamos a la función de salto
    }

    private void FixedUpdate() // FixedUpdate se llama en intervalos fijos, útil para física y movimientos de Rigidbody
    {
        ApplyYForce(); // Aplicamos la fuerza de salto en el eje Y
    }

    void Jumping() // Función que detecta si el jugador presiona el botón de salto y si está en el suelo
    {
        if (Input.GetButtonDown("Jump") && IsGrounded()) // Si se presiona el botón de salto y Mario está en el suelo
        {
            isJumping = true; // Se marca que Mario está saltando
            // animator.SetBool("isJumping", true);
            animator.Play("JUMPING");

            AudioManager.instance.PlayAudio(Audio, "Mario Jump");
        }

        animator.SetBool("isJumping", !IsGrounded());
    }

    void ApplyYForce() // Aplica una fuerza hacia arriba para hacer el salto
    {
        if (isJumping) // Si Mario está saltando
        {
            rigBod2D.AddForce(Vector2.up * JumpForce * rigBod2D.gravityScale, ForceMode2D.Impulse); // Aplica la fuerza hacia arriba
            isJumping = false; // Una vez aplicada la fuerza, se detiene el salto
        }
    }

    private bool IsGrounded() // Verifica si el personaje está tocando el suelo
    {
        Collider2D collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), sphereRadius, groundMask); // Se usa OverlapCircle para verificar si hay colisión con el suelo
        return collider != null; // Si hay colisión, devuelve true (está en el suelo)
    }

    /*
    private void OnDrawGizmos() // Dibuja una esfera en el editor de Unity para visualizar el radio de detección del suelo
    {
        Gizmos.color = Color.yellow; // Establecemos el color de la esfera
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y), sphereRadius); // Dibujamos la esfera de detección
    }
    */

    private void OnCollisionEnter2D(Collision2D col) // Detecta las colisiones con otros objetos
    {
        MovementIA goombaMovimiento = col.gameObject.GetComponent<MovementIA>(); // Verificamos si el objeto con el que colisionamos tiene el script MovementIA

        if (goombaMovimiento != null)  // Si el Goomba tiene el script MovementIA
        {
            // Verificamos si Mario colisionó desde arriba

            if (transform.position.y > col.transform.position.y)  // Mario está por encima del Goomba
            {
                Destroy(col.gameObject); // Destruir al Goomba si Mario salta sobre él
            }
            else
            {
                Destroy(gameObject); // Si Mario choca con el Goomba desde el lado, Mario se destruye
            }
        }
    }
}