using UnityEngine;
using UnityEngine.UI;


namespace State

{
    public class SleepyState : PlayerState
    {
        [SerializeField] private Image _sleepIndicator;
        [SerializeField] private float _normalSpeed = 5f; // Нормальная скорость
        [SerializeField] private float _reducedSpeed = 2f; // Уменьшенная скорость

        public override void EnterState(PlayerStateManager player)
        {
            Debug.Log("Player is now Sleepy");
            // Уменьшение скорости при входе в состояние сонливости
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
            Debug.Log("Player is no longer Sleepy");
            // Восстановление нормальной скорости при выходе из состояния сонливости
            player.SetSpeed(_normalSpeed);
        }
    }
}