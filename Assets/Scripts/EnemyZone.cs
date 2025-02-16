using UnityEngine;

public class ZonaSonido : MonoBehaviour
{
    public float probabilidadGrito = 0.2f; // Probabilidad de 20% de reproducir el grito
    public AudioClip gritoClip; // Clip de sonido del grito

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<LateralMovements>()) // Verificamos si el objeto que entra en la zona es el jugador con el script "LateralMovements"
        {
            IntentarReproducirGrito(); // Intentar reproducir el sonido con la probabilidad indicada
        }
    }

    void IntentarReproducirGrito()
    {
        if (Random.value < probabilidadGrito) // Comprobamos si la probabilidad aleatoria es suficiente para reproducir el sonido
        {
            AudioManager.instance.PlayAudio(gritoClip , "Grito" , volume : 100000f); // Llamamos al "AudioManager" para reproducir el clip de sonido del grito
        }
    }
}