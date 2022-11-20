using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionsController : MonoBehaviour
{
    [SerializeField] private List<GameObject> GuideGame = new List<GameObject>();
    [SerializeField] private GameObject button1, button2;
    private Button _nextBtn;

    int _index = 0;

    // Start is called before the first frame update
    void Start()
    {
        _nextBtn = button1.transform.GetComponentInChildren<Button>();
        _nextBtn.onClick.AddListener(delegate { ContinueGuide(); });
        GuideGame[2].SetActive(false);
        GuideGame[1].SetActive(false);
        button2.SetActive(false);
    }


    public void ContinueGuide()
    {
        if (_index == GuideGame.Count - 1)
        {
            
        }
        else if (_index == GuideGame.Count - 2)
        {
            GuideGame[_index].SetActive(false);
            button1.SetActive(false);
            button2.SetActive(true);
            _index++;
            GuideGame[_index].SetActive(true);
        }
        else
        {
            GuideGame[_index].SetActive(false);
            _index++;
            GuideGame[_index].SetActive(true);
            
        }
    }

}
