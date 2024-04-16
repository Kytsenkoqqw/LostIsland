using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private GameObject _dailogPanel;
    [SerializeField] private string[] _lines;
    [SerializeField] private float _speedText;
    [SerializeField] private TextMeshProUGUI _dialogText;

    public int index;

   
    void Start () 
    {
        _dailogPanel.SetActive(false);  
        index = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Bob");
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
        foreach (char c  in _lines[index].ToCharArray()) 
        {
            _dialogText.text += c;
            yield return new WaitForSeconds (_speedText);
        }
    }

    public void scipTextClick()
    {
        if (_dialogText.text == _lines [index]) {
            NextLines ();
        } 
        else
        {
            StopAllCoroutines ();
            _dialogText.text = _lines [index];
        }
    }

    public void NextLines()
    {
        if (index < _lines.Length - 1) 
        {
            index++;
            StartDialog ();
        } 
        else 
        {
            index=0;
            StartDialog ();
        }
    }
}

