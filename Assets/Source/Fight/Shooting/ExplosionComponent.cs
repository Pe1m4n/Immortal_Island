using UnityEngine;
using Zenject;

namespace Source.Fight
{
    public class ExplosionComponent
    {
        private readonly ExplosionObject _prefab;
        private readonly IInstantiator _instantiator;

        public ExplosionComponent(ExplosionObject prefab, IInstantiator instantiator)
        {
            _prefab = prefab;
            _instantiator = instantiator;
        }
        
        public void SpawnExplosionAt(Vector3 position)
        {
            var explosionObject = _instantiator.InstantiatePrefab(_prefab, position, Quaternion.identity, null);
        }
    }
}