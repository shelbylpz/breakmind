using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    #region Componentes Dialogo
    [Header("Panel de Dialogos")]
#pragma warning disable 0649
    [SerializeField]
    private GameObject _dialoguePnl, _interactPnl;
#pragma warning restore 0649
    private TextMeshProUGUI _dialogueTMP, _nameTMP, _nextTMP, _interactTMP;
    private Button _nextBtn;
    #endregion

    #region Componentes NPC
    private string _name;
    private List<string> _dialogueList;
    private int _dialogueIdx;
    #endregion


    void Start()
    {

        #region Obtener componentes dialogo
        if (_dialoguePnl == null)
        {
            Debug.LogWarning("Falto arrastrar el panel de dialogos al inspector del controlador de dialogos");
        }
        //obtener el componente del rpimer hijo
        _dialogueTMP = _dialoguePnl.transform.GetComponentInChildren<TextMeshProUGUI>();
        if (_dialogueTMP != null)
        {
            _dialogueTMP.text = "Encontrado texto de dialogos";
        }
        else
        {
            Debug.LogWarning("No se encontro un TMP como primer hijo de dialogo");
        }
        //obtener el componente del hijo del segundo hijo
        _nameTMP = _dialoguePnl.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        if (_nameTMP != null)
        {
            _nameTMP.text = "Nombre Encontrado";
        }
        else
        {
            Debug.LogWarning("No se encontro un TMP para el nombre en el primer hijo del segundo hijo");
        }
        //Obtener el tercer hijo
        _nextBtn = _dialoguePnl.transform.GetChild(2).GetComponent<Button>();
        if (_nextBtn != null)
        {
            //agregar un listener

            _nextTMP = _nextBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            if (_nextTMP != null)
            {
                _nextTMP.text = "Encontrado";
            }
            else
            {
                Debug.LogWarning("No se ha encontrado el TMP del Boton");
            }
        }
        else
        {
            Debug.LogWarning("No se encontro un boton como tercer hijo del panel");
        }

        if (_interactPnl == null)
        {
            Debug.LogWarning("Falto arrastrar el InteractPnl al inspector del controlador de dialogos");

        }
        _interactTMP = _interactPnl.transform.GetComponentInChildren<TextMeshProUGUI>();
        if (_interactTMP != null)
        {
            _interactTMP.text = "Press <E> to Interact";
        }
        #endregion 

        _dialoguePnl.SetActive(false);
        _interactPnl.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ContinueDialogue();

        }
    }
    public void SetDialogue(string name, string[] dialogue)
    {
        HideInteract();
        Debug.Log("Obteniendo dialogo de " + name);
        _name = name;
        _dialogueList = new List<string>(dialogue.Length);
        _dialogueList.AddRange(dialogue);
        _dialogueIdx = 0;
        _nameTMP.text = _name;
        ShowDialogue();
        _nextTMP.text = "Press <F>";
        #region Prueba despues esto para el boton
        /*
         if( dialogue.Length == 1 || (dialogue.Length - _dialogueIdx) == 0)
          {
            _dialoguePnl.SetActive(false);
         
          }else if(dialogue.Length == 1 || (dialogue.Length - _dialogueIdx) == 1)
        {
            _nextTMP.text = "Exit";
            _dialogueIdx++;
            ShowDialogue();
        }
        else
        {
            
            _dialogueIdx++;
            ShowDialogue();

        }*/
        #endregion
        ShowInteract();
    }

    private void ContinueDialogue()
    {
        HideInteract();
        if (_dialogueIdx == _dialogueList.Count - 1)
        {
            Debug.Log("Se termino el dialogo de " + _name);
            _dialoguePnl.SetActive(false);
        }
        else if (_dialogueIdx == _dialogueList.Count - 2)
        {
            _nextTMP.text = "Exit";
            _dialogueIdx++;
            ShowDialogue();
        }
        else
        {
            _dialogueIdx++;
            ShowDialogue();
        }
    }

    private void ShowDialogue()
    {
        Debug.Log("Idx: " + _dialogueIdx + " Dialogue cont: " + _dialogueList[_dialogueIdx]);
        _dialogueTMP.text = _dialogueList[_dialogueIdx];
    }

    public void ShowInteract()
    {
        _interactPnl.SetActive(true);
    }
    public void HideInteract()
    {
        _interactPnl.SetActive(false);
    }
}
