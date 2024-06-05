using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.EntryPoints;
using CodeBase.Infrastructure.ServiceLocator;
using CodeBase.Services.GameStateMachine;
using CodeBase.Services.Input;
using CodeBase.Services.SceneLoader;
using UnityEngine;

namespace CodeBase.Installers
{
    public class GameInstaller : MonoInstaller
    {
        protected override void InstallBindings()
        {
            Debug.Log("GLOBAL: Install");

            RegisterServices();
        }

        private void RegisterServices()
        {
            //AllServices.Container.RegisterSingle<ISceneLoader>(new SceneLoader(this));
            AllServices.Container.RegisterSingle<ISceneLoader>(new SceneLoader());
            AllServices.Container.RegisterSingle<IGameStateSwitcher>(new GameStateMachine());
            AllServices.Container.RegisterSingle<IAssetProvider>(new AssetProvider());
            AllServices.Container.RegisterSingle<IInputService>(new InputService());
        }
    }
}
