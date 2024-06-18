using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.LevelStates;
using CodeBase.Services.LevelStateMachine;

namespace CodeBase.Bootstrappers
{
    public class LevelBootstrapper : MonoBootstrapper
    {
        private ILevelStateSwitcher levelStateSwitcher;
        private LevelBootstrapState levelBootstrapState;
        private LevelResearchState levelResearchState;
        private LevelVictoryState levelVictoryState;
        private LevelDefeatState levelDefeatState;

        [Inject]
        public void Construct(ILevelStateSwitcher levelStateSwitcher, LevelBootstrapState levelBootstrapState,
            LevelResearchState levelResearchState, LevelVictoryState levelVictoryState, LevelDefeatState levelDefeatState)
        {
            this.levelStateSwitcher = levelStateSwitcher;
            this.levelBootstrapState = levelBootstrapState;
            this.levelResearchState = levelResearchState;
            this.levelVictoryState = levelVictoryState;
            this.levelDefeatState = levelDefeatState;
        }

        public override void OnBindResolved()
        {
            /*
            ILevelStateSwitcher levelStateSwitcher = AllServices.Container.Single<ILevelStateSwitcher>();

            levelStateSwitcher.AddState(new LevelBootstrapState(
                AllServices.Container.Single<IAssetProvider>(),
                AllServices.Container.Single<HeroSpawnPoint>()
                ));

            levelStateSwitcher.Enter<LevelBootstrapState>();
            */

            InitLevelStateMachine();
        }

        private void InitLevelStateMachine()
        {
            levelStateSwitcher.AddState(levelBootstrapState);
            levelStateSwitcher.AddState(levelResearchState);
            levelStateSwitcher.AddState(levelVictoryState);
            levelStateSwitcher.AddState(levelDefeatState);

            levelStateSwitcher.Enter<LevelBootstrapState>();
        }
    }
}
