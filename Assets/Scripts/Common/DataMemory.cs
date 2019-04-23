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
        if(Player1.ToString() != "")
        {
            Player1Preview.text = "";
            Player1.text = data.playerOne.ToString();
        }
        else
        {
            Player1Preview.text = "PlayerOne Name";
        }
        if(Player2 != null)
        {
            Player2Preview.text = "";
            Player2.text = data.playerTwo.ToString();
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
