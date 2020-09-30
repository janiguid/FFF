using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] Sound[] sounds;
    AudioSource source;

    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        if(source == null)
        {
            if(TryGetComponent<AudioSource>(out source) == false)
            {
                source = gameObject.AddComponent<AudioSource>();
            }
        }     
    }


    public void PlayAudio(string name)
    {
        if (source.isPlaying)
        {
            return;
        }

        source.volume = 1;
        if (source)
        {
            foreach(Sound s in sounds)
            {
                if(s.SoundName == name)
                {
                    source.clip = s.audio;
                    source.Play();
                    return;
                }
            }
        }

        return;
    }

    public void StopAudio()
    {
        StartCoroutine(EndSound());
    }

    IEnumerator EndSound()
    {
        if (source == null) yield return null;
        while(source.volume != 0)
        {
            source.volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }

        print("ended coroutine");
        source.Stop();
        yield return null;
    }

    public bool IsPlaying()
    {
        return source.isPlaying;
    }
}
