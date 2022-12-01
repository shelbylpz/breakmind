using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UvRayCast : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float range = 4f;
    LayerMask _mask;
    public GameObject lastSelect = null;
    private void Start()
    {
        _mask = LayerMask.GetMask("UV");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range, _mask))
        {
            Deselected();
            SelectedObject(hit.transform);
            //Debug.Log("Hit interactable");
            Debug.DrawRay(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            hit.collider.transform.GetComponent<Interactable>().Interact();
            
        }
        else
        {
            
            Deselected();

            Debug.DrawRay(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward) * range, Color.white);
            
        }
    }

    void SelectedObject(Transform transform)
    {
        lastSelect = transform.gameObject;
    }

    void Deselected()
    {
        if (lastSelect)
        { 
            lastSelect.GetComponent<Interactable>().Interact();
            lastSelect = null;
        }
    }
}
