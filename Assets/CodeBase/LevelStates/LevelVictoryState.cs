using CodeBase.GameStates;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.GameFactory;
using CodeBase.Services.GameStateMachine;
using CodeBase.Services.Input;

namespace CodeBase.LevelStates
{
    public class LevelVictoryState : IEnterableState, IService
    {
        private IInputService inputService;
        private IGameFactory gameFactory;
        private IGameStateSwitcher gameStateSwitcher;

        public LevelVictoryState(IInputService inputService, IGameFactory gameFactory, IGameStateSwitcher gameStateSwitcher)
        {
            this.inputService = inputService;
            this.gameFactory = gameFactory;
            this.gameStateSwitcher = gameStateSwitcher;
        }

        public void Enter()
        {
            inputService.Enabled = false;
            gameFactory.VirtualJoystick.gameObject.SetActive(false);

            gameStateSwitcher.Enter<LoadMainMenuState>();
        }
    }
}
