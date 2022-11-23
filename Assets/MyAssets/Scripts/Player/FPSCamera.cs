using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    #region Variables inicializacion camara
    [SerializeField]
    private Transform _player, _playerCamera;
    #endregion


    #region Variables rotacion
    [SerializeField]
    private float _camRotX, _camRotY;
    [SerializeField]
    private float _cameraSensitivity = 5;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        #region Comprobacion de asignacion
        if (_player == null)
        {
            Debug.Log("No se asigno el jugador al contrololador de camara");
        }
        if (_playerCamera == null)
        {
            Debug.Log("No se asigno la camara principal al contrololador de camara");
        }
        #endregion
        _playerCamera.SetParent(_player);
        #region Asignar pos y rot

        _playerCamera.localPosition = new Vector3(0, 0.63f, 0.1f);

        _playerCamera.localScale = new Vector3(0, 0.63f, 0.1f);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region Zoom

        _playerCamera.localPosition = new Vector3(0, 0.63f, 0.1f);
        #endregion

        #region rotacion

        _camRotX += Input.GetAxis("Mouse X") * _cameraSensitivity;
        _camRotY += Input.GetAxis("Mouse Y") * _cameraSensitivity * (-1);
        _camRotY = Mathf.Clamp(_camRotY, -70, 70);
        _playerCamera.localRotation = Quaternion.Euler(_camRotY, 0, 0);
        _player.localRotation = Quaternion.Euler(0, _camRotX, 0);


        #endregion

    }
}
