using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Source.Fight.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _syncTransform;

        public AnimationComponent AnimationComponent { get; private set; }
        public StunComponent StunComponent { get; private set; }
        public PhysicsComponent PhysicsComponent { get; private set; }
        public NavigationComponent NavigationComponent { get; private set; }

        private IEnumerable<DestinationPoint> _destinations;

        [Inject]
        public void SetUp(IEnumerable<DestinationPoint> destinations)
        {
            AnimationComponent = new AnimationComponent(_animator);
            NavigationComponent = new NavigationComponent(_navMeshAgent, destinations, transform, _syncTransform);
            PhysicsComponent = new PhysicsComponent(gameObject.GetComponentsInChildren<Rigidbody>(), AnimationComponent, NavigationComponent);
            StunComponent = new StunComponent(PhysicsComponent);
        }
        
        private void Start()
        {
            NavigationComponent.GoToDestination();
        }

        private void Update()
        {
            StunComponent.Tick();
        }
    }
}