using CodeBase.GameStates;
using CodeBase.Infrastructure.EntryPoints;
using CodeBase.Infrastructure.ServiceLocator;
using CodeBase.Services.GameStateMachine;
using CodeBase.Services.SceneLoader;

namespace CodeBase.Bootstrappers
{
    public class GameBootstrapper : MonoBootstrapper
    {
        public override void Bootstrap()
        {
            DontDestroyOnLoad(this); // TEMP?

            IGameStateSwitcher gameStateSwitcher = AllServices.Container.Single<IGameStateSwitcher>();

            gameStateSwitcher.AddState(new GameBootstrapState(gameStateSwitcher));
            gameStateSwitcher.AddState(new LoadNextLevelState(AllServices.Container.Single<ISceneLoader>()));

            gameStateSwitcher.Enter<GameBootstrapState>();
        }
    }
}
