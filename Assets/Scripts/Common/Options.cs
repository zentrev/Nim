using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : Window
{
    [SerializeField] AudioManager m_audioManager = null;

    public void MuteMusic()
    {
        AudioManager.Instance.MuteMusic();
    }

    public void MuteSFX()
    {
        AudioManager.Instance.MuteSFX();
    }
}
