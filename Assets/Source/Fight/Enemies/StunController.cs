using UnityEngine.AI;
using Zenject;

namespace Source.Fight.Enemies
{
    public class StunComponent : ITickable
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly AnimationComponent _animationComponent;
        private readonly PhysicsComponent _physicsComponent;

        private bool _isStunned;
        
        public StunComponent(NavMeshAgent navMeshAgent, AnimationComponent animationComponent, 
            PhysicsComponent physicsComponent)
        {
            _navMeshAgent = navMeshAgent;
            _animationComponent = animationComponent;
            _physicsComponent = physicsComponent;
        }

        public void Tick()
        {
            
        }

        public void StunForSeconds(float seconds, ExplosionArgs explosionArgs)
        {
            _animationComponent.StopAnimations();
            _navMeshAgent.isStopped = true;
            _navMeshAgent.enabled = false;
            _physicsComponent.SetRagdollActive(true);
            _physicsComponent.AddForce(explosionArgs);
        }
    }
}