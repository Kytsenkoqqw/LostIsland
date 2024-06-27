using System;
using UnityEngine;
using UnityEngine.UI;

namespace State
{
    public class NormalState : PlayerState
    {
        [SerializeField] private Image _hpIndicator;
        [SerializeField] private Image _foodIndicator;
        [SerializeField] private Image _speelIndicator;
        
        public override void EnterState(PlayerStateManager player)
        {
            float foodFillAmount = _foodIndicator.fillAmount;
            float sleepFillAmount = _speelIndicator.fillAmount;
            
            if (foodFillAmount > 0.7f)
            {
                player.ChangeState(player.NormalState);
            }
            else if (sleepFillAmount > 0.7f)
            {
                player.ChangeState(player.NormalState);
            }
        }

        public override void UpdateState(PlayerStateManager player)
        {
            float foodFillAmount = _foodIndicator.fillAmount;
            float sleepFillAmount = _speelIndicator.fillAmount;
            
            if (foodFillAmount < 0.7f)
            {
                player.ChangeState(player.HungryState);
            }
            else if (sleepFillAmount < 0.7f)
            {
                player.ChangeState(player.SleepyState);
            }
        }

        public override void ExitState(PlayerStateManager player)
        {
            
        }
    }
}