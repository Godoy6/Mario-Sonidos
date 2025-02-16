using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rigBod2D; // Variable para almacenar el componente Rigidbody2D del objeto
    public float JumpForce = 3.0f; // Fuerza con la que el jugador saltará
    public float sphereRadius = 0.3f; // Radio de la esfera para detectar el suelo
    private bool isJumping = false; // Estado para saber si el jugador está en pleno salto
    public LayerMask groundMask; // Máscara para verificar si estamos sobre el suelo
    private Animator animator; // Variable para controlar las animaciones
    public AudioClip JumpPlayer; // Sonido del salto
    public AudioClip DeathGoomba; // Sonido cuando el jugador mata al Goomba
    private int value = 10; // Valor de las monedas obtenidas al matar a un Goomba

    void Start()
    {
        rigBod2D = GetComponent<Rigidbody2D>(); // Obtenemos el Rigidbody2D para aplicar fuerzas
        animator = GetComponent<Animator>(); // Obtenemos el componente Animator para controlar las animaciones
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
        if (Input.GetButtonDown("Jump") && IsGrounded()) // Si se presiona el botón de salto y el jugador está en el suelo
        {
            isJumping = true; // Se marca que el jugador está saltando
            animator.Play("JUMPING"); // Reproduce la animación de salto
            AudioManager.instance.PlayAudio(JumpPlayer , "JumpPlayer"); // Reproduce el sonido del salto
        }
        animator.SetBool("isJumping" , !IsGrounded()); // Cambia la animación si el jugador está en el aire o en el suelo
    }

    void ApplyYForce() // Aplica una fuerza hacia arriba para hacer el salto
    {
        if (isJumping) // Si el jugador está saltando
        {
            rigBod2D.AddForce(Vector2.up * JumpForce * rigBod2D.gravityScale , ForceMode2D.Impulse); // Aplica la fuerza hacia arriba
            isJumping = false; // Una vez aplicada la fuerza, se detiene el salto
        }
    }

    private bool IsGrounded() // Verifica si el personaje está tocando el suelo
    {
        Collider2D collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), sphereRadius, groundMask); // Se usa "OverlapCircle" para verificar si hay colisión con el suelo
        return collider != null; // Si hay colisión, devuelve true (está en el suelo)
    }

    private void OnCollisionEnter2D(Collision2D col) // Detecta las colisiones con otros objetos
    {
        MovementIA goombaMovimiento = col.gameObject.GetComponent<MovementIA>(); // Verificamos si el objeto con el que colisionamos tiene el script MovementIA
        if (goombaMovimiento != null)  // Si el Goomba tiene el script MovementIA
        {
            if (transform.position.y > col.transform.position.y)  // Si el jugador está por encima del Goomba
            {
                Destroy(col.gameObject); // Destruir al Goomba si el jugador salta sobre él
                GameManager.instance.AddCoin(value); // Añadir monedas al jugador
                AudioManager.instance.PlayAudio(DeathGoomba, "DeathGoomba"); // Reproducir el sonido de la muerte del Goomba
            }
            else
            {
                Destroy(gameObject); // Si el jugador choca con el Goomba desde el lado, el jugador se destruye
            }
        }
    }
    /*
    private void OnDrawGizmos() // Dibuja una esfera en el editor de Unity para visualizar el radio de detección del suelo
    {
        Gizmos.color = Color.yellow; // Establecemos el color de la esfera
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y), sphereRadius); // Dibujamos la esfera de detección
    }
    */
}