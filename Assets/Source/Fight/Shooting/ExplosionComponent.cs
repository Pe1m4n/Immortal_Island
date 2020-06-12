using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

namespace Source.Fight
{
    public class ExplosionComponent
    {
        private readonly ExplosionObject _prefab;
        private readonly IInstantiator _instantiator;
        private readonly CannonSettings _settings;

        public ExplosionComponent(ExplosionObject prefab, IInstantiator instantiator, CannonSettings settings)
        {
            _prefab = prefab;
            _instantiator = instantiator;
            _settings = settings;
        }
        
        public void SpawnExplosionAt(Vector3 position, float power)
        {
            var delta = _settings.ExplosionDelayMax - _settings.ExplosionDelayMin;
            var delay = delta * power;
            Observable.Timer(TimeSpan.FromSeconds(_settings.ExplosionDelayMin + delay)).Subscribe((l) =>
            {
                var explosionObject = _instantiator.InstantiatePrefab(_prefab, position, Quaternion.identity, null);
            });
        }
    }
}