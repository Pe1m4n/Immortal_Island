using System;
using System.Collections.Generic;
using System.Linq;
using Source.Fight.World;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Zenject;

namespace Source.Fight.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _syncTransform;
        [SerializeField] private GameObject _hitEffect;

        public AnimationComponent AnimationComponent { get; private set; }
        public StunComponent StunComponent { get; private set; }
        public PhysicsComponent PhysicsComponent { get; private set; }
        public NavigationComponent NavigationComponent { get; private set; }

        private IEnumerable<DestinationPoint> _destinations;

        [Inject]
        public void SetUp(IEnumerable<DestinationPoint> destinations, HealthController healthController, WinLoseController winLoseController)
        {
            AnimationComponent = new AnimationComponent(_animator);
            NavigationComponent = new NavigationComponent(_navMeshAgent, destinations, transform, _syncTransform, healthController, winLoseController, _hitEffect);
            PhysicsComponent = new PhysicsComponent(gameObject.GetComponentsInChildren<Rigidbody>(), AnimationComponent, NavigationComponent);
            StunComponent = new StunComponent(PhysicsComponent);
            NavigationComponent.Init(StunComponent);
        }
        
        private void Start()
        {
            NavigationComponent.GoToDestination();
        }

        private void Update()
        {
            StunComponent.Tick();
            NavigationComponent.Tick();
        }
    }
}