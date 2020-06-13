using Source.Common;
using Source.Fight.Points;
using Source.Leaderboard;
using UnityEngine;
using Zenject;

namespace Source.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LocationsInfo _locations;
        [SerializeField] private PointsData _pointsData;
        public override void InstallBindings()
        {
            Container.Bind<InputHandlingBlocker>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle().NonLazy();
            Container.Bind<NextFightController>().AsSingle();
            Container.Bind<LocationsInfo>().FromInstance(_locations).AsSingle();
            Container.Bind<PointsData>().FromInstance(_pointsData).AsSingle();
            Container.Bind<PlayerNameHolder>().AsSingle();
            Container.Bind<LeaderBoardController>().AsSingle();
        }
    }
}