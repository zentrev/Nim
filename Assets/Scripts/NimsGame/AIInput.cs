using System;
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
        rows.Clear();
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

    public void AITurn(GameManager.eDifficulty difficutly, bool lastPickWins)
    {
        foreach(RowCount row in rows)
        {
            row.GetActiveNimCount();
        }

        int selectionCount = 0;

        switch (GameManager.eDifficulty.HARD)
        {
            case GameManager.eDifficulty.EASY:

                PickOneRandom();

                break;
            case GameManager.eDifficulty.NORMAL:
                break;
            case GameManager.eDifficulty.HARD:
                BitArray[] bitRows = new BitArray[rows.Count];
                bool validMove = false;
                Debug.Log("<color=red>-----------NEW AI TURN----------------</color>");
                for(int currentRow = 0; currentRow < rows.Count; currentRow++)
                {
                    Debug.Log("New HEcking Row!!!-----------------------------");
                    for (int i = 0; i < rows[currentRow].GetActiveNimCount(); i++)
                    {
                        if (!validMove)
                        {
                            for (int j = 0; j < rows.Count; j++)
                            {
                                if (j == currentRow)
                                {
                                    bitRows[j] = new BitArray(BitConverter.GetBytes(i));
                                    Debug.Log("C:" + i);
                                }
                                else
                                {
                                    bitRows[j] = new BitArray(BitConverter.GetBytes(rows[j].GetActiveNimCount()));
                                    Debug.Log(rows[j].GetActiveNimCount());

                                }
                            }

                            //debug
                            foreach (BitArray bits in bitRows)
                            {
                                string outS = "";
                                for (int q = 0; q < bits.Length; q++)
                                {
                                    outS += (bits[q]) ? "1" : "0";
                                }
                                Debug.Log("<color=blue>" + outS + "</color>");
                            }


                            int longestRow = 0;
                            for (int j = 0; j < bitRows.Length; j++)
                            {
                                if (bitRows[j].Length > longestRow) longestRow = bitRows[j].Length;
                            }

                            Debug.Log("---");
                            string addativeS = "";
                            bool winningMove = true;
                            for (int j = 0; j < longestRow; j++)
                            {
                                int addative = 0;
                                for (int k = 0; k < bitRows.Length; k++)
                                {
                                    if (bitRows[k].Length >= j)
                                    {
                                        if (bitRows[k][j]) addative++;
                                    }
                                }
                                if (addative % 2 != 0 && addative != 0)
                                {
                                    winningMove = false;
                                }

                                if(!lastPickWins && j == 0)
                                {
                                    if(addative % 2 == 0 || addative == 0)
                                    {
                                        winningMove = false;
                                    }
                                    else
                                    {
                                        winningMove = true;
                                    }
                                }
                                
                                addativeS += addative.ToString();
                            }

                            Debug.Log(addativeS);
                            Debug.Log("--new--");

                            if (winningMove)
                            {
                                Debug.Log(rows[currentRow].row + ": " + currentRow + " Take:" + (rows[currentRow].GetActiveNimCount() - i));
                                int selected = 0;

                                foreach (NimObject nim in rows[currentRow].nims)
                                {
                                    if (nim.m_active && selected <= rows[currentRow].GetActiveNimCount()-i)
                                    {
                                        nim.DeactivateObject();
                                        selectionCount++;
                                        selected++;
                                    }
                                }
                                Debug.Log(selected);
                                GameManager.Instance.EndTurn(selectionCount);
                                return;
                            }
                        }
                    }
                }
                Debug.Log("<color=red>We Failed</color>");
                PickOneRandom();
                break;
            default:
                Debug.LogError("Invalid difficulty");
                break;
        }
    }


    public void PickOneRandom()
    {
        int selectionCount = 0;
        bool vaildMove = false;
        while (!vaildMove)
        {
            int ran = UnityEngine.Random.Range(0, rows.Count);
            if (rows[ran].activeCount > 0)
            {
                foreach (NimObject nim in rows[ran].nims)
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
    }
}
