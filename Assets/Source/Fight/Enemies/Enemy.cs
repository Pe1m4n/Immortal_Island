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

        private IEnumerable<DestinationPoint> _destinations; 
        
        
        [Inject]
        public void SetUp(IEnumerable<DestinationPoint> destinations)
        {
            _destinations = destinations;
        }
        
        private void Start()
        {
            var rnd = new System.Random();
            var randomDestination =  _destinations.OrderBy(x => rnd.Next()).First();
            _navMeshAgent.SetDestination(randomDestination.transform.position);
        }
    }
}