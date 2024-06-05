using CodeBase.Infrastructure.ServiceLocator;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.SceneLoader;

namespace CodeBase.GameStates
{
    public class LoadNextLevelState : IEnterableState, IService
    {
        private ISceneLoader sceneLoader;

        public LoadNextLevelState(ISceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            sceneLoader.Load("Level_1"); // TEMP
        }
    }
}
