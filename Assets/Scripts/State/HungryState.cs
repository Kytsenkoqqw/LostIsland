using UnityEngine;
using UnityEngine.UI;

namespace State
{
    public class HungryState : PlayerState
    {
        [SerializeField] private Image _hpIndicator;
        [SerializeField] private Image _foodIndicator;
        [SerializeField] private float _healthLossRate = 0.01f;
        public override void EnterState(PlayerStateManager player)
        {
            Debug.Log("Player is now Hungry");
        }

        public override void UpdateState(PlayerStateManager player)
        {
            _hpIndicator.fillAmount -= _healthLossRate * Time.deltaTime;

            if (_hpIndicator.fillAmount <= 0)
            {
                Debug.Log("Player has died of hunger");
            }

            if (_foodIndicator.fillAmount >= 0.7f)
            {
                player.ChangeState(player.NormalState);
            }
        }

        public override void ExitState(PlayerStateManager player)
        {
            throw new System.NotImplementedException();
        }
    }
}