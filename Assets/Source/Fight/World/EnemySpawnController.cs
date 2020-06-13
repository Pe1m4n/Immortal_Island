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
        private readonly IInstantiator _instantiator;
        private readonly SpawnZone _spawnzone;

        private float _nextSpawn;
        private float _currentTime = 0f;

        private List<SpawnData> _spawns;
        private int _nextSpawnId;
        private bool _stopSpawning;
        
        public EnemySpawnController(IInstantiator instantiator,
            SpawnZone spawnzone, WorldData worldData)
        {
            _instantiator = instantiator;
            _spawnzone = spawnzone;
            _spawns = worldData.Spawns.OrderBy(x => x.secondsTillSpawn).ToList();
            _nextSpawn = _spawns[_nextSpawnId].secondsTillSpawn;
        }

        public void Tick()
        {
            if (_stopSpawning)
            {
                return;
            }
            
            _currentTime += Time.deltaTime;   
            if (_currentTime > _nextSpawn)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            SpawnEnemy(_spawns[_nextSpawnId].enemy, _spawns[_nextSpawnId].count);
            
            _nextSpawnId++;
            if (_nextSpawnId >= _spawns.Count)
            {
                _stopSpawning = true;
                return;
            }

            _nextSpawn = _spawns[_nextSpawnId].secondsTillSpawn;
        }

        private void SpawnEnemy(EnemyData enemy, int count)
        {
            var spawnRenderer = _spawnzone.GetComponent<Renderer>();
            var bounds = spawnRenderer.bounds;
            var randomPoint =  bounds.center + new Vector3(
                (Random.value - 0.5f) * bounds.size.x,
                (Random.value - 0.5f) * bounds.size.y,
                (Random.value - 0.5f) * bounds.size.z
            );
            
            for (int i = 0; i < count; i++)
            {
                NavMeshHit hit;
                if (!NavMesh.SamplePosition(randomPoint, out hit, 3f, NavMesh.GetAreaFromName(SPAWN_NAV_MESH_LAYER)))
                {
                    Debug.LogError("Failed to get random position on spawn nav mesh layer");
                    return;
                }
            
                var prefab = enemy.Prefab;
                _instantiator.InstantiatePrefab(prefab, hit.position, Quaternion.identity, null);
            }
        }
    }
}