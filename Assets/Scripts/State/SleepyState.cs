using System;
using UnityEngine;
using UnityEngine.UI;


namespace State

{
    public class SleepyState : PlayerState
    {
        [SerializeField] private AudioSource _sleepySound;
        
        [SerializeField] private Image _sleepIndicator;
        [SerializeField] private float _normalSpeed = 5f; // Нормальная скорость
        [SerializeField] private float _reducedSpeed = 2f; // Уменьшенная скорость

        private void Start()
        {
            _sleepySound = GetComponent<AudioSource>();
        }

        public override void EnterState(PlayerStateManager player)
        {
            _sleepySound.Play();
            player.SetSpeed(_reducedSpeed);
        }

        public override void UpdateState(PlayerStateManager player)
        {
            float sleepFillAmount = _sleepIndicator.fillAmount;

            // Проверка, если персонаж больше не сонный
            if (sleepFillAmount >= 0.5f)
            {
                player.ChangeState(player.NormalState);
            }
        }

        public override void ExitState(PlayerStateManager player)
        {
            // Восстановление нормальной скорости при выходе из состояния сонливости
            player.SetSpeed(_normalSpeed);
        }
    }
}