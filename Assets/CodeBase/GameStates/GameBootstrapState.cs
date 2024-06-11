using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.GameStateMachine;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class GameBootstrapState : IEnterableState, IService
    {
        private IGameStateSwitcher gameStateSwitcher;

        public GameBootstrapState(IGameStateSwitcher gameStateSwitcher)
        {
            this.gameStateSwitcher = gameStateSwitcher;
        }

        public void Enter()
        {
            Debug.Log("GLOBAL: Init");

            // Connecting to Server
            // Configs Loading

            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

            gameStateSwitcher.Enter<LoadNextLevelState>();
        }
    }
}
