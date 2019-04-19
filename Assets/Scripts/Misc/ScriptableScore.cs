using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScoreData")]

public class ScriptableScore : ScriptableObject
{
    public int playerwins = 0;
    public int computerwins = 0;
    public Dictionary<string, int> scores = null;
}
