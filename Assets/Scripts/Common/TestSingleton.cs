using UnityEngine.Audio;
using UnityEngine;
using System;

public class TestSingleton : Singleton<TestSingleton>
{
    [SerializeField] Sound[] m_sounds = null;
    [SerializeField] AudioMixerGroup m_music = null;
    [SerializeField] AudioMixerGroup m_sfx = null;


    public override void Awake()
    {
        base.Awake();
        foreach (Sound sound in m_sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.outputAudioMixerGroup = sound.audioMixerGroup;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
        Play("Music");
        Play("BadMusic");
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(m_sounds, s => s.name == name);
        if (sound.playing == true)
        {
            if (sound != null)
            {
                sound.audioSource.Play();
            }
        }
    }

    public void ToggleMusic()
    {
        for (int i = 0; i < m_sounds.Length; i++)
        {
            if (m_sounds[i].name == "Music")
            {
                if (m_sounds[i].playing == false)
                {
                    m_sounds[i].playing = true;
                    m_sounds[i].audioSource.UnPause();
                    Debug.Log("vol set to 1");
                }
                else
                {
                    m_sounds[i].playing = false;
                    m_sounds[i].audioSource.Pause();
                    Debug.Log("vol set to 0");
                }
            }
        }

    }

    public void ToggleSFX()
    {
        for (int i = 0; i < m_sounds.Length; i++)
        {
            if (m_sounds[i].name == "SoundFX")
            {
                if (m_sounds[i].playing == false)
                {
                    m_sounds[i].playing = true;
                    Debug.Log("sfx set to 100");
                }
                else
                {
                    m_sounds[i].playing = false;
                    Debug.Log("sfx set to 0");
                }
            }
        }
    }
}
