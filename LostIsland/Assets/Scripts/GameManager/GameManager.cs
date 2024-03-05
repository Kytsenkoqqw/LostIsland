using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [FormerlySerializedAs("PauseMenu")] [SerializeField] private GameObject _pauseMenu;
    [FormerlySerializedAs("Joystick")] [SerializeField] private GameObject _joystick;
    [FormerlySerializedAs("InventoryChest")] [SerializeField] private GameObject _inventoryChest;
    [FormerlySerializedAs("OpenButtonChest")] [SerializeField] private GameObject _openButtonChest;
    [FormerlySerializedAs("ClosedButtonChest")] [SerializeField] private GameObject _closedButtonChest;
    private bool _openChest = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;    
        }
    }

    public void Resume()
    {
        if (Time.timeScale !=1)
        {
            _joystick.SetActive(true);
            _pauseMenu.SetActive(false);
            _openButtonChest.GetComponent<Button>().interactable = true;
            _closedButtonChest.GetComponent<Button>().interactable = true;
            Time.timeScale = 1;
        }
    }
    
    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            _joystick.SetActive(false);
            _pauseMenu.SetActive(true);
            _openButtonChest.GetComponent<Button>().interactable = false;
            _closedButtonChest.GetComponent<Button>().interactable = false;
            Time.timeScale = 0;
        }
    }

    public void OpenInventoryChest()
    {
        _inventoryChest.SetActive(true);
        _openButtonChest.SetActive(false);
    }

    public void ClosedInventoryChest()
    {
        _inventoryChest.SetActive(false);
        _openButtonChest.SetActive(true);
    }
}
