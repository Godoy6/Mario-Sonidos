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

    public AudioSource PlayAudio(AudioClip clip, string gameObjectName, bool isLoop = false, float volume = 1.0f)
    {
        // 1 - Crear EMPTY
        GameObject nObject = new GameObject();

        // 2 - Ponerle NOMBRE
        nObject.name = gameObjectName;

        // 3 - Añadir el audio SOURCE
        AudioSource audioSourceComponent = nObject.AddComponent<AudioSource>();

        // 4 - Arrastrar audio CLIP
        audioSourceComponent.clip = clip;

        // 5 - Seteamos el LOOP
        audioSourceComponent.loop = isLoop;

        // 6 - Regular PROPIEDADES
        audioSourceComponent.volume = volume;

        // 7 - Añadimos el OBJETO a la LISTA
        sounds.Add(audioSourceComponent);

        // 8 - QUE SUENE!!!
        audioSourceComponent.Play();

        // 9 - Cuando deje de SONAR hay que DESTRUIRLO (>performance<)
        StartCoroutine(WaitForAudio(audioSourceComponent));

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