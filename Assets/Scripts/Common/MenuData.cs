using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuData : MonoBehaviour
{
    [SerializeField] GameOptions m_data = null;

    public void SetPlayer1(TextMeshProUGUI name)
    {
        if (name.text.Length > 1)
        {
            m_data.playerOne = " " + name.text;
        }
        if(m_data.playerOne == "" || m_data.playerOne == null || m_data.playerOne.Length == 1)
        {
            m_data.playerOne = " Player One";
            name.SetText(m_data.playerOne);
        }
        
    }

    public void SetPlayer2(TextMeshProUGUI name)
    {
        if(name.text.Length > 1)
        {
            m_data.playerTwo = " " + name.text;
        }
        if (m_data.playerTwo == "" || m_data.playerTwo == null || m_data.playerTwo.Length == 1)
        {
            m_data.playerTwo = " Player Two";
            name.SetText(m_data.playerOne);
        }
        
    }

    public void SetPlayer2AI()
    {
        m_data.playerTwo = "Nim";
    }

    public void SetDiff(int difficulty)
    {
        Debug.Log(difficulty);
        switch (difficulty)
        {
            case 1:
                m_data.Difficulty = GameManager.eDifficulty.EASY;
                break;
            case 2:
                m_data.Difficulty = GameManager.eDifficulty.NORMAL;
                break;
            case 3:
                m_data.Difficulty = GameManager.eDifficulty.HARD;
                break;
            default:
                m_data.Difficulty = GameManager.eDifficulty.INVALID;
                break;
        }
        Debug.Log(m_data.Difficulty);
    }

    public void SetWin(bool IsLastWin)
    {
        m_data.lastPickWins = IsLastWin;
    }

    public void SetPlayers(bool IsAI)
    {
        m_data.playingAI = IsAI;
    }
}
