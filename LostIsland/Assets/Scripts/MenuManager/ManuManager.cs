using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManuManager : MonoBehaviour
{

    [SerializeField] private Button _playButton;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _bar;
    public string _sceneToLoad;

    public void Play()
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync());
        Time.timeScale = 1; 
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            _bar.value = asyncLoad.progress;
            yield return null;
        }
    }




}
