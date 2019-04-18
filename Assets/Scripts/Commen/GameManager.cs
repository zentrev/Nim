using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum eDifficlty
    {
        INVALID,
        EASY,
        NORMAL,
        HARD,
    }

    public int m_nimsObjects = 0;

    public void StartGame(eDifficlty difficulty)
    {
        switch (difficulty)
        {
            case eDifficlty.EASY:
                m_nimsObjects = 6;
                break;
            case eDifficlty.NORMAL:
                m_nimsObjects = 12;
                break;
            case eDifficlty.HARD:
                m_nimsObjects = 187;
                break;
            default:
                Debug.LogError("INVALID DIFFICULTY");
                break;
        }
    }

    public void ChangeObjectCount(int count)
    {
        m_nimsObjects -= count;
    }
}
