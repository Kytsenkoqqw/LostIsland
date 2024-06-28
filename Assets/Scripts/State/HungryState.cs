using System;
using UnityEngine;
using UnityEngine.UI;

namespace State
{
    public class HungryState : PlayerState
    {
        [SerializeField] private AudioSource _hungrySound;

        [SerializeField] private Image _hpIndicator;
        [SerializeField] private Image _foodIndicator;
        [SerializeField] private float _healthLossRate = 0.01f;

        private void Start()
        {
            _hungrySound = GetComponent<AudioSource>();
        }

        public override void EnterState(PlayerStateManager player)
        {
            _hungrySound.Play();
        }

        public override void UpdateState(PlayerStateManager player)
        {
            _hpIndicator.fillAmount -= _healthLossRate * Time.deltaTime;

            if (_hpIndicator.fillAmount <= 0)
            {
               
            }

            if (_foodIndicator.fillAmount >= 0.7f)
            {
                player.ChangeState(player.NormalState);
            }
        }

        public override void ExitState(PlayerStateManager player)
        {
            
        }
    }
}