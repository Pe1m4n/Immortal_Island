using System;
using System.Collections.Generic;
using System.Linq;
using Source.Fight.World;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Object = System.Object;

namespace Source.Fight.Enemies
{
    public class NavigationComponent : ITickable
    {
        private readonly NavMeshAgent _agent;
        private readonly Transform _mainTransform;
        private readonly Transform _syncTransform;
        private readonly HealthController _healthController;

        private DestinationPoint _destination;
        private StunComponent _stunComponent;

        public NavigationComponent(NavMeshAgent agent, IEnumerable<DestinationPoint> destinationPoints,
            Transform mainTransform, Transform syncTransform,HealthController healthController)
        {
            _agent = agent;
            _mainTransform = mainTransform;
            _syncTransform = syncTransform;
            _healthController = healthController;

            var random = new System.Random();
            _destination = destinationPoints.OrderBy(x => random.Next()).First();
            mainTransform.LookAt(_destination.transform.position);
        }

        public void Init(StunComponent stunComponent)
        {
            _stunComponent = stunComponent;
        }

        public void Tick()
        {
            if (_agent.hasPath && _agent.remainingDistance <= 0.2f)
            {
                _healthController.DecrementHealth();
                UnityEngine.Object.Destroy(_mainTransform.gameObject);
            }
        }
        
        public void SetNavigationActive(bool active)
        {
            if (!active && _agent.enabled)
            {
                _agent.isStopped = false;
                _agent.ResetPath();
            }

            _agent.enabled = active;

            if (active)
            {
                var syncPos = new Vector3(
                    _syncTransform.position.x,
                    _mainTransform.position.y,
                    _syncTransform.position.z);

                _mainTransform.position = syncPos;
            }
        }

        public void GoToDestination()
        {
            _agent.SetDestination(_destination.transform.position);
        }
    }
}