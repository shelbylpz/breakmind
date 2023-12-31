using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Linterna : MonoBehaviour
{

    [SerializeField] GameObject _linterna;
    [SerializeField] GameObject _linterna2;
    [SerializeField] bool _enabled = false;
    [SerializeField] bool typeLight = false;
    [SerializeField] GameObject _LinternaOff;
    [SerializeField] GameObject _LinternaOnNormal;
    [SerializeField] GameObject _LinternaOnUV;
    //[SerializeField] GameObject colorLight;
    // Start is called before the first frame update
    private void Start()
    {
        
        if (!_linterna)
        {
            Debug.LogWarning("No se ha configurado el objeto Linterna");
        }
        _linterna.SetActive(false);
        if (!_linterna2)
        {
            Debug.LogWarning("No se ha configurado el objeto Linterna");
        }
        _linterna2.SetActive(false);
        _LinternaOnNormal.SetActive(false);
        _LinternaOnUV.SetActive(false);
        _enabled = false;
        typeLight = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            typeLight = false;
            _linterna2.SetActive(false);
            if (_enabled)
            {
                _linterna.SetActive(true);
                _LinternaOnUV.SetActive(false);
                _LinternaOnNormal.SetActive(true);
            }
            else
                _enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            typeLight = true;
            _linterna.SetActive(false);
            if (_enabled)
            {
                _linterna2.SetActive(true);
                _LinternaOnNormal.SetActive(false);
                _LinternaOnUV.SetActive(true);

            }
            else
                _enabled = false;
        }
        if (!typeLight)
        {
            if (!_enabled)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _linterna.SetActive(true);
                    _LinternaOff.SetActive(false);
                    _LinternaOnNormal.SetActive(true);
                    _enabled = true;
                }

            }
            else if(_enabled){
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _linterna.SetActive(false);
                    _LinternaOnNormal.SetActive(false);
                    _LinternaOff.SetActive(true);
                    _enabled = false;
                }
            }

        }
        else
        {
            if (!_enabled)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _linterna2.SetActive(true);
                    _LinternaOff.SetActive(false);
                    _LinternaOnUV.SetActive(true);
                    _enabled = true;
                }

            }
            else if (_enabled)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _linterna2.SetActive(false);
                    _LinternaOff.SetActive(true);
                    _LinternaOnUV.SetActive(false);
                    _enabled = false;
                }
            }
        }
    }
    
}
