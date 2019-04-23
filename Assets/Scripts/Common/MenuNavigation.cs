﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] GameObject PlayerCountMenu = null;
    [SerializeField] GameObject OptionsMenu = null;
    [SerializeField] GameObject SinglePlayerMenu = null;
    [SerializeField] GameObject MultiplayerPlayerMenu = null;

    public void EnablePlayerSelect()
    {
        PlayerCountMenu.SetActive(true);
    }

    public void EnableMenuOptions()
    {
        OptionsMenu.SetActive(true);
    }

    public void CloseMenuOptions()
    {
        OptionsMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void EnableSingleMenu()
    {
        SinglePlayerMenu.SetActive(true);
        PlayerCountMenu.SetActive(false);
    }

    public void CloseSingleMenu()
    {
        SinglePlayerMenu.SetActive(false);
        PlayerCountMenu.SetActive(true);
    }

    public void EnableMultiMenu()
    {
        MultiplayerPlayerMenu.SetActive(true);
        PlayerCountMenu.SetActive(false);
    }

    public void CloseMultiMenu()
    {
        MultiplayerPlayerMenu.SetActive(false);
        PlayerCountMenu.SetActive(true);
    }

    public void StartGame()
    {

    }
}
