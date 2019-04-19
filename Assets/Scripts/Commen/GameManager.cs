using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject m_easyPrefab = null;
    [SerializeField] GameObject m_normalPrefab = null;
    [SerializeField] GameObject m_hardPrefab = null;

    public bool inGame = true;

    public enum eDifficlty
    {
        INVALID,
        EASY,
        NORMAL,
        HARD,
    }

    [HideInInspector]
    public int m_nimsObjects = 0;

    bool playerOnesTurn = true;

    public void StartGame(eDifficlty difficulty)
    {
        switch (difficulty)
        {
            case eDifficlty.EASY:
                m_nimsObjects = 6;
                //gen things
                break;
            case eDifficlty.NORMAL:
                m_nimsObjects = 12;
                //gen things
                break;
            case eDifficlty.HARD:
                m_nimsObjects = 187;
                //gen things
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

    public void EndTurn(int count = 0)
    {
        if(count > 0) ChangeObjectCount(count);
        if(m_nimsObjects <= 0)
        {
            EndGame();
            return;
        }
        playerOnesTurn = !playerOnesTurn;
    }

    private void EndGame()
    {
        if(playerOnesTurn)
        {
            Debug.Log("player one wins...");
        }
        else
        {
            Debug.Log("PLAYER TWO WINS!!!!");
        }

        SceneSwitcher.Instance.LoadScene("Main", SceneSwitcher.eSet.MENU);
    }
}
