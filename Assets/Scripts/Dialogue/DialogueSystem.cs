using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private GameObject _dailogPanel;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private string[] _lines;
    [SerializeField] private float _speedText;
    

    private int _index;

   
    private void Start () 
    {
        _dailogPanel.SetActive(false);  
        _index = 0;
    }
    
    public void ShowMessage(string[] lines)
    {
        _lines = lines;
        _index = 0;
        _dailogPanel.SetActive(true);
        StartDialog();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _dailogPanel.SetActive(true);
            StartDialog();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _dailogPanel.SetActive(false);
            StopAllCoroutines();
        }
        
    }

    void StartDialog()
    {
        _dialogText.text = string.Empty;
        StartCoroutine (TypeLine ());
    }
	
    IEnumerator TypeLine()
    {
        foreach (char c  in _lines[_index].ToCharArray()) 
        {
            _dialogText.text += c;
            yield return new WaitForSeconds (_speedText);
        }
    }

    public void scipTextClick()
    {
        if (_dialogText.text == _lines [_index]) {
            NextLines ();
        } 
        else
        {
            StopAllCoroutines ();
            _dialogText.text = _lines [_index];
        }
    }

    public void NextLines()
    {
        if (_index < _lines.Length - 1) 
        {
            _index++;
            StartDialog ();
        } 
        else 
        {
            _index=0;
            StartDialog ();
        }
    }
}

