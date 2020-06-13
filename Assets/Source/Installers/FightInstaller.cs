using System.Collections.Generic;
using Source.Fight;
using Source.Fight.Enemies;
using Source.Fight.World;
using UnityEngine;
using UnityEngine.UI;
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
        [SerializeField] private WorldData _worldData;

        [Header("UI")] [SerializeField] private Text _timerText;
        [SerializeField] private Text _healthText;

        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();

            BindEnemyRelatedStuff();
            InjectDependenciesToPrefabs();
            BindWorldRules();
        }

        private void BindWorldRules()
        {
            Container.Bind<WorldData>().FromInstance(_worldData).AsSingle();
            Container.BindInterfacesTo<RoundTimeController>().AsSingle();
            Container.Bind<WinLoseController>().AsSingle();
            Container.Bind<HealthController>().AsSingle().NonLazy();

            Container.Bind<Text>().FromInstance(_timerText).AsCached().WhenInjectedInto<RoundTimeController>();
            Container.Bind<Text>().FromInstance(_healthText).AsCached().WhenInjectedInto<HealthController>();
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