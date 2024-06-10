using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [FormerlySerializedAs("PauseMenu")] [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _inventoryChest;
    [SerializeField] private GameObject _openButtonChest;
    [SerializeField] private GameObject _resumeButton;
    [SerializeField] private GameObject _exitToMenuButon;
    [SerializeField] private GameObject _closedButtonChestInventory;
    [SerializeField] private ScrollRect _scrollViewInventory;
    [SerializeField] private GameObject _buttonInInventory;
    [SerializeField] private GameObject _closedButtonInventory;
    [SerializeField] private GameObject _openInventoryButton;
    [SerializeField] private GameObject _inventoryPlayer;
    [SerializeField] private GameObject _worldMap;
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
            _resumeButton.GetComponent<Button>().interactable = true;
            _closedButtonChestInventory.GetComponent<Button>().interactable = true;
            _scrollViewInventory.GetComponent<ScrollRect>().enabled = true;
            _buttonInInventory.GetComponent<Button>().interactable = true;
            Time.timeScale = 1;
        }
    }
    
    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            _joystick.SetActive(false);
            _pauseMenu.SetActive(true);
            _openButtonChest.GetComponent<Button>().interactable = false;
            _resumeButton.GetComponent<Button>().interactable = false;
            _closedButtonChestInventory.GetComponent<Button>().interactable = false;
            _scrollViewInventory.GetComponent<ScrollRect>().enabled = false;
            _buttonInInventory.GetComponent<Button>().interactable = false;
        }
    }

    public void ExitToMenu()
    {
        _scrollViewInventory.GetComponent<ScrollRect>().enabled = true;
        _buttonInInventory.GetComponent<Button>().interactable = true;
        SceneManager.LoadScene(0);
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

    public void OpenInventoryPlayer()
    {
        _inventoryPlayer.SetActive(true);
    }

    public void ClosedInventoryPlayer()
    {
        _inventoryPlayer.SetActive(false);
    }

    public void ShowWorldMap()
    {
        _worldMap.SetActive(true);
    }
}
