﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public bool IsActive;

    public void ToggleActive()
    {
        IsActive = !IsActive;
    }
}
