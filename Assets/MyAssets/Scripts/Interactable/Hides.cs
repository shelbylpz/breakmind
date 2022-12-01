using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hides : Interactable
{
    [SerializeField] bool initialState;
    private bool actualState;
    private MeshRenderer mr;
    private BoxCollider BoxCollider;
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        BoxCollider = GetComponent<BoxCollider>();
        if (!initialState)
        {
            mr.enabled = initialState;
            BoxCollider.isTrigger = !initialState;
        }
        actualState = initialState;
    }
    public override void Interact()
    {
        if (transform.gameObject.CompareTag("Lore"))
        {
            if (actualState == initialState)
            {
                mr.enabled = !initialState;
                BoxCollider.isTrigger = initialState;
                actualState = !actualState;
            }
            else
            {
                mr.enabled = initialState;
                BoxCollider.isTrigger = !initialState;
                actualState = !actualState;

            }
        }
        else
        {
            if (actualState == initialState)
            {
                mr.enabled = !initialState;
                BoxCollider.isTrigger = initialState;
                actualState = !actualState;
            }
        }
    }
}
