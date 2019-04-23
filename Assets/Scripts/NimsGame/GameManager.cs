using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum eDifficulty
    {
        INVALID,
        EASY,
        NORMAL,
        HARD,
    }

    [SerializeField] GameOptions gameOptions = null;

    [SerializeField] GameObject m_easyPrefab = null;
    [SerializeField] GameObject m_normalPrefab = null;
    [SerializeField] GameObject m_hardPrefab = null;

    public int m_nimsObjects = 0;
    public bool inGame = true;

    bool playerOnesTurn = true;

    public void StartGame()
    {
        Debug.Log("STARTING");
        switch (gameOptions.Difficulty)
        {
            case eDifficulty.EASY:
                m_nimsObjects = 6;
                //gen things
                break;
            case eDifficulty.NORMAL:
                m_nimsObjects = 12;
                //gen things
                break;
            case eDifficulty.HARD:
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
        Debug.Log(m_nimsObjects);

        if (count > 0) ChangeObjectCount(count);
        Debug.Log(m_nimsObjects);

        if (m_nimsObjects <= 0)
        {
            EndGame();
            return;
        }
        playerOnesTurn = !playerOnesTurn;
    }

    private void EndGame()
    {
        string winner = ((gameOptions.lastPickWins) ? ((playerOnesTurn) ? gameOptions.playerOne : gameOptions.playerTwo) : (playerOnesTurn) ? gameOptions.playerTwo : gameOptions.playerOne);
        Debug.Log(winner + " Wins!");

        //SceneSwitcher.Instance.LoadScene("Game", SceneSwitcher.eSet.MENU);
    }
}
