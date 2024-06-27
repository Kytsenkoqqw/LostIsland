using UnityEngine;

namespace State
{
    public abstract class PlayerState : MonoBehaviour
    {
        public abstract void EnterState(PlayerStateManager player);
        public abstract void UpdateState(PlayerStateManager player);
        public abstract void ExitState(PlayerStateManager player);
    }
}