using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services;
using CodeBase.UI.Services;

namespace CodeBase.LevelStates
{
    public class LevelDefeatState : IEnterableState, IService
    {
        private IInputService inputService;
        private IGameFactory gameFactory;
        private IWindowsProvider windowsProvider;

        public LevelDefeatState(IInputService inputService, IGameFactory gameFactory, IWindowsProvider windowsProvider)
        {
            this.inputService = inputService;
            this.gameFactory = gameFactory;
            this.windowsProvider = windowsProvider;
        }

        public void Enter()
        {
            inputService.Enabled = false;
            gameFactory.VirtualJoystick.gameObject.SetActive(false);

            windowsProvider.Open(UI.Windows.WindowId.DefeatWindow);
        }
    }
}
