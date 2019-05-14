﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : Singleton<SceneSwitcher>
{
    int gameCount = 0;
    public enum eSet
    {
        NONE,
        MENU,
        GAME
    }

    [SerializeField] eSet m_curentSet = eSet.NONE;
    public eSet CurentSet { get => m_curentSet; set => m_curentSet = value; }

    public void SetSet(eSet set)
    {
        CurentSet = set;
    }

    void Update()
    {
        switch (CurentSet)
        {
            case eSet.NONE:
                break;
            case eSet.MENU:
                break;
            case eSet.GAME:
                break;
            default:
                break;
        }

        if(gameCount < 8)
        {
            AdScript adStuff = GameObject.FindObjectOfType<AdScript>();
            adStuff.ShowAd();
        }
    }

    public void LoadScene(string level, eSet set = eSet.GAME)
    {
        m_curentSet = set;
        SceneManager.LoadScene(level, LoadSceneMode.Single);
        gameCount++;
    }

    public void LoadScene(int level, eSet set = eSet.GAME)
    {
        m_curentSet = set;
        SceneManager.LoadScene(level, LoadSceneMode.Single);
        gameCount++;
    }
}
