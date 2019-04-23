﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuData : MonoBehaviour
{
    [SerializeField] GameOptions m_data = null;

    public void SetPlayer1(TextMeshProUGUI name)
    {
        m_data.playerOne = name.text;
    }

    public void SetPlayer2(TextMeshProUGUI name)
    {
        if(name != null)
        {
            m_data.playerTwo = name.text;
        }
        else
        {
            m_data.playerTwo = null;
        }
    }

    public void SetDiff(int difficulty)
    {
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
