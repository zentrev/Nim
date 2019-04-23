using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : Singleton<UserInput>
{
    [SerializeField] LayerMask m_layerMask = new LayerMask();
    private GameObject ParentRow { get; set; }  = null;
    private Camera m_camera = null;
    List<NimObject> SelectedObjects = new List<NimObject>();

    public void EndTurn()
    {
        int nimCount = SelectedObjects.Count;

        if (nimCount > 0 || GameManager.Instance.firstTurn)
        {
            foreach (NimObject nim in SelectedObjects)
            {
                nim.DeactivateObject();
            }
            SelectedObjects.Clear();
            ParentRow = null;
            GameManager.Instance.firstTurn = false;
            GameManager.Instance.EndTurn(nimCount);
        }
    }

    private void Start()
    {
        m_camera = Camera.main;
    }

    private void Update()
    {
        if (GameManager.Instance.inGame)
        {
            if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = new Ray();

                if (Input.touchCount > 0)
                {
                    Debug.Log(Input.GetTouch(0).phase);
                    ray = m_camera.ScreenPointToRay(Input.GetTouch(0).position);
                }
                else
                {
                    ray = m_camera.ScreenPointToRay(Input.mousePosition);
                }

                if (Physics.Raycast(ray, out RaycastHit hit, m_layerMask))
                {
                    NimObject nims = hit.transform.gameObject.GetComponent<NimObject>();
                    if (nims)
                    {
                        if (nims.m_active)
                        {
                            if (SelectedObjects.Contains(nims))
                            {
                                SelectedObjects.Remove(nims);
                                nims.m_selected = false;
                            }
                            else
                            {
                                if (nims.transform.parent.gameObject != ParentRow)
                                {
                                    int objectCount = SelectedObjects.Count - 1;

                                    for (int i = objectCount; i >= 0; i--)
                                    {
                                        NimObject q = SelectedObjects[i];
                                        SelectedObjects.RemoveAt(i);
                                        q.m_selected = false;
                                    }
                                    ParentRow = nims.transform.parent.gameObject;
                                }
                                if (!SelectedObjects.Contains(nims)) SelectedObjects.Add(nims);
                                nims.m_selected = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
