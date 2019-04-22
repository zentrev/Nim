using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] LayerMask m_layerMask = new LayerMask();
    private GameObject ParentRow { get; set; }  = null;
    private Camera m_camera = null;
    Queue<NimObject> SelectedObjects = new Queue<NimObject>();

    public void EndTurn()
    {
        foreach(NimObject nim in SelectedObjects)
        {
            nim.DeactivateObject();
        }
        SelectedObjects.Clear();
        ParentRow = null;
    }
    private void Start()
    {
        m_camera = Camera.main;
    }
    private void Update()
    {
        if (GameManager.Instance.inGame)
        {
            if(Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = new Ray();

                if (Input.touchCount > 0)
                {
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
                        if (nims.transform.parent.gameObject != ParentRow)
                        {
                            int objectCount = SelectedObjects.Count;
                            for (int i = 0; i < objectCount; i++)
                            {
                                NimObject q = SelectedObjects.Dequeue();
                                q.m_selected = false;
                            }
                            ParentRow = nims.transform.parent.gameObject;
                        }
                        if(!SelectedObjects.Contains(nims)) SelectedObjects.Enqueue(nims);
                        nims.m_selected = true;
                    }
                }
            }
        }
    }
}
