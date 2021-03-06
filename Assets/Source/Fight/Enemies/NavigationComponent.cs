﻿using System;
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
        private readonly WinLoseController _winLoseController;
        private readonly GameObject _hitEffect;
        private readonly IInstantiator _instantiator;

        private DestinationPoint _destination;
        private StunComponent _stunComponent;
        private bool _stopUpdating;

        public NavigationComponent(NavMeshAgent agent, IEnumerable<DestinationPoint> destinationPoints,
            Transform mainTransform, Transform syncTransform,HealthController healthController,
            WinLoseController winLoseController, GameObject hitEffect, IInstantiator instantiator)
        {
            _agent = agent;
            _mainTransform = mainTransform;
            _syncTransform = syncTransform;
            _healthController = healthController;
            _winLoseController = winLoseController;
            _hitEffect = hitEffect;
            _instantiator = instantiator;

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
            if (_stopUpdating)
            {
                return;
            }
            
            if (_agent.hasPath && (_winLoseController.GameLost || _winLoseController.GameWon))
            {
                _agent.isStopped = true;
                _agent.ResetPath();
                _stopUpdating = true;
            }
            
            if (_agent.hasPath && (_mainTransform.position - _destination.transform.position).magnitude <= 0.4f)
            {
                if (_hitEffect != null)
                {
                    _instantiator.InstantiatePrefab(_hitEffect, _mainTransform.position, _mainTransform.rotation, null);
                }
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