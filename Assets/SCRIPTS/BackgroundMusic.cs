using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip Audio;  // Referencia al clip de audio

    void Start()
    {
        if (AudioManager.instance != null)  // Verifica si existe una instancia de "AudioManager"
        {
            DontDestroyOnLoad(gameObject); // Hace que el objeto no se destruya al cargar una nueva escena
            AudioManager.instance.PlayAudio(Audio , "Musica Fondo" , true); // Reproducción en bucle
        }
    }

    void Update()
    {
        
    }
}