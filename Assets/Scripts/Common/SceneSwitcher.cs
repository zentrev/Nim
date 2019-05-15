

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : Singleton<SceneSwitcher>
{
    public enum eSet
    {
        NONE,
        MENU,
        GAME
    }

    [SerializeField] eSet m_curentSet = eSet.NONE;
    [SerializeField] [Range(0, 10)] int m_addFrequency = 4;

    int gameCount = 0;

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

        if(gameCount % m_addFrequency == 0)
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
