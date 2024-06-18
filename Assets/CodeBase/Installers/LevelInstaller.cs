using CodeBase.Gameplay;
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
        [SerializeField] private FinishPoint m_finishPoint;
        [SerializeField] private LevelStateMachineTicker m_levelStateMachineTicker;

        public override void InstallBindings()
        {
            Debug.Log("LEVEL: Install");

            /*
            AllServices.Container.RegisterSingle<ILevelStateSwitcher>(new LevelStateMachine());
            AllServices.Container.RegisterSingle(m_heroSpawnPoint);
            */

            dIContainer.RegisterSingle(m_heroSpawnPoint);
            dIContainer.RegisterSingle(m_finishPoint);
            dIContainer.RegisterSingle(m_levelStateMachineTicker);

            RegisterLevelStateMachine();
        }

        private void OnDestroy()
        {
            /*
            AllServices.Container.UnregisterSingle<HeroSpawnPoint>();
            AllServices.Container.UnregisterSingle<ILevelStateSwitcher>();
            */

            dIContainer.UnregisterSingle<HeroSpawnPoint>();
            dIContainer.UnregisterSingle<FinishPoint>();
            dIContainer.UnregisterSingle<LevelStateMachineTicker>();

            UnregisterLevelStateMachine();
        }

        private void RegisterLevelStateMachine()
        {
            dIContainer.RegisterSingle<ILevelStateSwitcher, LevelStateMachine>();
            dIContainer.RegisterSingle<LevelBootstrapState>();
            dIContainer.RegisterSingle<LevelResearchState>();
            dIContainer.RegisterSingle<LevelVictoryState>();
            dIContainer.RegisterSingle<LevelDefeatState>();
        }

        private void UnregisterLevelStateMachine()
        {
            dIContainer.UnregisterSingle<ILevelStateSwitcher>();
            dIContainer.UnregisterSingle<LevelBootstrapState>();
            dIContainer.UnregisterSingle<LevelResearchState>();
            dIContainer.UnregisterSingle<LevelVictoryState>();
            dIContainer.UnregisterSingle<LevelDefeatState>();
        }
    }
}
