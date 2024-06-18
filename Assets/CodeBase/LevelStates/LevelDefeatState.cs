using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.GameFactory;
using CodeBase.Services.Input;

namespace CodeBase.LevelStates
{
    public class LevelDefeatState : IEnterableState, IService
    {
        private IInputService inputService;
        private IGameFactory gameFactory;

        public LevelDefeatState(IInputService inputService, IGameFactory gameFactory)
        {
            this.inputService = inputService;
            this.gameFactory = gameFactory;
        }

        public void Enter()
        {
            inputService.Enabled = false;
            gameFactory.VirtualJoystick.gameObject.SetActive(false);
        }
    }
}
