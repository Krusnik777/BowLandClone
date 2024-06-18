using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.SceneLoader;

namespace CodeBase.GameStates
{
    public class LoadMainMenuState : IEnterableState, IService
    {
        private ISceneLoader sceneLoader;

        public LoadMainMenuState(ISceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            sceneLoader.Load(Constants.MainMenuSceneName);
        }
    }
}
