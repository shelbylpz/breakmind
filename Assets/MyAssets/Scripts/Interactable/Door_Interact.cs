using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interact : Interactable
{
    [SerializeField] public int _keyNeed;
    public override void Interact(PlayerController _player)
    {
        if (_player._keys[_keyNeed] == true)
        {
            transform.Translate(Vector3.up * 90);
        }
        else
        {
            Debug.LogWarning("No tienes la llave mecesaria");
        }
    }
}
