using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<AudioSource> sounds; // AllSounds

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        sounds = new List<AudioSource>();
    }

    public AudioSource PlayAudio(AudioClip clip,string gameObjectName,bool isLoop = false,float volume = 1.0f)
    {
        GameObject nObject = new GameObject(); // 1 - Crear EMPTY

        nObject.name = gameObjectName; // 2 - Ponerle NOMBRE

        AudioSource audioSourceComponent = nObject.AddComponent<AudioSource>(); // 3 - Añadir el audio SOURCE

        audioSourceComponent.clip = clip; // 4 - Arrastrar audio CLIP

        audioSourceComponent.loop = isLoop; // 5 - Seteamos el LOOP

        audioSourceComponent.volume = volume; // 6 - Regular PROPIEDADES

        sounds.Add(audioSourceComponent); // 7 - Añadimos el OBJETO a la LISTA

        audioSourceComponent.Play(); // 8 - QUE SUENE!!!

        StartCoroutine(WaitForAudio(audioSourceComponent)); // 9 - Cuando deje de SONAR hay que DESTRUIRLO (>performance<)

        return audioSourceComponent;
    }

    private IEnumerator WaitForAudio(AudioSource source)
    {
        if (source.loop)
        {
            yield return null;
        }
        else
        {
            while (source.isPlaying)
            {
                yield return new WaitForSeconds(0.3f);
            }
            Destroy(source.gameObject); // Cuando el audio deja de sonar lo DESTRUIMOS
        }
    }

    void Update()
    {

    }
}