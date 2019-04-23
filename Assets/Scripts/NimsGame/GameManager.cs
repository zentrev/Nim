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
        GameObject prefab = null;
        switch (gameOptions.Difficulty)
        {
            case eDifficulty.EASY:
                m_nimsObjects = 6;
                prefab = Instantiate(m_easyPrefab);
                break;
            case eDifficulty.NORMAL:
                m_nimsObjects = 14;
                //gen things
                break;
            case eDifficulty.HARD:
                m_nimsObjects = 22;
                //gen things
                break;
            default:
                Debug.LogError("INVALID DIFFICULTY");
                break;
        }
        prefab.transform.position = Vector3.zero;
        Debug.Log(gameOptions.playerOne + "'s Turn");
    }

    public void ChangeObjectCount(int count)
    {
        m_nimsObjects -= count;
    }

    public void EndTurn(int count = 0)
    {
        if (count > 0) ChangeObjectCount(count);

        if (m_nimsObjects <= 0)
        {
            EndGame();
            return;
        }
        playerOnesTurn = !playerOnesTurn;
        if(!playerOnesTurn && gameOptions.playingAI)
        {
            inGame = false;
            //Run AI stuff
            inGame = true;
        }
        Debug.Log(CurrentPlayer() + "'s Turn! " + m_nimsObjects + " Objects Left!");
    }

    private void EndGame()
    {
        if (!gameOptions.lastPickWins) playerOnesTurn = !playerOnesTurn;
        Debug.Log(CurrentPlayer() + " Wins!");

        //SceneSwitcher.Instance.LoadScene("Game", SceneSwitcher.eSet.MENU);
    }

    private string CurrentPlayer()
    {
        return ((gameOptions.lastPickWins) ? ((playerOnesTurn) ? gameOptions.playerTwo : gameOptions.playerOne) : (playerOnesTurn) ? gameOptions.playerOne : gameOptions.playerTwo);
    }

    
}
