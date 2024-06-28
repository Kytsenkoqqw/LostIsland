using Unity.VisualScripting;
using UnityEngine;

namespace State
{
    public class PlayerStateManager : MonoBehaviour
    {
        public PlayerState CurrentState { get; private set; }
        // Состояния
        public HungryState HungryState = new HungryState();
        public SleepyState SleepyState = new SleepyState();
        public NormalState NormalState = new NormalState();

        private PlayerState currentState;
        private PlayerController _playerController;
        private IndicatorManager _indicatorManager;

        void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _indicatorManager = GetComponent<IndicatorManager>();
            // Начальное состояние
            currentState = NormalState;
            currentState.EnterState(this);
        }

        void Update()
        {
            currentState.UpdateState(this);
        }

        public void ChangeState(PlayerState newState)
        {
            if (currentState == newState)
            {
                // Не делать ничего, если текущее состояние уже равно новому состоянию
                return;
            }

            // Установить новое состояние
            currentState.ExitState(this);
            newState.EnterState(this);
            currentState = newState;
        }
        
        public void SetSpeed(float speed)
        {
            if (_playerController != null)
            {
                _playerController.SetMoveSpeed(speed);
            }
        }
    }
}