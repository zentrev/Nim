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
    }
    private void Start()
    {
        m_camera = Camera.main;
    }
    private void Update()
    {
        Ray ray = m_camera.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out RaycastHit hit, m_layerMask))
        {
            NimObject nims = hit.transform.gameObject.GetComponent<NimObject>();
            if(nims)
            {
                SelectedObjects.Enqueue(nims);
                nims.m_selected = true;
            }
        }
    }
}
