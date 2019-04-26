using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
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
	}

	public void Play(string name)
	{
		Sound sound = Array.Find(m_sounds, s => s.name == name);
		if (sound != null)
		{
			sound.audioSource.Play();
		}
	}

    public void ToggleMusic()
    {
        m_music.audioMixer.GetFloat("Music", out float current);
        Debug.Log(current);
        if(current == 0)
        {
            m_music.audioMixer.SetFloat("Music", 100);
            Debug.Log("music at 100");
        }
        else if(current == 100)
        {
            m_music.audioMixer.SetFloat("Music", 0);
            Debug.Log("music at 0");
        }
    }

    public void ToggleSFX()
    {
        m_sfx.audioMixer.GetFloat("SoundFX", out float current);
        if (current == 0)
        {
            m_sfx.audioMixer.SetFloat("SoundFX", 100);
            Debug.Log("SFX at 100");
        }
        else if (current == 100)
        {
            m_sfx.audioMixer.SetFloat("SoundFX", 0);
            Debug.Log("SFX at 0");
        }
    }
}
