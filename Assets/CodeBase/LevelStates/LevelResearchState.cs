using CodeBase.Configs;
using CodeBase.Gameplay;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.LevelStates
{
    public class LevelResearchState : IEnterableState, ITickableState, IExitableState, IService
    {
        private IGameFactory gameFactory;
        private ILevelStateSwitcher levelStateSwitcher;
        private IConfigsProvider configsProvider;

        private LevelConfig levelConfig;

        public LevelResearchState(IGameFactory gameFactory, ILevelStateSwitcher levelStateSwitcher, IConfigsProvider configsProvider)
        {
            this.gameFactory = gameFactory;
            this.levelStateSwitcher = levelStateSwitcher;
            this.configsProvider = configsProvider;
        }

        public void Enter()
        {
            gameFactory.HeroHealth.EventOnDie += OnHeroDie;

            levelConfig = configsProvider.GetLevel(SceneManager.GetActiveScene().name);
        }

        public void Exit()
        {
            gameFactory.HeroHealth.EventOnDie -= OnHeroDie;
        }

        public void Tick()
        {
            if (gameFactory.HeroCondition.IsTargeted)
            {
                levelStateSwitcher.Enter<LevelBattleState>();
                return;
            }

            if (Vector3.Distance(gameFactory.HeroObject.transform.position, levelConfig.FinishPoint) < FinishPoint.Radius)
            {
                levelStateSwitcher.Enter<LevelVictoryState>();
            }
        }

        private void OnHeroDie()
        {
            levelStateSwitcher.Enter<LevelDefeatState>();
        }
    }
}
