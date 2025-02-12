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

            // Reproducir m�sica de fondo en bucle
            AudioManager.instance.PlayAudio(Audio, "Musica Fondo", isLoop: true);
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