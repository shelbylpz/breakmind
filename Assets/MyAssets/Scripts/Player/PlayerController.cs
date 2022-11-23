using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    #region Variables Movimiento
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _maxSpeed = 20f;
    [SerializeField]
    private float _horizontalInput, _forwardInput;
    [SerializeField]
    private bool _isRunning;
    #endregion

    #region Key's
    [SerializeField] public List<bool> _keys;
    [SerializeField] public int _nKeys = 0;
     TextMeshProUGUI _card;
    [SerializeField] GameObject _CardPnl;
    #endregion

    #region Variables Brinco

    [SerializeField]
    private bool _jumpRequest = false;
    [SerializeField]
    private float _jumpForce = 5f;
    [SerializeField]
    private int _availableJumps = 0, _maxJumps = 3;
    #endregion

    private Rigidbody _playerRB;

    //private PLayerAnimation _playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        #region Obtener Rigidbody
        _playerRB = GetComponent<Rigidbody>();
        if (_playerRB == null)
        {
            Debug.Log("El jugador no tiene componente Rigidbody");
        }
        #endregion
     /*   #region Obtener PlayerAnimation
        _playerAnimation = GetComponent<PLayerAnimation>();
        if (_playerAnimation == null)
        {
            Debug.LogWarning("No se encontro un controlador de Animacion");
        }
        else
        {
            _playerAnimation.SetSpeed(0.74f);
        }
        #endregion
     
        _isRunning = false;
     */
        _speed = _maxSpeed * 1f;
        
        _card = _CardPnl.transform.GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        #region Movimiento
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(_horizontalInput, 0, _forwardInput);
        transform.Translate(movement * _speed * Time.deltaTime);
        #endregion
        #region Animacion de movimiento Comentada
        /* float velocity = Mathf.Max(Mathf.Abs(_horizontalInput), Mathf.Abs(_forwardInput)) * (_speed / _maxSpeed);
         _playerAnimation.SetSpeed(velocity);
         #endregion

         #region Cambio entre correr y caminar
         if (Input.GetKeyDown(KeyCode.LeftShift))
         {
             _isRunning = !_isRunning;
             if (_isRunning)
             {
                 _speed = _maxSpeed;
             }
             else
             {
                 _speed = _maxSpeed * 0.5f;
             }
         }
        */
        #endregion

        #region Peticion de brinco
        if (Input.GetKeyDown(KeyCode.Space) && _availableJumps > 0)
        {
            _jumpRequest = true;
        }
        #endregion
    }

    private void FixedUpdate()
    {
        if (_jumpRequest)
        {
            Debug.Log("Brinco el personaje");
            _playerRB.velocity = Vector3.up * _jumpForce;
            _availableJumps--;
            _jumpRequest = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _availableJumps = _maxJumps;
        }
    }

    public void updateKeys(int _keyPos)
     {
         _keys[_keyPos] = true;
         _nKeys++;
        _card.text = _nKeys.ToString();
     }

    /*private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Se encontro un objeto interactuable");
            Interactable interacted = collider.GetComponent<Interactable>();
            if (interacted != null)
            {
                interacted.Interact();
            }
            else
            {
                Debug.Log("Pero el objeto no tiene sript para interactuar");
            }
        }
    }*/

}

#region things to view
//using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player_Controller : MonoBehaviour
// {
//     private Rigidbody _playerRB;

//     private PlayerAnimation _playerAnimation;

//     #region Key's
//     [SerializeField] public List<bool> _keys;
//     #endregion

//     #region Moviemiento
//     [SerializeField]
//     private float _speed = 5f;
//     [SerializeField]
//     private float _maxSpeed = 10f;
//     [SerializeField]
//     private float _horizontalInput, _forwardinput;
//     [SerializeField]
//     private bool _isRunning;
//     #endregion
//     #region  Brinco
//     [SerializeField]
//     private int _availableJumps = 0, _maxJumps = 3;
//     [SerializeField]
//     private float _jumpForce = 5f;
//     [SerializeField]
//     private bool _jumpRequest = false;
//     #endregion
//     // Start is called before the first frame update
//     void Start()
//     {
//         #region Obtener RigidBody
//         _playerRB = GetComponent<Rigidbody>();
//         if(_playerRB == null)
//         {
//             Debug.LogWarning("El jugador no tiene Rigidbody");
//         }
//         #endregion
//         #region Obtener PlayerAnimation
//         _playerAnimation = GetComponent<PlayerAnimation>();
//         if(_playerAnimation == null)
//         {
//             Debug.LogWarning("No se encontro un controlador de Player Animation");
//         }
//         #endregion
//         _isRunning = false;
//         _speed = _maxSpeed * .5f;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         #region movimiento
//         _horizontalInput = Input.GetAxis("Horizontal");
//         _forwardinput = Input.GetAxis("Vertical");
//         Vector3 movement = new Vector3(_horizontalInput, 0, _forwardinput);
//         transform.Translate(movement * _speed * Time.deltaTime);
//         #endregion
//         #region Animacion de movimiento
//         float velocity = Mathf.Max(Mathf.Abs(_horizontalInput), Mathf.Abs(_forwardinput))*_speed/_maxSpeed;
//         _playerAnimation.SetSpeed(velocity);
//         #endregion
//         #region Cambio entre correr y caminar
//         if (Input.GetKeyDown(KeyCode.LeftShift))
//         {
//             _isRunning = !_isRunning;   
//             if (_isRunning)
//             {
//                 _speed = _maxSpeed;
//             }
//             else
//             {
//                 _speed = _maxSpeed * 0.5f;
//             }
//         }
//         #endregion
//         #region Jump
//         if (Input.GetKeyDown(KeyCode.Space) && _availableJumps>0)
//         {
//             _jumpRequest = true;
//         }
//         #endregion
//     }

//     private void FixedUpdate()
//     {
//         if (_jumpRequest)
//         {
//             Debug.Log("Brinco el personaje");
//             _playerRB.velocity = Vector3.up * _jumpForce;
//             _availableJumps--;
//             _jumpRequest = false;

//         }
//     }

//     private void OnCollisionEnter(Collision collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             _availableJumps = _maxJumps;
//         }
//     }

//     public void updateKeys(int _keyPos)
//     {
//         _keys[_keyPos] = true;
//     }
// }

#endregion