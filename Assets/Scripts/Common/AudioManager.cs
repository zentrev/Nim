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


	public override void Awake()
	{
        base.Awake();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
=======
>>>>>>> parent of 68f5ba1... fixes to AudioManager
=======
>>>>>>> parent of 68f5ba1... fixes to AudioManager
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
        m_MusicCrossOut.SetActive(false);
        m_SFXCrossOut.SetActive(false);
>>>>>>> parent of 68f5ba1... fixes to AudioManager
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
        //m_music.audioMixer.GetFloat("Music", out float current);
        //Debug.Log(current);
        //if(current == 0)
        //{
        //    m_music.audioMixer.SetFloat("Music", 100);
        //    Debug.Log("music at 100");
        //}
        //else if(current == 100)
        //{
        //    m_music.audioMixer.SetFloat("Music", 0);
        //    Debug.Log("music at 0");
        //}

        for(int i = 0; i < m_sounds.Length; i++)
        {
            if(m_sounds[i].name == "Music")
            {
                if(m_sounds[i].playing == false)
                {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                    sound.playing = true;
                    sound.audioSource.UnPause();
                    //m_MusicCrossOut.SetActive(false);
                }
                else
                {
                    sound.playing = false;
                    sound.audioSource.Pause();
                    //m_MusicCrossOut.SetActive(true);
=======
                    m_sounds[i].playing = true;
                    m_sounds[i].audioSource.Play();
                    m_MusicCrossOut.SetActive(false);
                    Debug.Log("vol set to 1");
                }
                else
                {
=======
                    m_sounds[i].playing = true;
                    m_sounds[i].audioSource.Play();
                    m_MusicCrossOut.SetActive(false);
                    Debug.Log("vol set to 1");
                }
                else
                {
>>>>>>> parent of 68f5ba1... fixes to AudioManager
=======
                    m_sounds[i].playing = true;
                    m_sounds[i].audioSource.Play();
                    m_MusicCrossOut.SetActive(false);
                    Debug.Log("vol set to 1");
                }
                else
                {
>>>>>>> parent of 68f5ba1... fixes to AudioManager
                    m_sounds[i].playing = false;
                    m_sounds[i].audioSource.Stop();
                    m_MusicCrossOut.SetActive(true);
                    Debug.Log("vol set to 0");
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 68f5ba1... fixes to AudioManager
=======
>>>>>>> parent of 68f5ba1... fixes to AudioManager
=======
>>>>>>> parent of 68f5ba1... fixes to AudioManager
                }
            }
        }

    }

    public void ToggleSFX()
    {
        //m_sfx.audioMixer.GetFloat("SoundFX", out float current);
        //if (current == 0)
        //{
        //    m_sfx.audioMixer.SetFloat("SoundFX", 100);
        //    Debug.Log("SFX at 100");
        //}
        //else if (current == 100)
        //{
        //    m_sfx.audioMixer.SetFloat("SoundFX", 0);
        //    Debug.Log("SFX at 0");
        //}

        for (int i = 0; i < m_sounds.Length; i++)
        {
            if (m_sounds[i].name == "SoundFX")
            {
                if (m_sounds[i].playing == false)
                {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                    sound.playing = true;
                    //m_SFXCrossOut.SetActive(false);
                }
                else
                {
                    sound.playing = false;
                    //m_SFXCrossOut.SetActive(true);
=======
                    m_sounds[i].playing = true;
                    m_SFXCrossOut.SetActive(false);
                    Debug.Log("sfx set to 100");
                }
                else
                {
                    m_sounds[i].playing = false;
                    m_SFXCrossOut.SetActive(true);
                    Debug.Log("sfx set to 0");
>>>>>>> parent of 68f5ba1... fixes to AudioManager
=======
                    m_sounds[i].playing = true;
                    m_SFXCrossOut.SetActive(false);
                    Debug.Log("sfx set to 100");
                }
                else
                {
                    m_sounds[i].playing = false;
                    m_SFXCrossOut.SetActive(true);
                    Debug.Log("sfx set to 0");
>>>>>>> parent of 68f5ba1... fixes to AudioManager
=======
                    m_sounds[i].playing = true;
                    m_SFXCrossOut.SetActive(false);
                    Debug.Log("sfx set to 100");
                }
                else
                {
                    m_sounds[i].playing = false;
                    m_SFXCrossOut.SetActive(true);
                    Debug.Log("sfx set to 0");
>>>>>>> parent of 68f5ba1... fixes to AudioManager
                }
            }
        }
    }
}
