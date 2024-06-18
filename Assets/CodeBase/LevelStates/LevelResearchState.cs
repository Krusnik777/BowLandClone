using CodeBase.Gameplay;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.GameFactory;
using CodeBase.Services.LevelStateMachine;
using UnityEngine;

namespace CodeBase.LevelStates
{
    public class LevelResearchState : IEnterableState, ITickableState, IExitableState, IService
    {
        private IGameFactory gameFactory;
        private ILevelStateSwitcher levelStateSwitcher;
        private FinishPoint finishPoint;

        public LevelResearchState(IGameFactory gameFactory, ILevelStateSwitcher levelStateSwitcher, FinishPoint finishPoint)
        {
            this.gameFactory = gameFactory;
            this.levelStateSwitcher = levelStateSwitcher;
            this.finishPoint = finishPoint;
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
            if (Vector3.Distance(gameFactory.HeroObject.transform.position, finishPoint.transform.position) < finishPoint.Radius)
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
