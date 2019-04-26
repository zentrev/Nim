using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : Window
{
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }
}
