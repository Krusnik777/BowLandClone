using CodeBase.GameStates;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.Services;
using CodeBase.Services;
using CodeBase.UI.Services;
using UnityEngine;

namespace CodeBase.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("GLOBAL: Install");

            RegisterGameServices();

            RegisterGameStateMachine();
        }

        private void RegisterGameServices()
        {
            dIContainer.RegisterSingle<IConfigsProvider, ConfigsProvider>();
            dIContainer.RegisterSingle<IProgressProvider, ProgressProvider>();
            dIContainer.RegisterSingle<IProgressSaver, ProgressSaver>();
            dIContainer.RegisterSingle<ICoroutineRunner, CoroutineRunner>();
            dIContainer.RegisterSingle<ISceneLoader, SceneLoader>();
            dIContainer.RegisterSingle<IAssetProvider, AssetProvider>();
            dIContainer.RegisterSingle<IInputService, InputService>();
            dIContainer.RegisterSingle<IGameFactory, GameFactory>();

            dIContainer.RegisterSingle<IUIFactory, UIFactory>();
            dIContainer.RegisterSingle<IWindowsProvider, WindowsProvider>();

            dIContainer.RegisterSingle<IAdsService,AdsService>();
            dIContainer.RegisterSingle<IIAPService, IAPService>();
        }

        private void RegisterGameStateMachine()
        {
            dIContainer.RegisterSingle<IGameStateSwitcher, GameStateMachine>();
            dIContainer.RegisterSingle<GameBootstrapState>();
            dIContainer.RegisterSingle<LoadMainMenuState>();
            dIContainer.RegisterSingle<LoadNextLevelState>();
        }
    }
}
