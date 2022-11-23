using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door_Interact : Interactable
{
    [SerializeField] GameObject _levelRequiredPnl;
    TextMeshProUGUI _levelText;
    [SerializeField] public int _keyNeed;

    private void Start()
    {
        _levelText = _levelRequiredPnl.transform.GetComponentInChildren<TextMeshProUGUI>();
        _levelRequiredPnl.SetActive(false);
    }
    public override void Interact(PlayerController _player)
    {
        if (_player._keys[_keyNeed] == true)
        {
            transform.Translate(Vector3.up * 90);
        }
        else
        {
            _levelRequiredPnl.SetActive(true);
            _levelText.text = "Necesitas Nivel de acceso " + (_keyNeed + 1);
            Debug.LogWarning("No tienes la llave mecesaria");
        }
    }
}
