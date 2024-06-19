using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.ConfigsProvider;
using CodeBase.Services.GameStateMachine;
using CodeBase.Services.ProgressSaver;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.GameStates
{
    public class GameBootstrapState : IEnterableState, IService
    {
        private IGameStateSwitcher gameStateSwitcher;
        private IConfigsProvider configsProvider;
        private IProgressSaver progressSaver;

        public GameBootstrapState(IGameStateSwitcher gameStateSwitcher, IConfigsProvider configsProvider, IProgressSaver progressSaver)
        {
            this.gameStateSwitcher = gameStateSwitcher;
            this.configsProvider = configsProvider;
            this.progressSaver = progressSaver;
        }

        public void Enter()
        {
            Debug.Log("GLOBAL: Init");

            // Connecting to Server
            // Configs Loading

            progressSaver.LoadProgress();

            configsProvider.Load();

            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

            if (SceneManager.GetActiveScene().name == Constants.BootstrapSceneName || SceneManager.GetActiveScene().name == Constants.MainMenuSceneName)
            {
                gameStateSwitcher.Enter<LoadMainMenuState>();
            }
        }
    }
}
