using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : Singleton<AIInput>
{
    class RowCount
    {
        public GameObject row;
        public List<NimObject> nims;
        public int activeCount;

        public RowCount(GameObject _row, List<NimObject> _nims)
        {
            row = _row;
            nims = _nims;
        } 

        public int GetActiveNimCount()
        {
            int count = 0;
            foreach(NimObject nim in nims)
            {
                if (nim.m_active) count++;
            }
            activeCount = count;
            return count;
        }
    }

    List<RowCount> rows = new List<RowCount>();

    public void GetObjects()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("NimsRow");

        for(int i = 0; i < gos.Length; i++)
        {
            List<NimObject> nims = new List<NimObject>();
            for(int j = 0; j < gos[i].transform.childCount; j++)
            {
                nims.Add(gos[i].transform.GetChild(j).GetComponent<NimObject>());
            }
            rows.Add(new RowCount(gos[i],nims));
        }
    }

    public void AITurn(GameManager.eDifficulty difficutly)
    {
        foreach(RowCount row in rows)
        {
            row.GetActiveNimCount();
        }

        int selectionCount = 0;

        switch (difficutly)
        {
            case GameManager.eDifficulty.EASY:

                bool vaildMove = false;
                while(!vaildMove)
                {
                    int ran = Random.Range(0, rows.Count);
                    if (rows[ran].activeCount > 0)
                    {
                        foreach(NimObject nim in rows[ran].nims)
                        {
                            if (nim.m_active)
                            {
                                nim.DeactivateObject();
                                selectionCount++;
                                vaildMove = true;
                                break;
                            }
                        }
                    }
                }
                Debug.Log("Ending AI");
                GameManager.Instance.EndTurn(selectionCount);

                break;
            case GameManager.eDifficulty.NORMAL:
                break;
            case GameManager.eDifficulty.HARD:



                break;
            default:
                Debug.LogError("Invalid difficulty");
                break;
        }
    }
}
