using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Source.Fight.Enemies
{
    public class NavigationComponent
    {
        private readonly NavMeshAgent _agent;
        private readonly Transform _mainTransform;
        private readonly Transform _syncTransform;

        private DestinationPoint _destination;

        public NavigationComponent(NavMeshAgent agent, IEnumerable<DestinationPoint> destinationPoints,
            Transform mainTransform, Transform syncTransform)
        {
            _agent = agent;
            _mainTransform = mainTransform;
            _syncTransform = syncTransform;
            
            var random = new System.Random();
            _destination = destinationPoints.OrderBy(x => random.Next()).First();
            mainTransform.LookAt(_destination.transform.position);
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