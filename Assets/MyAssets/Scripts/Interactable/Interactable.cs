using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("3-Interactuando con algun objeto desconocido");
    }
    public virtual void Interact(PlayerController _player)
    {
        Debug.Log("Funciona para colecctables");
    }
    public virtual void Show()
    {

    }
}
