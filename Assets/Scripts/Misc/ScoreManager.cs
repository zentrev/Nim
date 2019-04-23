using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : Window
{
    [SerializeField] ScriptableScore scores = null;
    [SerializeField] TextMeshProUGUI playerscore = null;
    [SerializeField] TextMeshProUGUI computerscore = null;
    [SerializeField] TextMeshProUGUI playerNames = null;
    [SerializeField] TextMeshProUGUI playerWins = null;
    [SerializeField] GameObject panel = null;

    void Update()
    {
        if (IsActive)
        {
            panel.SetActive(true);
            playerscore.text = scores.playerwins.ToString();
            computerscore.text = scores.computerwins.ToString();

            string playernames = "";
            string playerwins = "";
            foreach (KeyValuePair<string, int> score in scores.scores)
            {
                playernames += score.Key;
                playernames += "/n";

                playerwins += score.Value.ToString();
                playerwins += "/n";
            }
            playerNames.text = playernames;
            playerWins.text = playerwins;
        } else
        {
            panel.SetActive(false);
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
