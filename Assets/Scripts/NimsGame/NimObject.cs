using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NimObject : MonoBehaviour
{
    [SerializeField] Animator m_animator = null;
    [SerializeField] GameObject m_glow = null;
    public bool m_active { get; set; } = true;
    public bool m_selected { get; set; } = false;

    private void Update()
    {
        if (m_glow) m_glow.SetActive((m_selected) ? true : false);
    }
    public void DeactivateObject()
    {
        if(m_animator) m_animator.SetTrigger("Deselect");
        m_selected = false;
        m_active = false;
    }
}
