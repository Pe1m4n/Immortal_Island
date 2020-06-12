using Source.Common;
using Zenject;

namespace Source.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputHandlingBlocker>().AsSingle();
        }
    }
}