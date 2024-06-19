using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.SceneLoader;
using CodeBase.UI.Services.WindowsProvider;

namespace CodeBase.GameStates
{
    public class LoadMainMenuState : IEnterableState, IService
    {
        private ISceneLoader sceneLoader;
        private IWindowsProvider windowsProvider;

        public LoadMainMenuState(ISceneLoader sceneLoader, IWindowsProvider windowsProvider)
        {
            this.sceneLoader = sceneLoader;
            this.windowsProvider = windowsProvider;
        }

        public void Enter()
        {
            sceneLoader.Load(Constants.MainMenuSceneName,onLoaded : () => windowsProvider.Open(UI.Windows.WindowId.MainMenuWindow));
        }
    }
}
