using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameOptions", menuName = "GameOptions")]
public class GameOptions : ScriptableObject
{
    public GameManager.eDifficulty Difficulty;
    public string playerOne;
    public string playerTwo;
    public bool playingAI;
    public bool lastPickWins;
}
