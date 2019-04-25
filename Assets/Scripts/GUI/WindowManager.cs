using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : Singleton<WindowManager>
{
    Queue<Window> m_windows = new Queue<Window>();

    public void AddWindow(Window window, bool deactivateLast = true)
    {
        if (deactivateLast && m_windows.Count > 0) m_windows.Peek().SetDeactive();

        m_windows.Enqueue(window);
        window.SetActive();
        if (SceneSwitcher.Instance.CurentSet == SceneSwitcher.eSet.GAME) GameManager.Instance.inGame = false;
    }

    public void RemoveWindow()
    {
        Window windino = m_windows.Dequeue();
        windino.SetDeactive();
        if(m_windows.Count > 0)
        {
            m_windows.Peek().SetActive();
        }
        else if (SceneSwitcher.Instance.CurentSet == SceneSwitcher.eSet.GAME)
        {
            GameManager.Instance.inGame = true;
        }
    }
}
