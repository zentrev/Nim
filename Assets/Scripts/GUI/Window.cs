using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public bool IsActive;

    public void ToggleActive()
    {
        IsActive = !IsActive;
        gameObject.SetActive(IsActive);
    }

    public void SetActive()
    {
        IsActive = true;
        gameObject.SetActive(IsActive);
    }

    public void SetDeactive()
    {
        IsActive = false;
        gameObject.SetActive(IsActive);
    }

    public void Return()
    {
        WindowManager.Instance.RemoveWindow();
    }

    private void Start()
    {
        SetDeactive();
    }
}
