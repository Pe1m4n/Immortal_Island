using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Zenject;

namespace Source.Fight.Enemies
{
    public class StunComponent : ITickable
    {
        private readonly PhysicsComponent _physicsComponent;
        private readonly UnityEvent _onStun;

        public bool IsStunned { get; private set; }
        private float _getUpTime;
        
        public StunComponent(PhysicsComponent physicsComponent, UnityEvent onStun)
        {
            _physicsComponent = physicsComponent;
            _onStun = onStun;
        }

        public void Tick()
        {
            if (!IsStunned)
            {
                return;
            }

            if (Time.time > _getUpTime)
            {
                GetUp();
            }
        }

        private void GetUp()
        {
            if (!IsStunned)
            {
                return;
            }

            _physicsComponent.SetRagdollActive(false);
            IsStunned = false;
        }

        public void StunForSeconds(float seconds, ExplosionArgs explosionArgs)
        {
            if (!IsStunned)
            {
                _physicsComponent.SetRagdollActive(true);
            }
            _onStun?.Invoke();
            _physicsComponent.AddForce(explosionArgs);
            _getUpTime = Time.time + seconds;
            IsStunned = true;
        }
    }
}