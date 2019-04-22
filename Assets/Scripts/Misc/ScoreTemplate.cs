using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTemplate : MonoBehaviour
{
    [SerializeField] TextMeshPro m_name = null;
    [SerializeField] TextMeshPro m_wins = null;

    public string player { get { return m_name.text; } set { m_name.text = value; } }
    public int wins { get { return int.Parse(m_wins.text); } set { m_wins.text = value.ToString(); } }


}
