using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services;

namespace CodeBase.LevelStates
{
    public class LevelBattleState : IEnterableState, ITickableState, IExitableState, IService
    {
        private IGameFactory gameFactory;
        private ILevelStateSwitcher levelStateSwitcher;

        public LevelBattleState(IGameFactory gameFactory, ILevelStateSwitcher levelStateSwitcher)
        {
            this.gameFactory = gameFactory;
            this.levelStateSwitcher = levelStateSwitcher;
        }

        public void Enter()
        {
            gameFactory.HeroHealth.EventOnDie += OnHeroDie;
        }

        public void Exit()
        {
            gameFactory.HeroHealth.EventOnDie -= OnHeroDie;
        }

        public void Tick()
        {
            if (!gameFactory.HeroCondition.IsTargeted)
            {
                levelStateSwitcher.Enter<LevelResearchState>();
            }
        }

        private void OnHeroDie()
        {
            levelStateSwitcher.Enter<LevelDefeatState>();
        }
    }
}
