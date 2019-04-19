using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScoreData")]

public class ScriptableScore : ScriptableObject
{
    [SerializeField] int playerwins = 0;
    [SerializeField] int computerwins = 0;
    [SerializeField] Dictionary<string, int> scores = null;
}
