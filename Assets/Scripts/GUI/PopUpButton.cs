using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour
{
    [SerializeField] Window m_window = null;

    public void PopUpWindow()
    {
        WindowManager.Instance.AddWindow(m_window);
    }
}
