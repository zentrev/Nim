using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : Window
{
    [SerializeField] AudioManager m_audioManager = null;
    [SerializeField] GameObject panel = null;

    public void MuteMusic()
    {
        //AudioManager.Instance.GetComponent.
    }

    public void Update()
    {
        if (IsActive)
        {
            panel.SetActive(true);

        }
        else
        {
            panel.SetActive(false);
        }
        
    }
}
