using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManuManager : MonoBehaviour
{

    [SerializeField] private Button _playButton;

    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1; 
    }


}
