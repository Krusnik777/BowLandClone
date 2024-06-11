using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.LevelStates;
using CodeBase.Services.LevelStateMachine;

namespace CodeBase.Bootstrappers
{
    public class LevelBootstrapper : MonoBootstrapper
    {
        private ILevelStateSwitcher levelStateSwitcher;
        private LevelBootstrapState levelBootstrapState;

        [Inject]
        public void Construct(ILevelStateSwitcher levelStateSwitcher, LevelBootstrapState levelBootstrapState)
        {
            this.levelStateSwitcher = levelStateSwitcher;
            this.levelBootstrapState = levelBootstrapState;
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

            levelStateSwitcher.Enter<LevelBootstrapState>();
        }
    }
}
