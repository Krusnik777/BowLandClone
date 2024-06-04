using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.EntryPoints;
using CodeBase.Infrastructure.ServiceLocator;
using UnityEngine;

namespace CodeBase.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private HeroSpawnPoint m_heroSpawnPoint;

        protected override void InstallBindings()
        {
            Debug.Log("LEVEL: Install");

            AllServices.Container.RegisterSingle(m_heroSpawnPoint);
        }

        private void OnDestroy()
        {
            AllServices.Container.UnregisterSingle<HeroSpawnPoint>();
        }
    }
}
