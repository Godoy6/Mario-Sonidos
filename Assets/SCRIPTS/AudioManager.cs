using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Instancia estática para implementar el patrón Singleton
    private List<AudioSource> sounds; // Lista para almacenar todos los "AudioSources" activos

    private void Awake()
    {
        if (!instance) // Si no existe una instancia, asignamos esta instancia como la global
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruimos este objeto
        }
    }

    void Start()
    {
        sounds = new List<AudioSource>(); // Inicializamos la lista para almacenar los "AudioSources"
    }

    public AudioSource PlayAudio(AudioClip clip, string gameObjectName, bool isLoop = false, float volume = 1.0f) // Método para reproducir un audio clip
    {
        GameObject nObject = new GameObject(); // 1 - Crear un objeto vacío para alojar el AudioSource
        nObject.name = gameObjectName; // 2 - Asignar un nombre al objeto recién creado
        AudioSource audioSourceComponent = nObject.AddComponent<AudioSource>(); // 3 - Añadir el componente AudioSource al objeto
        audioSourceComponent.clip = clip; // 4 - Asignar el AudioClip al AudioSource
        audioSourceComponent.loop = isLoop; // 5 - Configurar si el audio debe repetirse en bucle
        audioSourceComponent.volume = volume; // 6 - Ajustar el volumen del audio
        sounds.Add(audioSourceComponent); // 7 - Añadir el AudioSource a la lista de sonidos activos
        audioSourceComponent.Play(); // 8 - Reproducir el audio
        StartCoroutine(WaitForAudio(audioSourceComponent)); // 9 - Esperar hasta que el audio termine y destruir el objeto para optimizar el rendimiento
        return audioSourceComponent; // Retorna el "AudioSource" que fue creado
    }

    private IEnumerator WaitForAudio(AudioSource source) // Corutina para esperar a que el audio termine de sonar y luego destruir el objeto
    {
        if (source.loop)
        {
            yield return null; // Si el audio es en bucle, no hacemos nada
        }
        else
        {
            while (source.isPlaying) // Si el audio no es en bucle, esperamos hasta que termine de sonar
            {
                yield return new WaitForSeconds(0.3f); // Esperamos 0.3 segundos antes de comprobar de nuevo
            }
            Destroy(source.gameObject); // Cuando el audio termina, destruimos el objeto para liberar recursos
        }
    }

    void Update()
    {
        
    }
}