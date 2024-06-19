using CodeBase.Gameplay;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.LevelStates;
using CodeBase.Services.LevelStateMachine;
using UnityEngine;

namespace CodeBase.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelStateMachineTicker m_levelStateMachineTicker;

        public override void InstallBindings()
        {
            Debug.Log("LEVEL: Install");

            dIContainer.RegisterSingle(m_levelStateMachineTicker);

            RegisterLevelStateMachine();
        }

        private void OnDestroy()
        {
            dIContainer.UnregisterSingle<LevelStateMachineTicker>();

            UnregisterLevelStateMachine();
        }

        private void RegisterLevelStateMachine()
        {
            dIContainer.RegisterSingle<ILevelStateSwitcher, LevelStateMachine>();
            dIContainer.RegisterSingle<LevelBootstrapState>();
            dIContainer.RegisterSingle<LevelResearchState>();
            dIContainer.RegisterSingle<LevelBattleState>();
            dIContainer.RegisterSingle<LevelVictoryState>();
            dIContainer.RegisterSingle<LevelDefeatState>();
        }

        private void UnregisterLevelStateMachine()
        {
            dIContainer.UnregisterSingle<ILevelStateSwitcher>();
            dIContainer.UnregisterSingle<LevelBootstrapState>();
            dIContainer.UnregisterSingle<LevelResearchState>();
            dIContainer.UnregisterSingle<LevelBattleState>();
            dIContainer.UnregisterSingle<LevelVictoryState>();
            dIContainer.UnregisterSingle<LevelDefeatState>();
        }
    }
}
