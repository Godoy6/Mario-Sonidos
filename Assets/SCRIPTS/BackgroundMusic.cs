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
            Debug.Log("Reproduciendo música de fondo");
            DontDestroyOnLoad(gameObject);

            // Cambiar el parámetro isLoop a true para que se repita la música
            AudioManager.instance.PlayAudio(Audio, "Musica Fondo", true);  // Reproducción en bucle
        }
        else
        {
            Debug.LogError("AudioManager no está inicializado");
        }
    }

    void Update()
    {

    }
}