using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPopUp : Window
{
    [SerializeField] GameObject m_musicCross = null;
    [SerializeField] GameObject m_sFXCross = null;

    private void Start()
    {
        m_musicCross.SetActive(false);
        m_sFXCross.SetActive(false);

    }

    public void ToggleMusic()
    {
        m_musicCross.SetActive(!m_musicCross.activeSelf);
        TestSingleton.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        m_sFXCross.SetActive(!m_sFXCross.activeSelf);
        TestSingleton.Instance.ToggleSFX();
    }
}
