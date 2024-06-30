using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] private Slider progressBar; // Ссылка на прогресс-бар
    [SerializeField] private GameObject loadScreen; // Ссылка на экран загрузки
    private float duration = 1f; // Длительность заполнения бара в секундах

    private void Start()
    {
        StartCoroutine(ShowLoadingScreen());
    }

    IEnumerator ShowLoadingScreen()
    {
        loadScreen.SetActive(true); // Показываем экран загрузки
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            progressBar.value = timer / duration; // Заполняем бар пропорционально времени
            yield return null;
        }

        // Убедимся, что бар заполнен полностью
        progressBar.value = 1f;

        // Выключаем экран загрузки
        loadScreen.SetActive(false);
    }
}
