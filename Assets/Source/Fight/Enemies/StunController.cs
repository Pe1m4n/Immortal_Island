using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Source.Fight.Enemies
{
    public class StunComponent : ITickable
    {
        
        private readonly PhysicsComponent _physicsComponent;

        private bool _isStunned;
        private float _getUpTime;
        
        public StunComponent(PhysicsComponent physicsComponent)
        {
            _physicsComponent = physicsComponent;
        }

        public void Tick()
        {
            if (!_isStunned)
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
            if (!_isStunned)
            {
                return;
            }

            _physicsComponent.SetRagdollActive(false);
            _isStunned = false;
        }

        public void StunForSeconds(float seconds, ExplosionArgs explosionArgs)
        {
            if (!_isStunned)
            {
                _physicsComponent.SetRagdollActive(true);
            }
            _physicsComponent.AddForce(explosionArgs);
            _getUpTime = Time.time + seconds;
            _isStunned = true;
        }
    }
}