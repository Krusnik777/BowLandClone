using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using CodeBase.UI.Services;
using Unity.Services.Core;

namespace CodeBase.GameStates
{
    public class GameBootstrapState : IEnterableState, IService
    {
        private IGameStateSwitcher gameStateSwitcher;
        private IConfigsProvider configsProvider;
        private IProgressSaver progressSaver;
        private IUIFactory uIFactory;
        private IAdsService adsService;
        private IIAPService iAPService;

        public GameBootstrapState(IGameStateSwitcher gameStateSwitcher, IConfigsProvider configsProvider, IProgressSaver progressSaver,
            IUIFactory uIFactory, IAdsService adsService, IIAPService iAPService)
        {
            this.gameStateSwitcher = gameStateSwitcher;
            this.configsProvider = configsProvider;
            this.progressSaver = progressSaver;
            this.uIFactory = uIFactory;
            this.adsService = adsService;
            this.iAPService = iAPService;
        }

        public async void Enter()
        {
            Debug.Log("GLOBAL: Init");

            // Connecting to Server
            // Configs Loading

            await UnityServices.InitializeAsync();

            iAPService.Initialize();

            adsService.Initialize();
            adsService.LoadInterstital();
            adsService.LoadRewarded();

            progressSaver.LoadProgress();

            configsProvider.Load();

            await uIFactory.WarmUp();

            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

            Addressables.InitializeAsync();

            if (SceneManager.GetActiveScene().name == Constants.BootstrapSceneName || SceneManager.GetActiveScene().name == Constants.MainMenuSceneName)
            {
                gameStateSwitcher.Enter<LoadMainMenuState>();
            }
        }
    }
}
