using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataMemory : MonoBehaviour
{
    [SerializeField] GameOptions data = null;
    [SerializeField] TextMeshProUGUI Player1 = null;
    [SerializeField] TextMeshProUGUI Player2 = null;
    [SerializeField] TextMeshProUGUI Player1Preview = null;
    [SerializeField] TextMeshProUGUI Player2Preview = null;
    [SerializeField] Toggle Easy = null;
    [SerializeField] Toggle Normal = null;
    [SerializeField] Toggle Hard = null;
    [SerializeField] Toggle LastWin = null;
    [SerializeField] Toggle LastLose = null;

    private void OnEnable()
    {

        Player1.text = data.playerOne;
        //Player1Preview.text = data.playerOne;

        if (Player2 != null)
        {
            Player2.text = data.playerTwo;
        }
        if(data.Difficulty == GameManager.eDifficulty.EASY)
        {
            Easy.isOn = true;
            Normal.isOn = false;
            Hard.isOn = false;
        }
        else if(data.Difficulty == GameManager.eDifficulty.NORMAL)
        {
            Easy.isOn = false;
            Normal.isOn = true;
            Hard.isOn = false;
        }
        else if(data.Difficulty == GameManager.eDifficulty.HARD)
        {
            Easy.isOn = false;
            Normal.isOn = false;
            Hard.isOn = true;
        }
        else
        {
            Easy.isOn = false;
            Normal.isOn = false;
            Hard.isOn = false;
        }
        if(data.lastPickWins)
        {
            LastWin.isOn = true;
            LastLose.isOn = false;
        }
        else
        {
            LastWin.isOn = false;
            LastLose.isOn = true;
        }
    }
}
