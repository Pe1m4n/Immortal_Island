using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Source.Fight.Enemies
{
    public class StunComponent : ITickable
    {
        private readonly PhysicsComponent _physicsComponent;

        public bool IsStunned { get; private set; }
        private float _getUpTime;
        
        public StunComponent(PhysicsComponent physicsComponent)
        {
            _physicsComponent = physicsComponent;
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
            _physicsComponent.AddForce(explosionArgs);
            _getUpTime = Time.time + seconds;
            IsStunned = true;
        }
    }
}