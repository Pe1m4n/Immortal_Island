using System.Collections.Generic;
using UnityEngine;

namespace Source.Fight.Enemies
{
    public class PhysicsComponent
    {
        private readonly IEnumerable<Rigidbody> _rigidbodies;
        
        public bool IsRagdollActive { get; private set; }

        public PhysicsComponent(IEnumerable<Rigidbody> rigidbodies)
        {
            _rigidbodies = rigidbodies;
        }

        public void SetRagdollActive(bool active)
        {
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
                rb.AddExplosionForce(args.Force, args.ExplosionPosition, args.Radius, args.Upwards);
            }
        }
    }
}