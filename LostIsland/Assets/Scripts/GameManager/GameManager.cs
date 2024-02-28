using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [FormerlySerializedAs("PauseMenu")] [SerializeField] private GameObject _pauseMenu;
    [FormerlySerializedAs("Joystick")] [SerializeField] private GameObject _joystick;
    [FormerlySerializedAs("ChestButton")] [SerializeField] private GameObject _chestButton;
    
    public void Resume()
    {
        if (Time.timeScale !=1)
        {
            _joystick.SetActive(true);
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            _joystick.SetActive(false);
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
