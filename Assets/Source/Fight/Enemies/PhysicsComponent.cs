using System.Collections.Generic;
using UnityEngine;

namespace Source.Fight.Enemies
{
    public class PhysicsComponent
    {
        private readonly IEnumerable<Rigidbody> _rigidbodies;
        private readonly AnimationComponent _animationComponent;
        private readonly NavigationComponent _navigationComponent;

        public bool IsRagdollActive { get; private set; }

        public PhysicsComponent(IEnumerable<Rigidbody> rigidbodies, AnimationComponent animationComponent,
            NavigationComponent navigationComponent)
        {
            _rigidbodies = rigidbodies;
            _animationComponent = animationComponent;
            _navigationComponent = navigationComponent;
        }

        public void SetRagdollActive(bool active)
        {
            _animationComponent.SetAnimationsActive(!active);
            _navigationComponent.SetNavigationActive(!active);
            foreach (var rb in _rigidbodies)
            {
                rb.isKinematic = !active;
            }

            IsRagdollActive = active;
        }
        
        public void AddForce(ExplosionArgs args)
        {
            if (!IsRagdollActive)
            {
                return;
            }

            foreach (var rb in _rigidbodies)
            {
                var forceVector = (rb.position - args.ExplosionPosition).normalized;
                forceVector.y = args.Upwards;
                forceVector *= args.Force;
                rb.AddForce(forceVector);
            }
        }
    }
}