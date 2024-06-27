using System.Collections;
using System.Collections.Generic;
using State;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : MonoBehaviour
{
    [SerializeField] private Image _hpIndicator;
    [SerializeField] private Image _foodIndicator;
    [SerializeField] private Image _sleepIndicator;

    [SerializeField] private float _foodDecreaseRate = 0.01f; // Скорость уменьшения еды
    [SerializeField] private float _sleepDecreaseRate = 0.01f; // Скорость уменьшения сна

    private PlayerStateManager _playerStateManager;

    void Start()
    {
        _playerStateManager = GetComponent<PlayerStateManager>();
    }

    void Update()
    {
        // Уменьшение значений индикаторов
        _foodIndicator.fillAmount -= _foodDecreaseRate * Time.deltaTime;
        _sleepIndicator.fillAmount -= _sleepDecreaseRate * Time.deltaTime;

        // Если еда или сон стали меньше 0, установить их в 0
        if (_foodIndicator.fillAmount < 0)
        {
            _foodIndicator.fillAmount = 0;
        }
        
        if (_sleepIndicator.fillAmount < 0)
        {
            _sleepIndicator.fillAmount = 0;
        }

        // Обновление состояния игрока в зависимости от значений индикаторов
        UpdatePlayerState();
    }

    private void UpdatePlayerState()
    {
        if (_foodIndicator.fillAmount < 0.7f)
        {
            _playerStateManager.ChangeState(_playerStateManager.HungryState);
        }
        else if (_sleepIndicator.fillAmount < 0.5f)
        {
            _playerStateManager.ChangeState(_playerStateManager.SleepyState);
        }
        else
        {
            _playerStateManager.ChangeState(_playerStateManager.NormalState);
        }
    }
}
