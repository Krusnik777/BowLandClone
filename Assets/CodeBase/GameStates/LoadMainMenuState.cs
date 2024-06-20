using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Services;

namespace CodeBase.GameStates
{
    public class LoadMainMenuState : IEnterableState, IService
    {
        private ISceneLoader sceneLoader;
        private IWindowsProvider windowsProvider;
        private IAssetProvider assetProvider;

        public LoadMainMenuState(ISceneLoader sceneLoader, IWindowsProvider windowsProvider, IAssetProvider assetProvider)
        {
            this.sceneLoader = sceneLoader;
            this.windowsProvider = windowsProvider;
            this.assetProvider = assetProvider;
        }

        public void Enter()
        {
            assetProvider.Cleanup();

            sceneLoader.Load(Constants.MainMenuSceneName,onLoaded : () => windowsProvider.Open(UI.Windows.WindowId.MainMenuWindow));
        }
    }
}
