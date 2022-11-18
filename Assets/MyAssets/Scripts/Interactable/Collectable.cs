using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    //public List<Collectable> Collectables;
    [SerializeField]
    private int _number;

    public override void Interact(PlayerController _player)
    {
        _player.updateKeys(_number);
        Destroy(gameObject);
    }
}
