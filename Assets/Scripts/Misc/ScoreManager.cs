using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : Window
{
    [SerializeField] ScriptableScore scores = null;
    [SerializeField] TextMeshPro playerscore = null;
    [SerializeField] TextMeshPro computerscore = null;
    [SerializeField] GameObject playerScoresParent = null;
    [SerializeField] GameObject playerScoresTemplate = null;

    void Update()
    {
        playerScoresParent.GetComponentInChildren<ScoreTemplate>();
        playerscore.text = scores.playerwins.ToString();
        computerscore.text = scores.computerwins.ToString();
        foreach(KeyValuePair<string, int> score in scores.scores)
        {
            GameObject temp = Instantiate(playerScoresTemplate, playerScoresParent.transform);
            ScoreTemplate loadscore = temp.GetComponent<ScoreTemplate>();
            if (loadscore)
            {
                loadscore.player = score.Key;
                loadscore.wins = score.Value;
            }
        }
    }

    public void AddWin(string playername)
    {
        if (scores.scores.ContainsKey(playername))
        {
            scores.scores[playername] += 1;
        }
        else
        {
            scores.scores.Add(playername, 1);
        }
    }

    public void PlayerVersusComputerWin(bool Pwin)
    {
        if (Pwin)
        {
            scores.playerwins += 1;
        } else
        {
            scores.computerwins += 1;
        }
    }
}
