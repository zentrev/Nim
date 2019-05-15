using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{
	[SerializeField] Sound[] m_sounds = null;
    [SerializeField] AudioMixerGroup m_music = null;
    [SerializeField] AudioMixerGroup m_sfx = null;

    //[SerializeField] GameObject m_MusicCrossOut = null;
    //[SerializeField] GameObject m_SFXCrossOut = null;

    bool firstLoading = true;

	public override void Awake()
	{
        base.Awake();
        if (firstLoading)
        {
            foreach (Sound sound in m_sounds)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();
                sound.audioSource.clip = sound.audioClip;
                sound.audioSource.outputAudioMixerGroup = sound.audioMixerGroup;
                sound.audioSource.volume = sound.volume;
                sound.audioSource.pitch = sound.pitch;
                sound.audioSource.loop = sound.loop;
            }
            firstLoading = false;
        }

        foreach(Sound sound in m_sounds)
        {
            sound.audioSource.Stop();

            if(sound.name == "Music")
            {
                sound.audioSource.Play();
            }

            if (sound.name == "BadMusic")
            {
                sound.audioSource.Play();
            }
            
        }

        //m_MusicCrossOut.SetActive(false);
        //m_SFXCrossOut.SetActive(false);
    }

    public void Play(string name)
	{
		Sound sound = Array.Find(m_sounds, s => s.name == name);
        if (sound.playing != true)
        {
            if (sound != null)
            {
                sound.audioSource.Play();
            }
        }
	}

    public void ToggleMusic()
    {
        foreach (Sound sound in m_sounds)
        {
            if (sound.name == "Music")
            {
                if (sound.playing == false)
                {
                    sound.playing = true;
                    sound.audioSource.UnPause();
                    //m_MusicCrossOut.SetActive(false);
                }
                else
                {
                    sound.playing = false;
                    sound.audioSource.Pause();
                    //m_MusicCrossOut.SetActive(true);
                }
            }
        }
    }

    public void ToggleSFX()
    {
        foreach(Sound sound in m_sounds)
        {
            if(sound.name == "SoundFX")
            {
                if(sound.playing == false)
                {
                    sound.playing = true;
                    //m_SFXCrossOut.SetActive(false);
                }
                else
                {
                    sound.playing = false;
                    //m_SFXCrossOut.SetActive(true);
                }
            }
        }
    }
}
