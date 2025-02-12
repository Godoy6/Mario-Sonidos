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

            // Reproducir música de fondo en bucle
            AudioManager.instance.PlayAudio(Audio, "Musica Fondo", isLoop: true);
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