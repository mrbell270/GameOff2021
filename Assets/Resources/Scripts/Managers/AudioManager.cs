using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public c_AudioClip[] audioClips;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(c_AudioClip ac in audioClips)
        {
            GameObject audioSourceObject = new GameObject(ac.name ??= "New AudioClip");
            audioSourceObject.transform.SetParent(transform);
            ac.source = audioSourceObject.AddComponent<AudioSource>();
            ac.source.clip = ac.clip;
            ac.source.playOnAwake = ac.playOnAwake;
            ac.source.volume = ac.volume;
            ac.source.pitch = ac.pitch;
            ac.source.loop = ac.loop;
            ac.source.outputAudioMixerGroup = ac.mixerGroup;
        }
    }

    private void Start()
    {
        foreach(c_AudioClip ac in audioClips)
        {
            if(ac.playOnAwake) ac.source.Play();
        }
    }

    public void PlayClip(string name)
    {
        c_AudioClip ac = Array.Find(audioClips, audioClip => audioClip.name == name);
        if (ac == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        if ((!ac.source.isPlaying) && (ac.source.time != 0))
        {
            ac.source.UnPause();
        }
        else
        {
            ac.source.Play();
        }
    }

    public void PlayClip(int idx)
    {
        if (idx >= audioClips.Length)
        {
            Debug.LogWarning("There is no " + idx + " sound!");
            return;
        }
        if ((!audioClips[idx].source.isPlaying) && (audioClips[idx].source.time != 0))
        {
            audioClips[idx].source.UnPause();
        }
        else
        {
            audioClips[idx].source.Play();
        }
    }

    public void PauseClip(string name)
    {
        c_AudioClip ac = Array.Find(audioClips, audioClip => audioClip.name == name);
        if (ac == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        ac.source.Pause();
    }

    public void PauseClip(int idx)
    {
        if (idx >= audioClips.Length)
        {
            Debug.LogWarning("There is no " + idx + " sound!");
            return;
        }
        audioClips[idx].source.Pause();
    }

    public void StopClip(string name)
    {
        c_AudioClip ac = Array.Find(audioClips, audioClip => audioClip.name == name);
        if (ac == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        ac.source.Stop();
    }

    public void StopClip(int idx)
    {
        if (idx >= audioClips.Length)
        {
            Debug.LogWarning("There is no " + idx + " sound!");
            return;
        }
        audioClips[idx].source.Stop();
    }

    public void PauseAll()
    {
        foreach (c_AudioClip ac in audioClips)
        {
            if (!ac.unpausable)
            {
                ac.source.Pause();
            }
        }
    }

    public void PauseAllForce()
    {
        foreach (c_AudioClip ac in audioClips)
        {
            ac.source.Pause();
        }
    }

    public void ResumeAll()
    {
        foreach (c_AudioClip ac in audioClips)
        {
            if ((!ac.source.isPlaying) && (ac.source.time != 0))
            {
                ac.source.UnPause();
            }
        }
    }

    public void StopAll()
    {
        foreach (c_AudioClip ac in audioClips)
        {
            ac.source.Stop();
        }
    }
}
