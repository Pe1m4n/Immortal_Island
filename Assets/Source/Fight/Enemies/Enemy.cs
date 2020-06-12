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

        public AnimationComponent AnimationComponent { get; private set; }
        public StunComponent StunComponent { get; private set; }

        private IEnumerable<DestinationPoint> _destinations;

        [Inject]
        public void SetUp(IEnumerable<DestinationPoint> destinations)
        {
            _destinations = destinations;
            AnimationComponent = new AnimationComponent(_animator);
            StunComponent = new StunComponent(_navMeshAgent, AnimationComponent);
        }
        
        private void Start()
        {
            var rnd = new System.Random();
            var randomDestination =  _destinations.OrderBy(x => rnd.Next()).First();
            transform.LookAt(randomDestination.transform.position);
            _navMeshAgent.SetDestination(randomDestination.transform.position);
        }
    }
}