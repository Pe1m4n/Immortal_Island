using UnityEngine.AI;
using Zenject;

namespace Source.Fight.Enemies
{
    public class StunComponent : ITickable
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly AnimationComponent _animationComponent;

        private bool _isStunned;
        
        public StunComponent(NavMeshAgent navMeshAgent, AnimationComponent animationComponent)
        {
            _navMeshAgent = navMeshAgent;
            _animationComponent = animationComponent;
        }


        public void Tick()
        {
            
        }

        public void StunForSeconds(float seconds)
        {
            _animationComponent.StopAnimations();
            _navMeshAgent.isStopped = true;
        }
    }
}