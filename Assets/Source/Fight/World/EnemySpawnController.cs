using System.Collections.Generic;
using System.Linq;
using Source.Fight.Enemies;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Source.Fight.World
{
    public class EnemySpawnController : ITickable
    {
        private const string SPAWN_NAV_MESH_LAYER = "Spawn";
        private const float TEST_SPAWN_DELAY = 5f;
        private readonly Dictionary<string, EnemyData> _enemies;
        private readonly IInstantiator _instantiator;
        private readonly SpawnZone _spawnzone;

        private float _nextSpawn = float.MinValue;

        public EnemySpawnController(Dictionary<string, EnemyData> enemies, IInstantiator instantiator,
            SpawnZone spawnzone)
        {
            _enemies = enemies;
            _instantiator = instantiator;
            _spawnzone = spawnzone;
        }

        public void Tick()
        {
            if (Time.time > _nextSpawn)
            {
                Spawn();
                _nextSpawn = Time.time + TEST_SPAWN_DELAY;
            }
        }

        private void Spawn()
        {
            var spawnRenderer = _spawnzone.GetComponent<Renderer>();
            var bounds = spawnRenderer.bounds;
            var randomPoint =  bounds.center + new Vector3(
                (Random.value - 0.5f) * bounds.size.x,
                (Random.value - 0.5f) * bounds.size.y,
                (Random.value - 0.5f) * bounds.size.z
            );
            NavMeshHit hit;
            if (!NavMesh.SamplePosition(randomPoint, out hit, 3f, NavMesh.GetAreaFromName(SPAWN_NAV_MESH_LAYER)))
            {
                Debug.LogError("Failed to get random position on spawn nav mesh layer");
                return;
            }
            
            var prefab = _enemies.First().Value.Prefab;
            _instantiator.InstantiatePrefab(prefab, hit.position, Quaternion.identity, null);
        }
    }
}