using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{
	[SerializeField] Sound[] m_sounds = null;

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
}
