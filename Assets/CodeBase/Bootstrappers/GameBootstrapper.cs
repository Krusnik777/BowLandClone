using CodeBase.GameStates;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.GameStateMachine;

namespace CodeBase.Bootstrappers
{
    public class GameBootstrapper : MonoBootstrapper
    {
        private IGameStateSwitcher gameStateSwitcher;
        private GameBootstrapState gameBootstrapState;
        private LoadMainMenuState loadMainMenuState;
        private LoadNextLevelState loadNextLevelState;

        [Inject]
        public void Construct(IGameStateSwitcher gameStateSwitcher, GameBootstrapState gameBootstrapState, LoadMainMenuState loadMainMenuState, LoadNextLevelState loadNextLevelState)
        {
            this.gameStateSwitcher = gameStateSwitcher;
            this.gameBootstrapState = gameBootstrapState;
            this.loadMainMenuState = loadMainMenuState;
            this.loadNextLevelState = loadNextLevelState;
        }

        public override void OnBindResolved()
        {
            /*
            DontDestroyOnLoad(this); // TEMP

            IGameStateSwitcher gameStateSwitcher = AllServices.Container.Single<IGameStateSwitcher>();

            gameStateSwitcher.AddState(new GameBootstrapState(gameStateSwitcher));
            gameStateSwitcher.AddState(new LoadNextLevelState(AllServices.Container.Single<ISceneLoader>()));

            gameStateSwitcher.Enter<GameBootstrapState>();
            */

            InitGameStateMachine();
        }

        private void InitGameStateMachine()
        {
            gameStateSwitcher.AddState(gameBootstrapState);
            gameStateSwitcher.AddState(loadMainMenuState);
            gameStateSwitcher.AddState(loadNextLevelState);

            gameStateSwitcher.Enter<GameBootstrapState>();
        }
    }
}
