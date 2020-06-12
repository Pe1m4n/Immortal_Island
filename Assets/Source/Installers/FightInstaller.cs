using System.Collections.Generic;
using Source.Fight;
using Source.Fight.Enemies;
using Source.Fight.World;
using UnityEngine;
using Zenject;

namespace Source.Installers
{
    public class FightInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CannonComponent _cannon;
        [SerializeField] private List<EnemyData> _enemiesData;
        [SerializeField] private SpawnZone _spawnZone;
        [SerializeField] private List<DestinationPoint> _destinationPoints;

        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();

            BindEnemyRelatedStuff();
            InjectDependenciesToPrefabs();
        }

        private void BindEnemyRelatedStuff()
        {
            var enemiesDict = new Dictionary<string, EnemyData>();
            foreach (var enemy in _enemiesData)
            {
                enemiesDict.Add(enemy.Name, enemy);
            }

            Container.Bind<Dictionary<string, EnemyData>>().FromInstance(enemiesDict).AsSingle();
            Container.BindInterfacesTo<EnemySpawnController>().AsSingle().NonLazy();
            Container.Bind<SpawnZone>().FromInstance(_spawnZone).AsSingle();
            Container.Bind<IEnumerable<DestinationPoint>>().FromInstance(_destinationPoints).AsSingle();
        }

        private void InjectDependenciesToPrefabs()
        {
            Container.Inject(_cannon);
        }
    }
}