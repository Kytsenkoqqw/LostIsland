using UnityEngine;

namespace State
{
    public abstract class PlayerState : MonoBehaviour
    {
        public abstract void Hungry();

        public abstract void Temperature();

        public abstract void Sleepy();
    }
}