using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip Audio;

    void Start()
    {
        if (AudioManager.instance != null)
        {
            Debug.Log("Reproduciendo m�sica de fondo");
            DontDestroyOnLoad(gameObject);

            // Cambiar el par�metro isLoop a true para que se repita la m�sica
            AudioManager.instance.PlayAudio(Audio, "Musica Fondo", true);  // Reproducci�n en bucle
        }
        else
        {
            Debug.LogError("AudioManager no est� inicializado");
        }
    }

    void Update()
    {

    }
}