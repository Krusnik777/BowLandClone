using CodeBase.GameStates;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.CoroutineRunner;
using CodeBase.Services.GameFactory;
using CodeBase.Services.GameStateMachine;
using CodeBase.Services.Input;
using CodeBase.Services.SceneLoader;
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
            /*
            AllServices.Container.RegisterSingle<ISceneLoader>(new SceneLoader(this));
            AllServices.Container.RegisterSingle<IGameStateSwitcher>(new GameStateMachine());
            AllServices.Container.RegisterSingle<IAssetProvider>(new AssetProvider());
            AllServices.Container.RegisterSingle<IInputService>(new InputService());
            */

            dIContainer.RegisterSingle<ICoroutineRunner, CoroutineRunner>();
            dIContainer.RegisterSingle<ISceneLoader, SceneLoader>();
            dIContainer.RegisterSingle<IAssetProvider, AssetProvider>();
            dIContainer.RegisterSingle<IInputService, InputService>();
            dIContainer.RegisterSingle<IGameFactory, GameFactory>();
        }

        private void RegisterGameStateMachine()
        {
            dIContainer.RegisterSingle<IGameStateSwitcher, GameStateMachine>();
            dIContainer.RegisterSingle<GameBootstrapState>();
            dIContainer.RegisterSingle<LoadNextLevelState>();
        }
    }
}
