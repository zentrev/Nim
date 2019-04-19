﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NimObject : MonoBehaviour
{
    [SerializeField] Animator m_animator = null;
    [SerializeField] GameObject m_glow = null;
    private bool m_active { get; set; } = true;
    public bool m_selected { get; set; } = false;

    private void Update()
    {
        if(m_selected)
        {
            m_glow.SetActive(true);
        }
    }
    public void DeactivateObject()
    {
        //Need to tell the Animator what state we are activating, and what layer it works on
        m_animator.Play("stateName", layer:3);
        m_active = false;
    }
}
