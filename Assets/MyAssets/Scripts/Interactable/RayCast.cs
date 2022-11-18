using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RayCast : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float range = 2f;
    [SerializeField] private GameObject _interactPnl;
    [SerializeField] PlayerController _player;
    LayerMask _mask;
    private void Start()
    {
        _mask = LayerMask.GetMask("Interactable");
        _player = GetComponent<PlayerController>();
        if (_player == null)
        {
            Debug.LogWarning("El RayCast no encontro un player Controller");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range, _mask))
        {
            //Debug.Log("Hit interactable");
            Debug.DrawRay(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            hit.transform.GetComponent<Interactable>().Show();
            _interactPnl.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.gameObject.CompareTag("Collectable"))
                    hit.transform.GetComponent<Interactable>().Interact(_player);
                if (hit.transform.gameObject.CompareTag("Door"))
                    hit.transform.GetComponent<Interactable>().Interact(_player);
                if (hit.transform.gameObject.CompareTag("NPC"))
                    hit.transform.GetComponent<Interactable>().Interact();
            }
        }
        else
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward) * range, Color.white);
            // Debug.Log("Did not Hit");
            _interactPnl.SetActive(false);

        }
    }
}
