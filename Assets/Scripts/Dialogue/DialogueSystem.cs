using System;
using System.Collections;
using System.Collections.Generic;
using Item;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private GameObject _dialogPanel;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private string[] _lines;
    [SerializeField] private float _speedText;
    [SerializeField] private AssetItem requiredItem;
    [SerializeField] private int requiredItemCount;

    private int _index;

    private void Start()
    {
        _dialogPanel.SetActive(false);
        _index = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Inventory inventory = FindObjectOfType<Inventory>(true);
            if (inventory != null)
            {
                string[] lines;
                if (inventory.HasItem(requiredItem, requiredItemCount))
                {
                    lines = new string[] { "Отлчно! Вижу у тебя есть нужное колличество дерева"};
                }
                else
                {
                    lines = new string[] { "Привет! Тут корабль сломан", "Что бы починть его, нужно добыть немного дерева!" };
                }

                _dialogPanel.SetActive(true);
                ShowMessage(lines);
            }
            else
            {
                Debug.LogWarning("Inventory not found.");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _dialogPanel.SetActive(false);
            StopAllCoroutines();
        }
    }

    public void ShowMessage(string[] lines)
    {
        _lines = lines;
        _index = 0;
        _dialogPanel.SetActive(true);
        StartDialog();
    }

    void StartDialog()
    {
        _dialogText.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in _lines[_index].ToCharArray())
        {
            _dialogText.text += c;
            yield return new WaitForSeconds(_speedText);
        }
    }

    public void SkipTextClick()
    {
        if (_dialogText.text == _lines[_index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            _dialogText.text = _lines[_index];
        }
    }

    public void NextLines()
    {
        if (_index < _lines.Length - 1)
        {
            _index++;
            StartDialog();
        }
        else
        {
            _index = 0;
            _dialogPanel.SetActive(false);
        }
    }
}
