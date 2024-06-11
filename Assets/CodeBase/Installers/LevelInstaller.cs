using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.LevelStates;
using CodeBase.Services.LevelStateMachine;
using UnityEngine;

namespace CodeBase.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private HeroSpawnPoint m_heroSpawnPoint;

        public override void InstallBindings()
        {
            Debug.Log("LEVEL: Install");

            /*
            AllServices.Container.RegisterSingle<ILevelStateSwitcher>(new LevelStateMachine());
            AllServices.Container.RegisterSingle(m_heroSpawnPoint);
            */

            dIContainer.RegisterSingle(m_heroSpawnPoint);

            RegisterLevelStateMachine();
        }

        private void OnDestroy()
        {
            /*
            AllServices.Container.UnregisterSingle<HeroSpawnPoint>();
            AllServices.Container.UnregisterSingle<ILevelStateSwitcher>();
            */

            dIContainer.UnregisterSingle<HeroSpawnPoint>();

            UnregisterLevelStateMachine();
        }

        private void RegisterLevelStateMachine()
        {
            dIContainer.RegisterSingle<ILevelStateSwitcher, LevelStateMachine>();
            dIContainer.RegisterSingle<LevelBootstrapState>();
        }

        private void UnregisterLevelStateMachine()
        {
            dIContainer.UnregisterSingle<ILevelStateSwitcher>();
            dIContainer.UnregisterSingle<LevelBootstrapState>();
        }
    }
}
